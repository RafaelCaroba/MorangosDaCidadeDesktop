using MorangosDaCidade.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorangosDaCidade.Repository
{
    class FuncionarioRepository
    {
        string stringDeConexao = @"Data Source=LAPTOP-V1LI7TEI;Initial Catalog=MorangosDaCidade;Integrated Security=True";
        public async Task<int> CadastrarFuncionarioAsync(Funcionario f)
        {
            int resultado = 0;

            string consulta = "INSERT INTO dbo.FUNCIONARIO (NOME, CPF, TELEFONE, EMAIL, DataNascimento, SENHA)" +
                              " VALUES (@NOME, @CPF, @TELEFONE, @EMAIL, @DataNascimento, @SENHA)";

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                SqlCommand comando = new SqlCommand(consulta, conexao);
                comando.Parameters.AddWithValue("@NOME", f.Nome);
                comando.Parameters.AddWithValue("@CPF", f.Cpf.Replace(".", "").Replace("-", "").Replace(",", ""));
                comando.Parameters.AddWithValue("@TELEFONE", f.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""));
                comando.Parameters.AddWithValue("@EMAIL", f.Email);
                comando.Parameters.AddWithValue("@DataNascimento", f.DataNascimento);
                comando.Parameters.AddWithValue("@SENHA", f.Senha);

                try
                {
                    await conexao.OpenAsync();
                    resultado = await comando.ExecuteNonQueryAsync();
                    Console.WriteLine("Número de linhas afetadas: " + resultado);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Erro de SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            return resultado;
        }


        public async Task<List<Funcionario>> ListarFuncionariosAsync()
        {
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                try
                {
                    await connection.OpenAsync();
                    string query = "SELECT IdFunc, NOME, CPF, EMAIL, TELEFONE, DataNascimento FROM dbo.FUNCIONARIO";
                    SqlCommand comando = new SqlCommand(query, connection);
                    List<Funcionario> funcionarios = new List<Funcionario>();
                    SqlDataReader reader = await comando.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        Funcionario f = new Funcionario();
                        f.Id = (int)reader["IdFunc"];
                        f.Nome = (string)reader["NOME"];
                        f.Cpf = (string)reader["CPF"];
                        f.Email = (string)reader["EMAIL"];
                        f.Telefone = (string)reader["TELEFONE"];
                        SqlDateTime dtNascimento = reader.GetDateTime(reader.GetOrdinal("DataNascimento"));
                        f.DataNascimento = dtNascimento;
                        funcionarios.Add(f);
                    }
                    return funcionarios;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Erro de SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            return null;
        }

        public List<Funcionario> BuscarFuncionarioPorNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT IdFunc, NOME, CPF, EMAIL, TELEFONE, DataNascimento FROM dbo.FUNCIONARIO" +
                        " WHERE NOME LIKE @Nome";
                    SqlCommand comando = new SqlCommand(query, connection);
                    comando.Parameters.AddWithValue("@Nome", $"%{nome}%");
                    List<Funcionario> funcionarios = new List<Funcionario>();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Funcionario f = new Funcionario();
                        f.Id = (int)reader["IdFunc"];
                        f.Nome = (string)reader["NOME"];
                        f.Cpf = (string)reader["CPF"];
                        f.Email = (string)reader["EMAIL"];
                        f.Telefone = (string)reader["TELEFONE"];
                        SqlDateTime dtNascimento = reader.GetDateTime(reader.GetOrdinal("DataNascimento"));
                        funcionarios.Add(f);
                    }
                    return funcionarios;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Erro de SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            return null;
        }

        public async Task<Funcionario> BuscarFuncionarioPorIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                try
                {
                    await connection.OpenAsync();
                    string query = "SELECT IdFunc, NOME, CPF, EMAIL, TELEFONE, DataNascimento FROM dbo.FUNCIONARIO WHERE IdFunc = @Id";
                    SqlCommand comando = new SqlCommand(query, connection);
                    comando.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = await comando.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        Funcionario f = new Funcionario
                        {
                            Id = (int)reader["IdFunc"],
                            Nome = (string)reader["NOME"],
                            Cpf = (string)reader["CPF"],
                            Email = (string)reader["EMAIL"],
                            Telefone = (string)reader["TELEFONE"],
                            DataNascimento = reader["DataNascimento"] != DBNull.Value ? new SqlDateTime((DateTime)reader["DataNascimento"]) : SqlDateTime.Null
                        };
                        return f;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Erro de SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            return null;
        }

        public async Task<int> AtualizarFuncionarioAsync(Funcionario funcionario)
        {
            Console.WriteLine(funcionario.Id);
            int resultado = 0;
            string query = "UPDATE dbo.FUNCIONARIO SET Nome = @NovoNome, CPF = @NovoCPF, " +
                           "Email = @NovoEmail, Telefone = @NovoTelefone, DataNascimento = @NovaDataNascimento, Senha = @NovaSenha WHERE IdFunc = @Id";

            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", funcionario.Id);
                command.Parameters.AddWithValue("@NovoNome", funcionario.Nome);
                command.Parameters.AddWithValue("@NovoCPF", funcionario.Cpf.Replace(".", "").Replace("-", "").Replace(",", ""));
                command.Parameters.AddWithValue("@NovoTelefone", funcionario.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""));
                command.Parameters.AddWithValue("@NovoEmail", funcionario.Email);
                command.Parameters.AddWithValue("@NovaDataNascimento", funcionario.DataNascimento);
                command.Parameters.AddWithValue("@NovaSenha", funcionario.Senha);

                try
                {
                    await connection.OpenAsync();
                    resultado = await command.ExecuteNonQueryAsync();
                    Console.WriteLine("Número de linhas afetadas: " + resultado);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Erro de SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            return resultado;
        }


        public int DeletarFuncionario(int id)
        {
            int resultado = 0;
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM dbo.FUNCIONARIO WHERE IdFunc = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    resultado = command.ExecuteNonQuery();
                    Console.WriteLine("Número de linhas afetadas: " + resultado);
                }
                catch (SqlException ex) { Console.WriteLine($"Erro de SQL: {ex.Message}"); }
                catch (Exception ex) { Console.WriteLine($"Erro: {ex.Message}"); }
            }
            return resultado;
        }

        public async Task<Funcionario> BuscarFuncionarioPorEmailSenhaAsync(string email, string senha)
        {
            Funcionario funcionario = null;

            string consulta = "SELECT * FROM dbo.FUNCIONARIO WHERE EMAIL = @EMAIL AND SENHA = @SENHA";

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                SqlCommand comando = new SqlCommand(consulta, conexao);
                comando.Parameters.AddWithValue("@EMAIL", email);
                comando.Parameters.AddWithValue("@SENHA", senha);

                try
                {
                    conexao.Open();

                    using (SqlDataReader reader = await comando.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            funcionario = new Funcionario
                            {
                                Nome = reader["NOME"].ToString(),
                                Cpf = reader["CPF"].ToString(),
                                Telefone = reader["TELEFONE"].ToString(),
                                Email = reader["EMAIL"].ToString(),
                                DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString()),
                                Senha = reader["SENHA"].ToString()
                            };
                        }
                    }
                }
                catch (SqlException ex) { Console.WriteLine("Erro de SQL: " + ex.Message); }

                catch (Exception ex) { Console.WriteLine("Erro: " + ex.Message); }

                finally
                {
                    // Garantindo que a conexão seja fechada
                    conexao.Close();
                }
            }
            return funcionario;
        }
    }
}