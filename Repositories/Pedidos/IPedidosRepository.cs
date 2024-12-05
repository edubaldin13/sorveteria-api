using System.Net;
using Sorveteria.DTO.Requests;
using Sorveteria.DTO.Responses;

namespace Sorveteria.Repositories.Pedidos
{
    public interface IPedidosRepository
    {
        public Task<List<GetPedidosResponse>> GetPedidos();  
        public Task<HttpStatusCode> AdicionarPedidos(PedidosPostRequest pedido);
        public Task<HttpStatusCode> ExcluirPedido(int pedidoId);
    }
}
