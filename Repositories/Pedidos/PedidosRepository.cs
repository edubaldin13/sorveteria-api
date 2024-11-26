using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sorveteria.DTO.Responses;
using Sorveteria.Repositories.Pedidos;
using static Sorveteria.Contexts.ApplicationContext;

namespace Sorveteria.Repositories.Pedidos
{
    public class PedidosRepository : IPedidosRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public PedidosRepository(ApplicationDbContext context
                                , IMapper mapper
                                , IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetPedidosResponse>> GetPedidos()
        {
            var record = await _context.Pedidos.ToListAsync();
            var result = _mapper.Map<List<GetPedidosResponse>>(record);
            return result;
        }
    }
}
