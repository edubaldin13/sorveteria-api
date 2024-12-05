using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Sorveteria.DTO;
using Sorveteria.DTO.Requests;
using Sorveteria.DTO.Responses;
using Sorveteria.Repositories.Pedidos;
using static Sorveteria.Contexts.ApplicationContext;

namespace Sorveteria.Repositories.Pedidos
{
    public class PedidosRepository : IPedidosRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public PedidosRepository( ApplicationDbContext context
                                , IMapper mapper
                                , IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetPedidosResponse>> GetPedidos()
        {
            var retorno = new List<GetPedidosResponse>();
            try
            {
                var record = await _context.Pedidos.Where(p => p.Ativo.Equals(true)).Include(p => p.Sabor1).Include(p => p.Sabor2).ToListAsync();
                
            retorno = _mapper.Map<List<GetPedidosResponse>>(record);
            } catch (Exception ex)
            {

            }
            return retorno;
        }
        public async Task<HttpStatusCode> AdicionarPedidos(PedidosPostRequest pedido)
        {
            try
            {
                var record = _mapper.Map<Pedido>(pedido);
                record.Ativo = true;
                var result = await _context.Pedidos.AddAsync(record);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            } catch (Exception e)
            {
                throw;
            }
        }

        public async Task<HttpStatusCode> ExcluirPedido(int pedidoId)
        {
            try
            {
                var record = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == pedidoId);
                if(record is null){
                    return HttpStatusCode.NotFound;
                }
                record.Ativo = false;
                _context.Pedidos.Update(record);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return HttpStatusCode.OK;
        }
    }
}
