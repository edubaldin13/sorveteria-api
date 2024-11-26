namespace Sorveteria.DTO.Requests
{
    public class AuthenticationPostRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
