using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        
    }
}
