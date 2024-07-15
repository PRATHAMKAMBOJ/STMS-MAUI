using STMSApi.Models;

namespace STMSApi.Interfaces
{
    public interface IJwtAuthService
    {
        TokenResponse GenerateToken(string userId);
    }
}
