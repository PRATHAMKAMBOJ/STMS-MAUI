using STMSApi.Models;

namespace STMSApi.Interfaces
{
    public interface IUserRepository 
    {
        public Task<User> GetUserByPass(string username, string password);
        public Task<bool> SignUp(User newUserDetails);
    }
}
