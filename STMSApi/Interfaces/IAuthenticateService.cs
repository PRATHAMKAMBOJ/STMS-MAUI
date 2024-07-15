using STMSApi.Models;

namespace STMSApi.Interfaces
{
    public interface IAuthenticateService
    {
        public Task<TokenResponse> GetJwtToken(string username, string password);
        public Task<bool> CreateUser(SignUpRequest requestDetails);
    }
}
