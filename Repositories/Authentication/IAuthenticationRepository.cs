using Sorveteria.DTO.Requests;
using Sorveteria.DTO.Responses;

namespace Sorveteria.Repositórios.Authentication
{
    public interface IAuthenticationRepository
    {
        public Task<AuthenticationPostResponse> Authenticate(AuthenticationPostRequest request);
    }
}
