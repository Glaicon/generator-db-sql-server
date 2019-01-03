using GeradorDB.Domain;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace GeradorDB
{
    public partial class FormGeradorDB : Form
    {
        public FormGeradorDB()
        {
            InitializeComponent();
        }
        private const string CAMINHO_DATABASE = @"C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\";
        private const string CAMINHO_BACKUP = @"C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Backup\";
        private void btnBackup_Click(object sender, EventArgs e)
        {
            var servidor = txtServidor.Text;
            var usuarioServidor = txtUsuarioServidor.Text;
            var password = mskSenhaUsuarioServidor.Text;
            var dataBaseModelo = cboBasesDados.SelectedValue != null ? cboBasesDados.SelectedValue.ToString() : null;

            if (ValidaCampos(servidor, usuarioServidor, "não necessita dessa informação", dataBaseModelo, "não necessita dessa informação"))
            {
                var server = new Server(servidor);
                server.ConnectionContext.LoginSecure = false;   // set to true for Windows Authentication  
                server.ConnectionContext.Login = usuarioServidor;
                server.ConnectionContext.Password = password;
                Console.WriteLine(server.Information.Version);   // connection is established  

                var backup = new Backup();
                string nomeArquivoBackup = string.Format("{0}_{1:yyyyMMdd_HHmmss}.bak", dataBaseModelo, DateTime.Now);
                var bdi = new BackupDeviceItem(nomeArquivoBackup, DeviceType.File);
                backup.Database = dataBaseModelo;
                backup.Devices.Add(bdi);
                backup.Incremental = false;

                var backupdate = new DateTime();
                backupdate = DateTime.Now;
                backup.ExpirationDate = backupdate;

                backup.LogTruncation = BackupTruncateLogType.Truncate;

                backup.SqlBackup(server);
                server.Refresh();
                MessageBox.Show(string.Format("Backup '{0}' concluído com sucesso.", nomeArquivoBackup), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string usuarioServidor = txtUsuarioServidor.Text;
            string password = mskSenhaUsuarioServidor.Text;

            var dataBaseName = txtDataBase.Text;
            var dataBaseModelo = cboBasesDados.SelectedValue != null ? cboBasesDados.SelectedValue.ToString() : null;
            var backupSelecionado = cboListaDeBases.SelectedValue != null ? cboListaDeBases.SelectedValue.ToString() : null;
            var servidor = txtServidor.Text;

            if (ValidaCampos(servidor, usuarioServidor, dataBaseName, dataBaseModelo, backupSelecionado))
            {
                try
                {
                    var server = new Server(servidor);
                    server.ConnectionContext.LoginSecure = false;
                    server.ConnectionContext.Login = usuarioServidor;
                    server.ConnectionContext.Password = password;
                    Console.WriteLine(server.Information.Version);

                    Database backUpFile = new Database(server, backupSelecionado);

                    string logFile = System.IO.Path.GetDirectoryName(CAMINHO_DATABASE);
                    logFile = System.IO.Path.Combine(logFile, dataBaseName + "_Log.ldf");

                    string dataFile = System.IO.Path.GetDirectoryName(CAMINHO_DATABASE);
                    dataFile = System.IO.Path.Combine(dataFile, dataBaseName + ".mdf");

                    var restore = new Restore();

                    restore.RelocateFiles.Add(new RelocateFile(dataBaseModelo + "_Data", dataFile));
                    restore.RelocateFiles.Add(new RelocateFile(dataBaseModelo + "_Log", logFile));

                    restore.Database = dataBaseName;
                    restore.Action = RestoreActionType.Database;
                    restore.NoRecovery = false;
                    restore.ReplaceDatabase = true;
                    restore.Devices.AddDevice(backupSelecionado, DeviceType.File);

                    server.KillAllProcesses(dataBaseName);
                    restore.SqlRestore(server);

                    server.Refresh();

                    MessageBox.Show(string.Format("Backup '{0}' restaurado com sucesso. Nova base de dados {1}", cboListaDeBases.Text, dataBaseName), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private bool ValidaCampos(string servidor, string usuarioServidor, string dataBaseName, string dataBaseModelo, string backupSelecionado)
        {
            if (string.IsNullOrEmpty(servidor))
            {
                MessageBox.Show("É necessário informar o servidor que está o banco de dados!");
                txtServidor.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(usuarioServidor))
            {
                MessageBox.Show("É necessário informar o usuário que tenha privilégio para acessar o servidor de banco de dados!");
                txtDataBase.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(dataBaseName))
            {
                MessageBox.Show("É necessário informar qual o nome da nova base de dados!");
                txtDataBase.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(dataBaseModelo))
            {
                MessageBox.Show("É necessário informar qual será a base de dados a ser replicada!");
                cboBasesDados.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(backupSelecionado))
            {
                MessageBox.Show("É necessário selecionar o backup a ser restaurado, ou faça um backup da base que deseja replicar!");
                cboListaDeBases.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void cboListaDeBases_DropDown(object sender, EventArgs e)
        {
            var servidor = txtServidor.Text;
            var usuarioServidor = txtUsuarioServidor.Text;
            var senhaUsuarioServidor = mskSenhaUsuarioServidor.Text;
            var baseDadosModelo = cboBasesDados.SelectedValue != null ? cboBasesDados.SelectedValue.ToString() : null;

            if (ValidaCampos(servidor, usuarioServidor, "não necessita dessa informação", baseDadosModelo, "não necessita dessa informação"))
            {
                try
                {
                    using (var connection = new System.Data.SqlClient.SqlConnection(string.Format("Server={0};Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=True;TrustServerCertificate=False;Connection Timeout=30;", servidor, "master", usuarioServidor, senhaUsuarioServidor)))
                    {
                        connection.Open();

                        using (var command = new System.Data.SqlClient.SqlCommand(
                            "SELECT physical_device_name FROM msdb.dbo.backupmediafamily " +
                            "INNER JOIN msdb.dbo.backupset ON msdb.dbo.backupmediafamily.media_set_id = msdb.dbo.backupset.media_set_id " +
                            "WHERE (msdb.dbo.backupset.database_name LIKE @DatabaseName)", connection))
                        {
                            command.Parameters.AddWithValue("DatabaseName", baseDadosModelo);

                            using (var reader = command.ExecuteReader())
                            {
                                var table = new DataTable();
                                table.Load(reader);
                                table.Columns.Add("FriendlyName");
                                foreach (DataRow row in table.Rows)
                                {
                                    row["FriendlyName"] = System.IO.Path.GetFileName(row["physical_device_name"].ToString());
                                }
                                if (cboListaDeBases.DataSource != null && cboListaDeBases.DataSource is DataTable)
                                {
                                    var oldTable = ((DataTable)cboListaDeBases.DataSource);
                                    cboListaDeBases.DataSource = null;
                                    oldTable.Dispose();
                                }
                                cboListaDeBases.DataSource = table;
                                cboListaDeBases.DisplayMember = "FriendlyName";
                                cboListaDeBases.ValueMember = "physical_device_name";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cboBasesDados_DropDown(object sender, EventArgs e)
        {
            var servidor = txtServidor.Text;
            var usuarioServidor = txtUsuarioServidor.Text;
            var password = mskSenhaUsuarioServidor.Text;

            if (ValidaCampos(servidor, usuarioServidor, "não necessita dessa informação", "não necessita dessa informação", "não necessita dessa informação"))
            {
                var server = new Server(servidor);
                server.ConnectionContext.LoginSecure = false;   // set to true for Windows Authentication  
                server.ConnectionContext.Login = usuarioServidor;
                server.ConnectionContext.Password = password;
                Console.WriteLine(server.Information.Version);   // connection is established  

                List<BaseDados> bases = new List<BaseDados>();
                foreach (var item in server.Databases)
                {
                    var baseDados = new BaseDados(item.ToString().Replace("[","").Replace("]",""));
                    bases.Add(baseDados);
                }

                cboBasesDados.DataSource = bases;
                cboBasesDados.DisplayMember = "Nome";
                cboBasesDados.ValueMember = "Nome";
            }
        }
    }
}
