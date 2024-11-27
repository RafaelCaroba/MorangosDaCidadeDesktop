using MorangosDaCidade.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMDC.Views
{
    public partial class CadastroFuncionario : Form
    {
        public Funcionario Funcionario { get; private set; }
        public CadastroFuncionario(Funcionario funcionario = null)
        {
            InitializeComponent();
            Funcionario = funcionario ?? new Funcionario();
            maskedDataNasc.TypeValidationCompleted += maskedTextBoxDataNascimento_TypeValidationCompleted;

            if (funcionario != null)
            {
                txtNome.Text = funcionario.Nome; 
                maskedCpf.Text = funcionario.Cpf; 
                txtEmail.Text = funcionario.Email; 
                maskedTelefone.Text = funcionario.Telefone; 
                maskedDataNasc.Text = funcionario.DataNascimento.Value.ToString("dd/MM/yyyy");
                maskedSenha.Text = funcionario.Senha;
            }
        }

        private void maskedTextBoxDataNascimento_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MessageBox.Show("Data de Nascimento inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                maskedDataNasc.Focus();
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSalvarFuncionario_Click(object sender, EventArgs e)
        {
            Funcionario.Nome = txtNome.Text; 
            Funcionario.Cpf = maskedCpf.Text;
            Funcionario.Email = txtEmail.Text;
            Funcionario.Telefone = maskedTelefone.Text;
            Funcionario.DataNascimento = new SqlDateTime(DateTime.Parse(maskedDataNasc.Text)); 
            Funcionario.Senha = maskedSenha.Text;


            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Funcionarios funcionarios = new Funcionarios();
            funcionarios.Show();
            this.Close();
        }
    }
}
