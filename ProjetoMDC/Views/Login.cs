using MorangosDaCidade.Entities;
using MorangosDaCidade.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMDC.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void CadastroLogin_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUusario.Text;
            string senha = txtSenha.Text;

            FuncionarioService funcionarioService = new FuncionarioService();
            AdminService adminService = new AdminService();

            try
            {
                Funcionario funcionario =
                    await funcionarioService.BuscarFuncionarioPorEmailSenhaAsync(email, senha);

                if (funcionario != null)
                {
                    MessageBox.Show($"Bem-vindo, {funcionario.Nome}!");
                    Gerenciamento gerenciamento = new Gerenciamento();
                    gerenciamento.Show();
                    Hide();
                }
                else
                {
                    Administrador administrador =
                        await adminService.BuscarAdministradorPorEmailSenhaAsync(email, senha);

                    if (administrador != null)
                    {
                        MessageBox.Show($"Bem-vindo, {administrador.Nome}!");
                        Gerenciamento gerenciamento = new Gerenciamento();
                        gerenciamento.Show();
                        Hide();
                    }
                    else MessageBox.Show("Credenciais inválidas. Tente novamente.");
                }
            }
            catch (Exception ex) { MessageBox.Show($"Erro: {ex.Message}"); }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
            this.Hide();
        }

        private void txtFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void txtLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
