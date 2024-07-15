using STMSApi.Interfaces;
using STMSApi.Models;
using System.Security.Cryptography;
using System.Text;

namespace STMSApi.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        public IUserRepository _userRepository;
        public IJwtAuthService _jwtAuthService;
        public AuthenticateService(IUserRepository userRepository,IJwtAuthService jwtAuthService)
        {
            _userRepository = userRepository;
            _jwtAuthService = jwtAuthService;
        }

        public async Task<bool> CreateUser(SignUpRequest requestDetails)
        {
            requestDetails.Password = EncryptPassword(requestDetails.Password);
            User newUser = new User()
            {
                Email = requestDetails.Email,
                Username = requestDetails.Username,
                Password = requestDetails.Password,
            };
            var user = await _userRepository.SignUp(newUser);
            if (user)
            {
                return true;
            }
            return false;
        }

        public async Task<TokenResponse> GetJwtToken(string email,string password)
        {
            var encryptPass = EncryptPassword(password);
            var user = await _userRepository.GetUserByPass(email, encryptPass);
            if(user != null)
            {
                TokenResponse token = _jwtAuthService.GenerateToken(user.UserId.ToString());
                token.User = user;
                return token;
            }
            return null;
        }
        private string EncryptPassword(string encryptPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute hash from the password bytes
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(encryptPassword));

                // Convert byte array to a string
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2")); 
                }
                return stringBuilder.ToString();
            }
        }
    }
}
