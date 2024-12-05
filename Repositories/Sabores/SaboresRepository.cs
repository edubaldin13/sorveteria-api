using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sorveteria.DTO;
using Sorveteria.DTO.Requests;
using Sorveteria.DTO.Responses;
using System.Net;
using static Sorveteria.Contexts.ApplicationContext;

namespace Sorveteria.Repositories.Sabores
{
    public class SaboresRepository : ISaboresRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public SaboresRepository(ApplicationDbContext context
                                , IMapper mapper
                                , IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<HttpStatusCode> AlterarSabor(SaborPatchRequest sabor)
        //{
        //    try
        //    {
        //        await _context.Sabores.Update(sabor);
        //        await _context.SaveChangesAsync();
        //    }catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return HttpStatusCode.OK;
        //}

        public async Task<List<GetSaboresResponse>> GetSabores()
        {
            var record = await _context.Sabores.ToListAsync();
            var result = _mapper.Map<List<GetSaboresResponse>>(record);
            return result;
        }

        public async Task<int> SaveSabores(SaboresPostRequest sabor)
        {
            try
            {
                var record = new Sabor
                {
                    Nome = sabor.Nome,
                    ValorBola = sabor.ValorBola 
                };
                await _context.AddAsync(record);
                await _context.SaveChangesAsync();
                return record.Id;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
