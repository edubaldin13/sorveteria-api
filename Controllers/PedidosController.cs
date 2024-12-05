using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sorveteria.DTO.Requests;
using Sorveteria.DTO.Responses;
using Sorveteria.Repositories.Pedidos;

namespace Sorveteria.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly IPedidosRepository _pedidosRepository;
        public PedidosController(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        [HttpGet]
        public async Task<List<GetPedidosResponse>> ListarPedidos()
        {
            return await _pedidosRepository.GetPedidos();
        }
        [HttpPost]
        public async Task<HttpStatusCode> SalvarPedidos([FromBody] PedidosPostRequest pedido)
        {
            return await _pedidosRepository.AdicionarPedidos(pedido);
        }
        [HttpPatch("excluir/{pedidoId}")]
        public async Task<HttpStatusCode> ExcluirPedidos([FromRoute] int pedidoId)
        {
            return await _pedidosRepository.ExcluirPedido(pedidoId);
        }
    }
}
