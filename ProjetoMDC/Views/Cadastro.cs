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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void txtFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario funcionario = new Funcionario
                {
                    Nome = txtNome.Text,
                    Cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Replace(",", ""),
                    Email = txtEmail.Text,
                    Telefone = txtCelular.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""),
                    DataNascimento = DateTime.Parse(txtDtaDeNascimento.Text),
                    Senha = txtSenha.Text
                };

                FuncionarioService funcionarioService = new FuncionarioService();
                funcionarioService.SalvarFuncionario(funcionario);
                MessageBox.Show("Funcionário cadastrado com sucesso!");

                Gerenciamento gerenciamento = new Gerenciamento();
                gerenciamento.Show();
                this.Hide();

            } catch (Exception ex) { MessageBox.Show($"Erro ao cadastrar funcionário: {ex.Message}"); }
        }
        }
    }

