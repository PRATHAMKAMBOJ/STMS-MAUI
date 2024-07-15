using STMS.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMS.Interfaces
{
    public interface IAuthService
    {
        Task<JwtTokenResponse> Login(string Username,string Password);
        Task<string> GetJwtToken();
        void Logout();
    }
}
