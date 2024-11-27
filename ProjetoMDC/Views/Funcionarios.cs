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
    public partial class Funcionarios : Form
    {
        FuncionarioService funcionarioService = new FuncionarioService();
        public Funcionarios()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Funcionarios_Load);
        }

        private async void Funcionarios_Load(object sender, EventArgs e)
        {
            await CarregarFuncionariosAsync();
        }

        private async Task CarregarFuncionariosAsync()
        {
            try
            {
                var funcionarios = await funcionarioService.ListarFuncionariosAsync();

                if (funcionarios != null)
                {
                    DataTable dataTable = new DataTable(); 
                    dataTable.Columns.Add("IdFuncionario", typeof(int)); 
                    dataTable.Columns.Add("Nome", typeof(string)); 
                    dataTable.Columns.Add("Cpf", typeof(string)); 
                    dataTable.Columns.Add("Email", typeof(string)); 
                    dataTable.Columns.Add("Telefone", typeof(string)); 
                    dataTable.Columns.Add("DataNascimento", typeof(DateTime)); 

                    foreach (var funcionario in funcionarios)
                    {
                        DataRow row = dataTable.NewRow(); 
                        row["IdFuncionario"] = funcionario.Id; 
                        row["Nome"] = funcionario.Nome; 
                        row["Cpf"] = funcionario.Cpf;
                        row["Email"] = funcionario.Email; 
                        row["Telefone"] = funcionario.Telefone; 
                        row["DataNascimento"] = funcionario.DataNascimento.Value; 
                        dataTable.Rows.Add(row);
                    }
                    dgvFuncionarios.DataSource = dataTable;
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {

        }

        private async void btAdicionarFuncionario_ClickAsync(object sender, EventArgs e)
        {
            CadastroFuncionario form = new CadastroFuncionario();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await funcionarioService.SalvarFuncionarioAsync(form.Funcionario); 
                await CarregarFuncionariosAsync();
            }
        }

        private async void btnEditFuncionario_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dgvFuncionarios.SelectedRows[0].Index;
                int funcionarioId = (int)dgvFuncionarios.Rows[selectedRowIndex].Cells["IdFuncionario"].Value;
                Funcionario funcionario = await funcionarioService.BuscarFuncionarioPorIdAsync(funcionarioId);
                CadastroFuncionario form = new CadastroFuncionario(funcionario);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    await funcionarioService.AtualizarFuncionarioAsync(form.Funcionario);
                    await CarregarFuncionariosAsync();
                }

            }
        }

        private async void btExcluirFuncionario_Click(object sender, EventArgs e) 
        { 
            if (dgvFuncionarios.SelectedRows.Count > 0) 
            { 
                int selectedRowIndex = dgvFuncionarios.SelectedRows[0].Index; 
                int funcionarioId = (int)dgvFuncionarios.Rows[selectedRowIndex].Cells["IdFuncionario"].Value; 
                DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja excluir este funcionário?", 
                    "Confirmação de Deleção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); 
                
                if (dialogResult == DialogResult.Yes) 
                { 
                    funcionarioService.DeletarFuncionario(funcionarioId);
                    await CarregarFuncionariosAsync(); 
                } 
            } 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void BtProdutos_Click(object sender, EventArgs e)
        {
            Gerenciamento gerenciamento = new Gerenciamento();
            gerenciamento.Show();
            this.Hide();
        }
    }
}
