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

    class ClienteRepository
    {
        string stringDeConexao = @"Data Source=LAPTOP-V1LI7TEI;Initial Catalog=MorangosDaCidade;Integrated Security=True";
        public async Task<int> CadastrarClienteAsync(Cliente f)
        {
            int resultado = 0;

            string consulta = "INSERT INTO dbo.CLIENTE (NOME,CPF,TELEFONE," +
                "EMAIL,DataNascimento,SENHA, ENDERECO)" +
                " VALUES (@NOME, @CPF, @TELEFONE, @EMAIL, @DataNascimento, @SENHA, @ENDERECO)";

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                SqlCommand comando = new SqlCommand(consulta, conexao);
                comando.Parameters.AddWithValue("@NOME", f.Nome);
                comando.Parameters.AddWithValue("@CPF", f.Cpf);
                comando.Parameters.AddWithValue("@TELEFONE", f.Telefone);
                comando.Parameters.AddWithValue("@EMAIL", f.Email);
                comando.Parameters.AddWithValue("@DataNascimento", f.DataNascimento);
                comando.Parameters.AddWithValue("@SENHA", f.Senha);
                comando.Parameters.AddWithValue("@ENDERECO", f.Endereco);

                try
                {
                    await conexao.OpenAsync();

                    resultado = (int)await comando.ExecuteNonQueryAsync();
                    Console.WriteLine("Número de linhas afetadas: " + resultado);
                }
                catch (SqlException ex) { Console.WriteLine("Erro de SQL: " + ex.Message); }

                catch (Exception ex) { Console.WriteLine("Erro: " + ex.Message); }

                finally
                {
                    // Garantindo que a conexão seja fechada
                    conexao.Close();
                }
            }
            return resultado;
        }

        public async Task<List<Cliente>> ListarClientesAsync()
        {
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                try
                {
                    await connection.OpenAsync();
                    string query = "SELECT IdCli, NOME, CPF, EMAIL, TELEFONE, DataNascimento, ENDERECO FROM dbo.CLIENTE";
                    SqlCommand comando = new SqlCommand(query, connection);
                    List<Cliente> clientes = new List<Cliente>();
                    SqlDataReader reader = await comando.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        Cliente f = new Cliente();
                        f.Id = (int)reader["IdCli"];
                        f.Nome = (string)reader["NOME"];
                        f.Cpf = (string)reader["CPF"];
                        f.Email = (string)reader["EMAIL"];
                        f.Telefone = (string)reader["TELEFONE"];
                        SqlDateTime dtNascimento = reader.GetDateTime(reader.GetOrdinal("DataNascimento"));
                        f.DataNascimento = dtNascimento;
                        f.Endereco = (string)reader["ENDERECO"];
                        clientes.Add(f);
                    }
                    return clientes;
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

        public async Task<List<Cliente>> BuscarClientePorNomeAsync(string nome)
        {
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                try
                {
                    await connection.OpenAsync();
                    string query = "SELECT IdCli, NOME, CPF, EMAIL, TELEFONE, DataNascimento FROM dbo.CLIENTE" +
                        " WHERE NOME LIKE @Nome";
                    SqlCommand comando = new SqlCommand(query, connection);
                    comando.Parameters.AddWithValue("@Nome", $"%{nome}%");
                    List<Cliente> clientes = new List<Cliente>();
                    SqlDataReader reader = await comando.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        Cliente f = new Cliente();
                        f.Id = (int)reader["IdCli"];
                        f.Nome = (string)reader["NOME"];
                        f.Cpf = (string)reader["CPF"];
                        f.Email = (string)reader["EMAIL"];
                        f.Telefone = (string)reader["TELEFONE"];
                        SqlDateTime dtNascimento = reader.GetDateTime(reader.GetOrdinal("DataNascimento"));
                        f.DataNascimento = dtNascimento;
                        f.Endereco = (string)reader["ENDERECO"];
                        clientes.Add(f);
                    }
                    return clientes;
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

        public async Task<Cliente> BuscarClientePorIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                try
                {
                    await connection.OpenAsync();
                    string query = "SELECT IdCli, NOME, CPF, EMAIL, TELEFONE, DataNascimento, ENDERECO FROM dbo.CLIENTE" +
                        " WHERE IdCli = @Id";
                    SqlCommand comando = new SqlCommand(query, connection);
                    comando.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = await comando.ExecuteReaderAsync();
                    if (reader.Read())
                    {
                        Cliente f = new Cliente();
                        f.Id = (int)reader["IdCli"];
                        f.Nome = (string)reader["NOME"];
                        f.Cpf = (string)reader["CPF"];
                        f.Email = (string)reader["EMAIL"];
                        f.Telefone = (string)reader["TELEFONE"];
                        SqlDateTime dtNascimento = reader.GetDateTime(reader.GetOrdinal("DataNascimento"));
                        f.DataNascimento = dtNascimento;
                        f.Endereco = (string)reader["ENDERECO"];
                        connection.Close();
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
                connection.Close();
            }
            return null;
        }
        public int AtualizarCliente(Cliente cliente)
        {
            Console.WriteLine(cliente.Id);
            int resultado = 0;
            string query = "UPDATE dbo.CLIENTE SET NOME = @NovoNome, CPF = @NovoCPF, " +
                    "EMAIL = @NovoEmail, DataNascimento = @NovaDataNascimento, SENHA = @NovaSenha, ENDERECO = @NovoEndereco" +
                    " WHERE IdCli = @IdCli";

            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", cliente.Id);
                command.Parameters.AddWithValue("@NovoNome", cliente.Nome);
                command.Parameters.AddWithValue("@NovoCPF", cliente.Cpf);
                command.Parameters.AddWithValue("@NovoEmail", cliente.Email);
                command.Parameters.AddWithValue("@NovaDataNascimento", cliente.DataNascimento);
                command.Parameters.AddWithValue("@NovaSenha", cliente.Senha);

                try
                {
                    connection.Open();
                    resultado = command.ExecuteNonQuery();
                    Console.WriteLine("Número de linhas afetadas: " + resultado);
                }
                catch (SqlException ex) { Console.WriteLine("Erro de SQL: " + ex.Message); }

                catch (Exception ex) { Console.WriteLine("Erro: " + ex.Message); }

                finally
                {
                    connection.Close();
                }
            }
            return resultado;
        }

        public int DeletarCliente(int id)
        {
            int resultado = 0;
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM dbo.CLIENTE WHERE IdCli = @Id";
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

    }
}