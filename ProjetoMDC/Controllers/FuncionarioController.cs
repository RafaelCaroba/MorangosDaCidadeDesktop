﻿using System;
using System.Threading;
using System.Data.SqlTypes;
using MorangosDaCidade.Entities;
using MorangosDaCidade.Repository;
using MorangosDaCidade.Service;
using MorangosDaCidade2.Controllers;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using System.Threading.Tasks;
using System.Text;

namespace MorangosDaCidade.Controllers
{
    class FuncionarioController : Controller
    {
        public static FuncionarioService funcionarioService = new FuncionarioService();

        public override async Task ExecutarAsync()
        {
            int opcao = -1;
            while (opcao != 0)
            {
                base.ExecutarAsync();
                ExibirTituloDaOpcao("MENU DE FUNCIONÁRIO");
                Console.WriteLine("1 - Cadastrar Novo Funcionário");
                Console.WriteLine("2 - Listar Funcionários");
                Console.WriteLine("3 - Editar Registro de Funcionário");
                Console.WriteLine("4 - Deletar Funcionário");
                Console.WriteLine("0 - Voltar");
                Console.Write("Esvolha uma opção: ");
                string opDigitada = Console.ReadLine();
                opcao = int.Parse(opDigitada);

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        CadastrarFuncionario();
                        break;
                    case 2:
                        Console.Clear();
                        ListarFuncionarios();
                        Console.WriteLine("Digite qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        EditarFuncionarioAsync();
                        break;
                    case 4:
                        Console.Clear();
                        DeletarFuncionario();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                }

            }
        }

        public static string LerSenhaEscondida()
        {
            var senha = new StringBuilder();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key != ConsoleKey.Enter)
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && senha.Length > 0)
                    {
                        // Apaga o último caractere se o usuário pressionar Backspace
                        Console.Write("\b \b");
                        senha.Remove(senha.Length - 1, 1);
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        // Adiciona o caractere à senha e exibe um asterisco (*) no console
                        Console.Write("*");
                        senha.Append(keyInfo.KeyChar);
                    }
                }
            } while (keyInfo.Key != ConsoleKey.Enter);

            return senha.ToString();
        }

        public async void CadastrarFuncionario()
        {
            ExibirTituloDaOpcao("CADASTRO DE FUNCIONÁRIO");
            Console.Write("Insira o nome do funcionário: ");
            String nome = Console.ReadLine();
            Console.Write("Insira o cpf do funcionário: ");
            String cpf = Console.ReadLine();
            Console.Write("Insira o e-mail do funcionário: ");
            String email = Console.ReadLine();
            Console.Write("Insira o telefone do funcionário: ");
            String telefone = Console.ReadLine();
            Console.Write("Insira a data de nascimento: ");
            String dtNascimento = Console.ReadLine();
            SqlDateTime dtConvertida = DateTime.Parse(dtNascimento);
            Console.Write("Insira uma senha: ");
            String senha1 = LerSenhaEscondida();
            Console.WriteLine(" ");
            String senha2 = null;
            while (!senha1.Equals(senha2))
            {
                Console.Write("Insira a senha novamente: ");
                senha2 = LerSenhaEscondida();
                Console.WriteLine(" ");
            }
            Funcionario funcionario = new Funcionario(nome, cpf, email, telefone, dtConvertida, senha1);

            if (await funcionarioService.SalvarFuncionarioAsync(funcionario))
            {
                string dataFormat = funcionario.DataNascimento.ToString().Replace("00:00:00", "");
                Console.WriteLine("\nSucesso! Novo funcionário Cadastrado:");
                Console.WriteLine($"Nome: {funcionario.Nome}");
                Console.WriteLine($"email: {funcionario.Email}");
                Console.WriteLine($"CPF: {funcionario.Cpf}");
                Console.WriteLine($"telefone: {funcionario.Telefone}");
                Console.WriteLine($"Data de Nascimento: {dataFormat}");
                
            }
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public async void ListarFuncionarios()
        {
            ExibirTituloDaOpcao("LISTA DE FUNCIONÁRIOS");
            List<Funcionario> funcionarios = await funcionarioService.ListarFuncionariosAsync();

            if (funcionarios.Count > 0) {
                Console.WriteLine($"{"Id",-5} | {"Nome",-20} | {"e-mail",-30} | {"CPF",-15} | {"Telefone",-15} | {"Data Nasc.",-15}");
                Console.WriteLine(new string('-', 115));
                foreach (Funcionario f in funcionarios)
                {
                    string cpfFormat = $"{f.Cpf.Substring(0, 3)}.{f.Cpf.Substring(3, 3)}.{f.Cpf.Substring(6, 3)}-{f.Cpf.Substring(9, 2)}";
                    string telefoneFormat = $"({f.Telefone.Substring(0, 2)}) {f.Telefone.Substring(2, 5)}-{f.Telefone.Substring(7, 4)}";
                    string dtFormat = f.DataNascimento.ToString().Replace("00:00:00", "");
                    Console.WriteLine($"{f.Id,-5} | {f.Nome.ToUpper(),-20} | {f.Email,-30} | {cpfFormat,-15} " +
                        $"| {telefoneFormat,-15} | {dtFormat,-15}");
                }
            }
            else Console.WriteLine("Não Há registros para serem mostrados.");
            
        }

        public void ListarFuncionariosPorNome(string nome)
        { 
            List<Funcionario> funcionarios = funcionarioService.ListarFuncionariosPorNome(nome);

            if (funcionarios.Count > 0)
            {
                ExibirTituloDaOpcao("LISTA DE FUNCIONÁRIOS");
                Console.WriteLine($"{"Id",-5} | {"Nome",-20} | {"e-mail",-30} | {"CPF",-15} | {"Telefone",-15} " +
                    $"| {"Data Nasc.",-15}");
                foreach (Funcionario f in funcionarios)
                {
                    string cpfFormat = $"{f.Cpf.Substring(0, 3)}.{f.Cpf.Substring(3, 3)}.{f.Cpf.Substring(6, 3)}-{f.Cpf.Substring(9, 2)}";
                    string telefoneFormat = $"({f.Telefone.Substring(0, 2)}) {f.Telefone.Substring(2, 5)}-{f.Telefone.Substring(7, 4)}";
                    string dtFormat = f.DataNascimento.ToString().Replace("00:00:00", "");
                    Console.WriteLine($"{f.Id,-5} | {f.Nome.ToUpper(),-20} | {f.Email,-30} | {cpfFormat,-15} " +
                                           $"| {telefoneFormat,-15} | {dtFormat,-15}");
                }
            }
            else
            {
                Console.WriteLine("Não Há registros para serem mostrados.");
            }
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public async Task EditarFuncionarioAsync()
        {
            ExibirTituloDaOpcao("EDITAR FUNCIONÁRIO");
            Console.WriteLine("Como prefere buscar o funcionário desejado?");
            Console.WriteLine("1 - Buscar por Nome");
            Console.WriteLine("2 - Buscar na Lista");
            Console.Write("Escolha uma opção: ");
            int opcao = int.Parse(Console.ReadLine());
            while (opcao != 1 && opcao != 2)
            {
                Console.WriteLine("Opção inválida");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite o nome: ");
                    string nome = Console.ReadLine();
                    ListarFuncionariosPorNome(nome);
                    break;

                case 2:
                    ListarFuncionarios();
                    break;
            }

            Console.Write("\nDigite o Id do funcionário: ");
            int id = int.Parse(Console.ReadLine());
            Funcionario funcionario = await funcionarioService.BuscarFuncionarioPorIdAsync(id);
            if (funcionario != null)
            {
                Console.Write("Insira o nome do funcionário: ");
                String nomeDigitado = Console.ReadLine();
                Console.Write("Insira o cpf do funcionário: ");
                String cpf = Console.ReadLine();
                Console.Write("Insira o e-mail do funcionário: ");
                String email = Console.ReadLine();
                Console.Write("Insira o telefone do funcionário: ");
                String telefone = Console.ReadLine();
                Console.Write("Insira a data de nascimento: ");
                String dtNascimento = Console.ReadLine();
                SqlDateTime dtConvertida = DateTime.Parse(dtNascimento);
                Console.Write("Insira uma senha: ");
                String senha1 = Console.ReadLine();
                String senha2 = null;
                
                while (!senha1.Equals(senha2))
                {
                    Console.Write("Insira a senha novamente: ");
                    senha2 = Console.ReadLine();
                }

                funcionario = new Funcionario(id, nomeDigitado, cpf, email, telefone, dtConvertida, senha1);

                if (await funcionarioService.AtualizarFuncionarioAsync(funcionario))
                {
                    string dataFormat = funcionario.DataNascimento.ToString().Replace("00:00:00", "");
                    Console.WriteLine("\nSucesso! Novo funcionário Cadastrado:");
                    Console.WriteLine($"Nome: {funcionario.Nome}");
                    Console.WriteLine($"email: {funcionario.Email}");
                    Console.WriteLine($"CPF: {funcionario.Cpf}");
                    Console.WriteLine($"telefone: {funcionario.Telefone}");
                    Console.WriteLine($"Data de Nascimento: {dataFormat}");

                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Não há nenhum funcionário com o id especificado.");
                Console.ReadKey();
            }
        }

        public async void DeletarFuncionario()
        {
            ExibirTituloDaOpcao("DELETAR USUÁRIO");
            Console.WriteLine("Como prefere buscar o funcionário desejado?");
            Console.WriteLine("1 - Buscar por Nome");
            Console.WriteLine("2 - Buscar na Lista");
            Console.Write("Escolha uma opção: ");
            int opcao = int.Parse(Console.ReadLine());
            while (opcao != 1 && opcao != 2)
            {
                Console.WriteLine("Opção inválida");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite o nome: ");
                    string nome = Console.ReadLine();
                    ListarFuncionariosPorNome(nome);
                    break;

                case 2:
                    ListarFuncionarios();
                    break;
            }

            Console.Write("\nDigite o Id do funcionário: ");
            int id = int.Parse(Console.ReadLine());
            Funcionario funcionario = await funcionarioService.BuscarFuncionarioPorIdAsync(id);
            if (funcionario != null)
            {
                if (funcionarioService.DeletarFuncionario(id))
                {
                    Console.WriteLine("Funcionário deletado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Houve um erro na deleção do funcionário.");
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Não há nenhum funcionário com o id especificado.");
                Console.ReadKey();
            }
        }
    }
}