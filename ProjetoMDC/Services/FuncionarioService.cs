using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MorangosDaCidade.Entities;
using MorangosDaCidade.Repository;
namespace MorangosDaCidade.Service
{
    class FuncionarioService
    {
        public FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        public FuncionarioService() { }

        public async Task<bool> SalvarFuncionarioAsync(Funcionario f)
        {
            int result = await funcionarioRepository.CadastrarFuncionarioAsync(f);
            return result > 0;
        }


        public async Task<List<Funcionario>> ListarFuncionariosAsync()
        {
            List<Funcionario> funcionarios = await funcionarioRepository.ListarFuncionariosAsync();
            return funcionarios;
        }

        public List<Funcionario> ListarFuncionariosPorNome(string nome)
        {
            List<Funcionario> funcionarios = funcionarioRepository.BuscarFuncionarioPorNome(nome);
            return funcionarios;
        }

        public async Task<Funcionario> BuscarFuncionarioPorIdAsync(int id)
        {
            Funcionario funcionario = await funcionarioRepository.BuscarFuncionarioPorIdAsync(id);
            return funcionario;
        }


        public async Task<bool> AtualizarFuncionarioAsync(Funcionario f)
        {
            if (await funcionarioRepository.AtualizarFuncionarioAsync(f) > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeletarFuncionario(int id)
        {
            if (funcionarioRepository.DeletarFuncionario(id) > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<Funcionario> BuscarFuncionarioPorEmailSenhaAsync(string email, string senha)
        {
            Funcionario funcionario = await funcionarioRepository.BuscarFuncionarioPorEmailSenhaAsync(email, senha);

            if (funcionario == null)
            {            }

            return funcionario;
        }

    }
}