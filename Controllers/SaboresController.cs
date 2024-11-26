using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sorveteria.DTO.Requests;
using Sorveteria.DTO.Responses;
using Sorveteria.Repositories.Sabores;

namespace Sorveteria.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SaboresController : Controller
    {
        private readonly ISaboresRepository _saboresRepository;
        public SaboresController(ISaboresRepository saboresRepository)
        {
            _saboresRepository = saboresRepository;
        }

        [HttpGet]
        public async Task<List<GetSaboresResponse>> ListarSabores()
        {
            return await _saboresRepository.GetSabores();
        }
        [HttpPost]
        public async Task<int> SalvarSabor([FromBody] SaboresPostRequest saboresPostRequest)
        {
            return await _saboresRepository.SaveSabores(saboresPostRequest);
        }
        
    }
}
