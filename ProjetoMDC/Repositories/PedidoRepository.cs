using MorangosDaCidade.Service;
using MorangosDaCidade2.Entities;
using MorangosDaCidade2.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MorangosDaCidade2.repositories
{
    internal class PedidoRepository
    {
        string stringDeConexao = @"Data Source=LAPTOP-V1LI7TEI;Initial Catalog=MorangosDaCidade;Integrated Security=True";

        public ClienteService clienteService = new ClienteService();
        public ProdutoService produtoService = new ProdutoService();
        public async Task<int> SalvarPedidoAsync(Pedido pedido)
        {
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO dbo.PEDIDO (IdCliente, DataPedido, StatusPedido) " +
                            "OUTPUT INSERTED.IdPedido VALUES (@ClienteId, GETDATE(), @StatusPedido)";

                        command.Parameters.AddWithValue("@ClienteId", pedido.Cliente.Id);
                        command.Parameters.AddWithValue("@StatusPedido", pedido.StatusPedido);

                        int idPedido = (int)await command.ExecuteScalarAsync();
                        return idPedido;
                    }
                    catch (SqlException ex){ Console.WriteLine(ex.Message); }
                    catch (InvalidCastException ex) { Console.WriteLine(ex.Message); }
                    catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
                    catch (System.IO.IOException ex) { Console.WriteLine(ex.Message); }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                }
                return 0;
            }
        }

        public async Task<int> SalvarItemPedidoAsync(ItemPedido item, int idPedido)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                await connection.OpenAsync();

                // Inicia uma transação
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        try
                        {
                            command.Connection = connection;
                            command.Transaction = transaction;

                            // Insere o item na tabela Pedido_Produto
                            command.CommandText = "INSERT INTO dbo.PEDIDO_PRODUTO (IdPedido, IdProduto, Quantidade)" +
                                " VALUES (@IdPedido, @IdProduto, @Quantidade)";
                            command.Parameters.AddWithValue("@IdProduto", item.Produto.Id);
                            command.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                            command.Parameters.AddWithValue("@IdPedido", idPedido);
                            result = await command.ExecuteNonQueryAsync();

                            // Atualiza a quantidade do produto na tabela Produtos
                            command.CommandText = "UPDATE dbo.PRODUTO SET Quantidade = Quantidade - @quantidade " +
                                "WHERE IdProduto = @id";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@quantidade", item.Quantidade);
                            command.Parameters.AddWithValue("@id", item.Produto.Id);
                            await command.ExecuteNonQueryAsync();

                            // Se tudo ocorreu bem, confirma a transação
                            transaction.Commit();
                        }
                        catch
                        {
                            // Se algo deu errado, desfaz a transação
                            transaction.Rollback();
                            throw;  // relança a exceção
                        }
                    }
                }
            }
            return result;
        }


        public async Task<List<Pedido>> ListarPedidosAsync()
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.PEDIDO", connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int clienteId = Convert.ToInt32(reader["IdCliente"]);
                            Pedido pedido = new Pedido
                            {
                                Id = Convert.ToInt32(reader["IdPedido"]),
                                Cliente = await clienteService.BuscarClientePorIdAsync(clienteId),
                                DataPedido = Convert.ToDateTime(reader["DataPedido"]),
                                StatusPedido = (Status)Enum.Parse(typeof(Status), reader["StatusPedido"].ToString()),
                                Itens = await ListarItensPedidoAsync(Convert.ToInt32(reader["IdPedido"]))
                            };

                            pedidos.Add(pedido);
                        }
                    }
                }
            }

            return pedidos;
        }

        public async Task<List<ItemPedido>> ListarItensPedidoAsync(int idPedido)
        {
            List<ItemPedido> itens = new List<ItemPedido>();

            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.PEDIDO_PRODUTO WHERE" +
                    " IdPedido = @IdPedido", connection))
                {
                    command.Parameters.AddWithValue("@IdPedido", idPedido);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ItemPedido item = new ItemPedido
                            {
                                Produto = await produtoService.BuscarProdutoPorIdAsync(Convert.ToInt32(reader["IdProduto"])),
                                Quantidade = Convert.ToInt32(reader["Quantidade"]),
                            };

                            itens.Add(item);
                        }
                    }
                }
            }

            return itens;
        }

        public async Task<Pedido> BuscarPedidoPorIdAsync(int id)
        {
            Pedido pedido = null;

            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.PEDIDO WHERE IdPedido = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            int clienteId = Convert.ToInt32(reader["IdCliente"]);
                            pedido = new Pedido
                            {
                                Id = Convert.ToInt32(reader["IdPedido"]),
                                Cliente = await clienteService.BuscarClientePorIdAsync(clienteId),
                                DataPedido = Convert.ToDateTime(reader["DataPedido"]),
                                StatusPedido = (Status)Enum.Parse(typeof(Status), reader["StatusPedido"].ToString()),
                                Itens = await ListarItensPedidoAsync(Convert.ToInt32(reader["IdPedido"]))
                            };
                        }
                    }
                }
            }

            return pedido;
        }

        public async Task<int> AtualizarStatusPedidoAsync(int id, Status novoStatus)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                try
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("UPDATE dbo.PEDIDO SET StatusPedido = @status WHERE IdPedido = @id", connection))
                    {
                        command.Parameters.AddWithValue("@status", novoStatus.ToString());
                        command.Parameters.AddWithValue("@id", id);

                        result = await command.ExecuteNonQueryAsync();
                    }
                }
                catch (SqlException ex) { await Console.Out.WriteLineAsync("Erro: " + ex.Message); }
            }
            return result;
        }

        public async Task<int> DeletarPedidoPorIdAsync(int id)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(stringDeConexao))
            {
                try
                {
                    await connection.OpenAsync();

                    // Primeiro, deleta os registros da tabela PEDIDO_PRODUTO
                    using (SqlCommand command = new SqlCommand("DELETE FROM dbo.PEDIDO_PRODUTO WHERE IdPedido = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        result = await command.ExecuteNonQueryAsync();
                    }

                    // Depois, deleta o registro da tabela PEDIDO
                    using (SqlCommand command = new SqlCommand("DELETE FROM dbo.PEDIDO WHERE IdPedido = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        result += await command.ExecuteNonQueryAsync();
                    }
                }
                catch (SqlException ex) { await Console.Out.WriteLineAsync("Erro: " + ex.Message); }

            }
            return result;
        }


    }
}
