namespace ProjetoMDC.Views
{
    partial class CadastroProduto
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.cbDisponivel = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbImagem = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btAdicionarImagem = new System.Windows.Forms.Button();
            this.numQuantidade = new System.Windows.Forms.NumericUpDown();
            this.numValor = new System.Windows.Forms.NumericUpDown();
            this.btSalvarProduto = new System.Windows.Forms.Button();
            this.txtFechar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 26F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(113, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(538, 51);
            this.label3.TabIndex = 21;
            this.label3.Text = "CADASTRO DE PRODUTOS";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(122, 168);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(188, 22);
            this.txtNome.TabIndex = 22;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(463, 168);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(188, 22);
            this.txtDescricao.TabIndex = 23;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNome.Location = new System.Drawing.Point(119, 149);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(49, 18);
            this.lblNome.TabIndex = 29;
            this.lblNome.Text = "Nome";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDescricao.Location = new System.Drawing.Point(460, 149);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(76, 18);
            this.lblDescricao.TabIndex = 30;
            this.lblDescricao.Text = "Descrição";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblQuantidade.Location = new System.Drawing.Point(119, 233);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(83, 18);
            this.lblQuantidade.TabIndex = 31;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // cbDisponivel
            // 
            this.cbDisponivel.AutoSize = true;
            this.cbDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbDisponivel.Location = new System.Drawing.Point(463, 255);
            this.cbDisponivel.Name = "cbDisponivel";
            this.cbDisponivel.Size = new System.Drawing.Size(118, 24);
            this.cbDisponivel.TabIndex = 33;
            this.cbDisponivel.Text = "Disponível?";
            this.cbDisponivel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(119, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 34;
            this.label1.Text = "Valor";
            // 
            // pbImagem
            // 
            this.pbImagem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbImagem.InitialImage = global::ProjetoMDC.Properties.Resources.OIP__1_;
            this.pbImagem.Location = new System.Drawing.Point(463, 338);
            this.pbImagem.Name = "pbImagem";
            this.pbImagem.Size = new System.Drawing.Size(182, 121);
            this.pbImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagem.TabIndex = 35;
            this.pbImagem.TabStop = false;
            this.pbImagem.Click += new System.EventHandler(this.pbImagem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(460, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 36;
            this.label2.Text = "Imagem";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btAdicionarImagem
            // 
            this.btAdicionarImagem.BackColor = System.Drawing.Color.Silver;
            this.btAdicionarImagem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdicionarImagem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btAdicionarImagem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btAdicionarImagem.Location = new System.Drawing.Point(460, 465);
            this.btAdicionarImagem.Name = "btAdicionarImagem";
            this.btAdicionarImagem.Size = new System.Drawing.Size(121, 32);
            this.btAdicionarImagem.TabIndex = 59;
            this.btAdicionarImagem.Text = "Selecionar";
            this.btAdicionarImagem.UseVisualStyleBackColor = false;
            this.btAdicionarImagem.Click += new System.EventHandler(this.btAdicionarImagem_Click);
            // 
            // numQuantidade
            // 
            this.numQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.numQuantidade.Location = new System.Drawing.Point(122, 253);
            this.numQuantidade.Name = "numQuantidade";
            this.numQuantidade.Size = new System.Drawing.Size(188, 24);
            this.numQuantidade.TabIndex = 60;
            // 
            // numValor
            // 
            this.numValor.DecimalPlaces = 2;
            this.numValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.numValor.Location = new System.Drawing.Point(122, 338);
            this.numValor.Name = "numValor";
            this.numValor.Size = new System.Drawing.Size(188, 24);
            this.numValor.TabIndex = 61;
            // 
            // btSalvarProduto
            // 
            this.btSalvarProduto.BackColor = System.Drawing.Color.Green;
            this.btSalvarProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalvarProduto.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btSalvarProduto.ForeColor = System.Drawing.Color.AliceBlue;
            this.btSalvarProduto.Location = new System.Drawing.Point(650, 582);
            this.btSalvarProduto.Name = "btSalvarProduto";
            this.btSalvarProduto.Size = new System.Drawing.Size(121, 32);
            this.btSalvarProduto.TabIndex = 62;
            this.btSalvarProduto.Text = "Salvar";
            this.btSalvarProduto.UseVisualStyleBackColor = false;
            this.btSalvarProduto.Click += new System.EventHandler(this.btSalvarProduto_Click);
            // 
            // txtFechar
            // 
            this.txtFechar.AutoSize = true;
            this.txtFechar.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechar.Location = new System.Drawing.Point(754, 0);
            this.txtFechar.Name = "txtFechar";
            this.txtFechar.Size = new System.Drawing.Size(29, 31);
            this.txtFechar.TabIndex = 63;
            this.txtFechar.Text = "X";
            this.txtFechar.Click += new System.EventHandler(this.txtFechar_Click_1);
            // 
            // CadastroProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(783, 626);
            this.Controls.Add(this.txtFechar);
            this.Controls.Add(this.btSalvarProduto);
            this.Controls.Add(this.numValor);
            this.Controls.Add(this.numQuantidade);
            this.Controls.Add(this.btAdicionarImagem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbImagem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDisponivel);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CadastroProduto";
            this.Text = "CadastroProduto";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.CheckBox cbDisponivel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbImagem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAdicionarImagem;
        private System.Windows.Forms.NumericUpDown numQuantidade;
        private System.Windows.Forms.NumericUpDown numValor;
        private System.Windows.Forms.Button btSalvarProduto;
        private System.Windows.Forms.Label txtFechar;
    }
}