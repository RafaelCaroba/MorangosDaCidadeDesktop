using System;

namespace ProjetoMDC.Views
{
    partial class CadastroFuncionario
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedCpf = new System.Windows.Forms.MaskedTextBox();
            this.maskedDataNasc = new System.Windows.Forms.MaskedTextBox();
            this.maskedTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedSenha = new System.Windows.Forms.MaskedTextBox();
            this.btSalvarProduto = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblEmail.Location = new System.Drawing.Point(93, 211);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 18);
            this.lblEmail.TabIndex = 34;
            this.lblEmail.Text = "E-mail";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNome.Location = new System.Drawing.Point(93, 126);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(49, 18);
            this.lblNome.TabIndex = 33;
            this.lblNome.Text = "Nome";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(96, 230);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(309, 22);
            this.txtEmail.TabIndex = 32;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(96, 145);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(309, 22);
            this.txtNome.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 26F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(54, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(622, 51);
            this.label3.TabIndex = 35;
            this.label3.Text = "CADASTRO DE FUNCIONÁRIOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(482, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 39;
            this.label1.Text = "Data de Nascimento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(93, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "CPF";
            // 
            // maskedCpf
            // 
            this.maskedCpf.AllowPromptAsInput = false;
            this.maskedCpf.Location = new System.Drawing.Point(96, 307);
            this.maskedCpf.Mask = "000.000.000-00";
            this.maskedCpf.Name = "maskedCpf";
            this.maskedCpf.Size = new System.Drawing.Size(188, 22);
            this.maskedCpf.TabIndex = 40;
            // 
            // maskedDataNasc
            // 
            this.maskedDataNasc.AllowPromptAsInput = false;
            this.maskedDataNasc.Location = new System.Drawing.Point(485, 230);
            this.maskedDataNasc.Mask = "00/00/0000";
            this.maskedDataNasc.Name = "maskedDataNasc";
            this.maskedDataNasc.Size = new System.Drawing.Size(140, 22);
            this.maskedDataNasc.TabIndex = 41;
            this.maskedDataNasc.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTelefone
            // 
            this.maskedTelefone.AllowPromptAsInput = false;
            this.maskedTelefone.Location = new System.Drawing.Point(485, 145);
            this.maskedTelefone.Mask = "(00) 00000-0000";
            this.maskedTelefone.Name = "maskedTelefone";
            this.maskedTelefone.Size = new System.Drawing.Size(140, 22);
            this.maskedTelefone.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(482, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 42;
            this.label4.Text = "Telefone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(93, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 18);
            this.label5.TabIndex = 45;
            this.label5.Text = "Senha";
            // 
            // maskedSenha
            // 
            this.maskedSenha.AllowPromptAsInput = false;
            this.maskedSenha.Location = new System.Drawing.Point(96, 387);
            this.maskedSenha.Name = "maskedSenha";
            this.maskedSenha.PasswordChar = '*';
            this.maskedSenha.Size = new System.Drawing.Size(188, 22);
            this.maskedSenha.TabIndex = 46;
            // 
            // btSalvarProduto
            // 
            this.btSalvarProduto.BackColor = System.Drawing.Color.Green;
            this.btSalvarProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalvarProduto.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btSalvarProduto.ForeColor = System.Drawing.Color.AliceBlue;
            this.btSalvarProduto.Location = new System.Drawing.Point(613, 489);
            this.btSalvarProduto.Name = "btSalvarProduto";
            this.btSalvarProduto.Size = new System.Drawing.Size(121, 32);
            this.btSalvarProduto.TabIndex = 63;
            this.btSalvarProduto.Text = "Salvar";
            this.btSalvarProduto.UseVisualStyleBackColor = false;
            this.btSalvarProduto.Click += new System.EventHandler(this.btSalvarFuncionario_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(717, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 31);
            this.label6.TabIndex = 64;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // CadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(746, 533);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedCpf);
            this.Controls.Add(this.btSalvarProduto);
            this.Controls.Add(this.maskedSenha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTelefone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maskedDataNasc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CadastroFuncionario";
            this.Text = "CadastroFuncionario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedCpf;
        private System.Windows.Forms.MaskedTextBox maskedDataNasc;
        private System.Windows.Forms.MaskedTextBox maskedTelefone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedSenha;
        private System.Windows.Forms.Button btSalvarProduto;
        private System.Windows.Forms.Label label6;
    }
}