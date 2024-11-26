using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sorveteria.DTO.Requests;
using Sorveteria.DTO.Responses;
using Sorveteria.Repositórios.Authentication;

namespace Sorveteria.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        [HttpPost("login")]
        public Task<AuthenticationPostResponse> Login([FromBody] AuthenticationPostRequest request)
        {
            return _authenticationRepository.Authenticate(request);
        }
    }
}
