using Newtonsoft.Json;
using STMS.Interfaces;
using STMS.MVVM.Models;

namespace STMS.Services
{
    public class AuthService : IAuthService
    {
        public string baseUrl = $"https://e694-112-196-9-90.ngrok-free.app/api/";
        private readonly string JwtTokenKey = "JwtToken";
        public async Task<JwtTokenResponse> Login(string Username,string Password)
        {
            
            using (var _client = new HttpClient())
            {
                var response = await _client.GetAsync(baseUrl + $"Login?email={Username}&password={Password}");
                if(response.IsSuccessStatusCode)
                {
                    var httpResponse = await response.Content.ReadAsStringAsync();
                    var deserializedResponse = JsonConvert.DeserializeObject<JwtTokenResponse>(httpResponse);
                    await SecureStorage.SetAsync(JwtTokenKey, deserializedResponse.Token);
                    return deserializedResponse;
                }
                return null;
            }   
        }
        public void Logout()
        {
            SecureStorage.Remove(JwtTokenKey);
        }
        public async Task<string> GetJwtToken()
        {
            var jwtToken = await SecureStorage.GetAsync(JwtTokenKey);
            if(jwtToken!=null)
            {
                return jwtToken;
            }
            return null;
        }
    }
}
