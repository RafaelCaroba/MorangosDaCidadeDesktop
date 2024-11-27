using MorangosDaCidade2.Entities;
using MorangosDaCidade2.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace ProjetoMDC.Views
{
    public partial class Gerenciamento : Form
    {
        ProdutoService produtoService = new ProdutoService();

        public Gerenciamento()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Gerenciamento_Load);
        }

        private async void Gerenciamento_Load(object sender, EventArgs e)
        {
            await CarregarProdutosAsync();
        }

        private async Task CarregarProdutosAsync()
        {
            var produtos = await produtoService.ListarProdutosAsync();


            if (produtos != null)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("IdProduto", typeof(int));
                dataTable.Columns.Add("Nome", typeof(String));
                dataTable.Columns.Add("Descricao", typeof(String));
                dataTable.Columns.Add("Quantidade", typeof(int));
                dataTable.Columns.Add("Disponivel", typeof(bool));
                dataTable.Columns.Add("Valor", typeof(double));
                dataTable.Columns.Add("Imagem", typeof(byte[]));

                foreach (var produto in produtos)
                {
                    DataRow row = dataTable.NewRow(); 
                    row["IdProduto"] = produto.Id; 
                    row["Nome"] = produto.Nome; 
                    row["Descricao"] = produto.Descricao; 
                    row["Quantidade"] = produto.Quantidade; 
                    row["Disponivel"] = produto.Disponivel; 
                    row["Valor"] = produto.Valor; 
                    row["Imagem"] = produto.Imagem; 
                    dataTable.Rows.Add(row);
                }

                dgvProdutos.DataSource = dataTable;

                foreach  (DataGridViewRow row in dgvProdutos.Rows)
                {
                    if (row.Cells["Imagem"].Value != DBNull.Value)
                    {
                        byte[] imageBytes = row.Cells["Imagem"].Value as byte[];
                        row.Cells["Imagem"].Value = ByteArrayToImage(imageBytes);
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há produtos cadastrados.");
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                return Properties.Resources.strawberry_berry_levitating_white_background;
            }

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    return Image.FromStream(ms);
                }
            } catch (ArgumentException ex)
            {
                Console.WriteLine("Erro ao converter byte array para imagem: " + ex.Message); 
                return Properties.Resources.strawberry_berry_levitating_white_background;
            }
            
        }
        private async void btAdicionarProd_Click(object sender, EventArgs e)
        {
            CadastroProduto form = new CadastroProduto();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await produtoService.SalvarProdutoAsync(form.Produto); 
                await CarregarProdutosAsync();
            }

        }

        private async void btEditarProd_Click(object sender, EventArgs e)
        {
            int selectedRow = dgvProdutos.SelectedRows[0].Index;
            int productId = (int)dgvProdutos.Rows[selectedRow].Cells["IdProduto"].Value;

            Produto produto = await produtoService.BuscarProdutoPorIdAsync(productId);
            CadastroProduto form = new CadastroProduto(produto);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await produtoService.AtualizarProdutoAsync(form.Produto);
                await CarregarProdutosAsync();
            }
        }

        private async void btExcluirProd_Click(object sender, EventArgs e)
        {
            
            int selectedRow = dgvProdutos.SelectedRows[0].Index;
            int productId = (int)dgvProdutos.Rows[selectedRow].Cells["IdProduto"].Value;
            Console.WriteLine($"ID SELECIONADO: {IdProduto}");

            Produto produto = await produtoService.BuscarProdutoPorIdAsync(productId);
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja excluir?", "Confirmação" , 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
                await produtoService.DeletarProdutoAsync(productId);
                await CarregarProdutosAsync();

            }
        }

        private void txtFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label23_Click(object sender, EventArgs e)
        {
        }

        private void label29_Click(object sender, EventArgs e)
        {
        }

        private void txtHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void txtSobreNos_Click(object sender, EventArgs e)
        {
            SobreNos sobreNos = new SobreNos();
            sobreNos.Show();
            this.Hide();
        }

        private void txtContato_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato();
            contato.Show();
            this.Hide();
        }

        private void label28_Click(object sender, EventArgs e)
        {
        }

        private void Gerenciamento_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtProdutos_Click(object sender, EventArgs e)
        {
            
        }

        private void BtFuncionarios_Click(object sender, EventArgs e)
        {
            Funcionarios funcionarios = new Funcionarios();
            funcionarios.Show();
            this.Hide();
        }
    }
}
