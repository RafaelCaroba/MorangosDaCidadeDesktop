using MorangosDaCidade.Entities;
using MorangosDaCidade.Service;
using ProjetoMDC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMDC
{
    public partial class Contato : Form
    {
        public Contato()
        {
            InitializeComponent();
        }

        private void Contato_Load(object sender, EventArgs e)
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

        private void txtFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtContato_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato();
            contato.Show();
            this.Hide();
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente novoCliente = new Cliente
                {
                    Nome = txtNome.Text,
                    Email = textemail.Text,
                    Telefone = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""),
                };

                ClienteService clienteService = new ClienteService();
                await clienteService.SalvarCliente(novoCliente);
                MessageBox.Show("Cliente cadastrado com sucesso!");

                // Limpar campos após cadastro
                txtNome.Clear();
                textemail.Clear();
                txtTelefone.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar cliente: {ex.Message}");
            }
        }


        private void txtLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void pictureFacebook_Click(object sender, EventArgs e)
        {
            try
            {
                string facebookUrl = "https://www.facebook.com/suaPagina";

                Process.Start(new ProcessStartInfo(facebookUrl) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar abrir a página do Facebook: " + ex.Message);
            }
        }

        private void pictureX_Click(object sender, EventArgs e)
        {
            try
            {
                string XUrl = "https://www.x.com/suaPagina";

                Process.Start(new ProcessStartInfo(XUrl) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar abrir a página do X: " + ex.Message);
            }
        }

        private void pictureInstagram_Click(object sender, EventArgs e)
        {
            try
            {
                string InstagramUrl = "https://www.instagram.com/suaPagina";

                Process.Start(new ProcessStartInfo(InstagramUrl) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar abrir a página do instagram: " + ex.Message);
            }
        }

        private void picturelinkedln_Click(object sender, EventArgs e)
        {
            try
            {
                string LinkedlnUrl = "https://www.instagram.com/suaPagina";

                Process.Start(new ProcessStartInfo(LinkedlnUrl) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar abrir a página do linkedln: " + ex.Message);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
