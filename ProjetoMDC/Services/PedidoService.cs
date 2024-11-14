using MorangosDaCidade.Service;
using MorangosDaCidade2.Entities;
using MorangosDaCidade2.repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MorangosDaCidade2.services
{
    internal class PedidoService
    {
        public PedidoRepository pedidoRepository = new PedidoRepository();

        public async Task<int> SalvarPedidoAsync(Pedido p)
        {
            return await pedidoRepository.SalvarPedidoAsync(p);
        }

        public async Task<bool> SalvarItemPedidoAsync(ItemPedido item, int idPedido)
        {
            if (await pedidoRepository.SalvarItemPedidoAsync(item, idPedido) > 0) return true;
            else return false;
        }

        public async Task<List<Pedido>> ListarPedidosAsync()
        {
            List<Pedido> pedidos = await pedidoRepository.ListarPedidosAsync();
            return pedidos;
        }

        public async Task<Pedido> BuscarPedidoPorIdAsync(int id)
        {
            Pedido pedido = await pedidoRepository.BuscarPedidoPorIdAsync(id);
            return pedido;
        }

        public async Task<bool> AtualizarStatusPedidoAsync(int id, Status status)
        {
            if(await pedidoRepository.AtualizarStatusPedidoAsync(id, status) > 0) return true;
            else return false;
        }

        public async Task<bool> DeletarPedidoPorIdAsync(int id)
        {
            if(await pedidoRepository.DeletarPedidoPorIdAsync(id) > 0) return true;
            else return false;
        }
    }
}
