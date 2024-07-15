using Microsoft.EntityFrameworkCore;
using STMSApi.Interfaces;
using STMSApi.Models;

namespace STMSApi.Repositories
{
    public class UserReposiotry : IUserRepository
    {
        public DatabaseContext _dbContext;
        public UserReposiotry(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserByPass(string email, string password)
        {
            var result =  await _dbContext.Users.Where(user =>  user.Email == email && user.Password == password).FirstOrDefaultAsync();
            if(result!=null)
            {
                return result;
            }
            return null;
        }

        public async Task<bool> SignUp(User newUserDetails)
        {
            var result = await _dbContext.Users.AddAsync(newUserDetails);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
