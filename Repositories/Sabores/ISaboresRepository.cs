using Sorveteria.DTO.Requests;
using Sorveteria.DTO.Responses;

namespace Sorveteria.Repositories.Sabores
{
    public interface ISaboresRepository
    {
        public Task<List<GetSaboresResponse>> GetSabores();
        public Task<int> SaveSabores(SaboresPostRequest sabor);
    }
}
