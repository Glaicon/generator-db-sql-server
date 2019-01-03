namespace GeradorDB
{
    partial class FormGeradorDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.cboListaDeBases = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsuarioServidor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mskSenhaUsuarioServidor = new System.Windows.Forms.MaskedTextBox();
            this.cboBasesDados = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nova Base de dados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(234, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gerador de Base de dados";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(57, 83);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(179, 20);
            this.txtServidor.TabIndex = 4;
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(361, 123);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(302, 20);
            this.txtDataBase.TabIndex = 10;
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(57, 149);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(606, 23);
            this.btnBackup.TabIndex = 11;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(57, 205);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(606, 23);
            this.btnRestore.TabIndex = 14;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // cboListaDeBases
            // 
            this.cboListaDeBases.FormattingEnabled = true;
            this.cboListaDeBases.Location = new System.Drawing.Point(57, 178);
            this.cboListaDeBases.Name = "cboListaDeBases";
            this.cboListaDeBases.Size = new System.Drawing.Size(606, 21);
            this.cboListaDeBases.TabIndex = 12;
            this.cboListaDeBases.DropDown += new System.EventHandler(this.cboListaDeBases_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Base de dados modelo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Usuário Servidor";
            // 
            // txtUsuarioServidor
            // 
            this.txtUsuarioServidor.Location = new System.Drawing.Point(255, 83);
            this.txtUsuarioServidor.Name = "txtUsuarioServidor";
            this.txtUsuarioServidor.Size = new System.Drawing.Size(240, 20);
            this.txtUsuarioServidor.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(516, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Senha Usuário Servidor";
            // 
            // mskSenhaUsuarioServidor
            // 
            this.mskSenhaUsuarioServidor.Location = new System.Drawing.Point(519, 83);
            this.mskSenhaUsuarioServidor.Name = "mskSenhaUsuarioServidor";
            this.mskSenhaUsuarioServidor.Size = new System.Drawing.Size(144, 20);
            this.mskSenhaUsuarioServidor.TabIndex = 6;
            // 
            // cboBasesDados
            // 
            this.cboBasesDados.FormattingEnabled = true;
            this.cboBasesDados.Location = new System.Drawing.Point(57, 123);
            this.cboBasesDados.Name = "cboBasesDados";
            this.cboBasesDados.Size = new System.Drawing.Size(280, 21);
            this.cboBasesDados.TabIndex = 15;
            this.cboBasesDados.DropDown += new System.EventHandler(this.cboBasesDados_DropDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 265);
            this.Controls.Add(this.cboBasesDados);
            this.Controls.Add(this.mskSenhaUsuarioServidor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUsuarioServidor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboListaDeBases);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Gerador de Base de dados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ComboBox cboListaDeBases;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsuarioServidor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mskSenhaUsuarioServidor;
        private System.Windows.Forms.ComboBox cboBasesDados;
    }
}

