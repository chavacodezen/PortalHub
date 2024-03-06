using Microsoft.EntityFrameworkCore;
using PortalHub.Models;
using PortalHub.Services.Contract;

namespace PortalHub.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly DevTestDbContext _dbContext;
        public UserService(DevTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUser(string email, string password)
        {
            User user_found = await _dbContext.Users.Where(u => u.Email == email && u.PasswordHash == password).FirstOrDefaultAsync();

            return user_found;
        }
        public async Task<User> SaveUser(User model)
        {
            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();

            return model;

        }
    }
}
