using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MorangosDaCidade.Entities;

namespace MorangosDaCidade.Repository
{
    class AdministradorRepository
    {
        string stringDeConexao = @"Data Source=LAPTOP-V1LI7TEI;Initial Catalog=MorangosDaCidade;Integrated Security=True;";

        public int CadastrarAdministrador(Administrador a)
        {
            int resultado = 0;

            string consulta = "INSERT INTO dbo.ADMINISTRADOR (NOME,CPF,TELEFONE," +
                "EMAIL,DataNascimento,SENHA)" +
                " VALUES (@NOME, @CPF, @TELEFONE, @EMAIL, @DataNascimento, @SENHA)";

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                SqlCommand comando = new SqlCommand(consulta, conexao);
                comando.Parameters.AddWithValue("@NOME", a.Nome);
                comando.Parameters.AddWithValue("@CPF", a.Cpf);
                comando.Parameters.AddWithValue("@TELEFONE", a.Telefone);
                comando.Parameters.AddWithValue("@EMAIL", a.Email);
                comando.Parameters.AddWithValue("@DataNascimento", a.DataNascimento);
                comando.Parameters.AddWithValue("@SENHA", a.Senha);

                try
                {
                    conexao.Open();

                    resultado = comando.ExecuteNonQuery();
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

        public List<Administrador> ListarAdministradores()
        {
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT IdAdmin, NOME, CPF, EMAIL, TELEFONE, DataNascimento FROM dbo.ADMINISTRADOR";
                    SqlCommand comando = new SqlCommand(query, connection);
                    List<Administrador> administradores = new List<Administrador>();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Administrador a = new Administrador();
                        a.Id = (int)reader["IdAdmin"];
                        a.Nome = (string)reader["NOME"];
                        a.Cpf = (string)reader["CPF"];
                        a.Email = (string)reader["EMAIL"];
                        a.Telefone = (string)reader["TELEFONE"];
                        SqlDateTime dtNascimento = reader.GetDateTime(reader.GetOrdinal("DataNascimento"));
                        a.DataNascimento = dtNascimento;
                        administradores.Add(a);
                    }
                    return administradores;
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

        public async Task<Administrador> BuscarAdministradorPorEmailSenhaAsync(string email, string senha)
        {
            Administrador administrador = null;

            string consulta = "SELECT * FROM dbo.ADMINISTRADOR WHERE EMAIL = @EMAIL AND SENHA = @SENHA";

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
                            administrador = new Administrador
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
            return administrador;
        }


    }



}
