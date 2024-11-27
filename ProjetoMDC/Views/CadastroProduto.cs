using MorangosDaCidade2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace ProjetoMDC.Views
{
    public partial class CadastroProduto : Form
    {
        public Produto Produto { get; private set; }
        private byte[] imagem;
        public CadastroProduto(Produto produto = null)
        {
            InitializeComponent();
            Produto = produto ?? new Produto();

            if (produto != null)
            {
                txtNome.Text = produto.Nome;
                txtDescricao.Text = produto.Descricao;
                numQuantidade.Value = produto.Quantidade;
                numValor.Value = (decimal)produto.Valor;
                if (produto.Imagem != null)
                {
                    pbImagem.Image = ByteArrayToImage(produto.Imagem);
                }
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
           // if (byteArray == null || byteArray.Length == 0)
            //{
              //  return Properties.Resources.strawberry_berry_levitating_white_background;
            //}
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pbImagem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btAdicionarImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string caminhoSelecionado = ofd.FileName;
                pbImagem.Image = Image.FromFile(caminhoSelecionado);
                imagem = ImageToByteArray(pbImagem.Image);
            }
        }

        private void btSalvarProduto_Click(object sender, EventArgs e)
        {
            Produto.Nome = txtNome.Text;
            Produto.Descricao = txtDescricao.Text; 
            Produto.Quantidade = (int)numQuantidade.Value; 
            Produto.Disponivel = cbDisponivel.Checked; 
            Produto.Valor = (double)numValor.Value; Produto.Imagem = imagem; 
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void txtFechar_Click(object sender, EventArgs e)
        {
            Gerenciamento gerenciamento = new Gerenciamento();
            gerenciamento.Show();
            this.Close();
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void txtFechar_Click_1(object sender, EventArgs e)
        {
            Gerenciamento gerenciamento = new Gerenciamento();
            gerenciamento.Show();
            this.Close();
        }
    }
}
