using MorangosDaCidade2.Entities;
using MorangosDaCidade2.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMDC.Views
{
    public partial class Gerenciamento : Form
    {
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
            ProdutoService produtoService = new ProdutoService();
            List<Produto> produtos = await produtoService.ListarProdutosAsync();

            // Exibe apenas os 4 primeiros produtos
            produtos = produtos.Take(4).ToList();

            if (produtos.Count > 0)
            {
                label1.Text = produtos[0].Nome;
               // label6.Text = "Quant. no estoque: " + produtos[0].Quantidade;
                label11.Text = produtos[0].Quantidade.ToString();

                label2.Text = produtos.Count > 1 ? produtos[1].Nome : "";
               // label7.Text = produtos.Count > 1 ? "Quant. no estoque: " + produtos[1].Quantidade : "";
                label12.Text = produtos.Count > 1 ? produtos[1].Quantidade.ToString() : "";

                label4.Text = produtos.Count > 2 ? produtos[2].Nome : "";
               // label8.Text = produtos.Count > 2 ? "Quant. no estoque: " + produtos[2].Quantidade : "";
                label13.Text = produtos.Count > 2 ? produtos[2].Quantidade.ToString() : "";

                label5.Text = produtos.Count > 3 ? produtos[3].Nome : "";
               // label9.Text = produtos.Count > 3 ? "Quant. no estoque: " + produtos[3].Quantidade : "";
                label26.Text = produtos.Count > 3 ? produtos[3].Quantidade.ToString() : "";
            }
            else
            {
                MessageBox.Show("Não há produtos cadastrados.");
            }
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                // Atualizar Quantidade
                await AtualizarQuantidadeAsync(label1.Text, int.Parse(textBox1.Text));
                await AtualizarQuantidadeAsync(label1.Text, -int.Parse(textBox5.Text));
                await AtualizarQuantidadeAsync(label2.Text, int.Parse(textBox2.Text));
                await AtualizarQuantidadeAsync(label2.Text, -int.Parse(textBox6.Text));
                await AtualizarQuantidadeAsync(label4.Text, int.Parse(textBox3.Text));
                await AtualizarQuantidadeAsync(label4.Text, -int.Parse(textBox7.Text));
                await AtualizarQuantidadeAsync(label5.Text, int.Parse(textBox4.Text));
                await AtualizarQuantidadeAsync(label5.Text, -int.Parse(textBox8.Text));

                // Atualizar Nome
                await AtualizarNomeAsync(label1.Text, textBox12.Text);
                await AtualizarNomeAsync(label2.Text, textBox11.Text);
                await AtualizarNomeAsync(label4.Text, textBox10.Text);
                await AtualizarNomeAsync(label5.Text, textBox9.Text);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();

                MessageBox.Show("Atualizações realizadas com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar atualizações: {ex.Message}");
            }
        }

        private async Task AtualizarQuantidadeAsync(string nomeProduto, int quantidade)
        {
            ProdutoService produtoService = new ProdutoService();
            Produto produto = (await produtoService.ListarProdutosPorNomeAsync(nomeProduto)).FirstOrDefault();

            if (produto != null)
            {
                produto.Quantidade += quantidade;
                if (produto.Quantidade < 0) produto.Quantidade = 0;

                if (await produtoService.AtualizarProdutoAsync(produto))
                {
                    await CarregarProdutosAsync();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar a quantidade do produto.");
                }
            }
            else
            {
                MessageBox.Show("Produto não encontrado.");
            }
        }

        private async Task AtualizarNomeAsync(string nomeProdutoAntigo, string nomeProdutoNovo)
        {
            ProdutoService produtoService = new ProdutoService();
            Produto produto = (await produtoService.ListarProdutosPorNomeAsync(nomeProdutoAntigo)).FirstOrDefault();

            if (produto != null)
            {
                produto.Nome = nomeProdutoNovo;

                if (await produtoService.AtualizarProdutoAsync(produto))
                {
                    await CarregarProdutosAsync();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar o nome do produto.");
                }
            }
            else
            {
                MessageBox.Show("Produto não encontrado.");
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
    }
}
