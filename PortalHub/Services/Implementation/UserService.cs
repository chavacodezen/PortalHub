using Microsoft.EntityFrameworkCore;
using PortalHub.Models;
using PortalHub.Services.Contract;

namespace PortalHub.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly PortalDbContext _dbContext;
        public UserService(PortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUser(string badge, string password)
        {
            User user_found = await _dbContext.Users.Where(u => u.Badge == badge && u.PasswordHash == password).FirstOrDefaultAsync();

            return user_found;
        }
        public async Task<User> SaveUser(User model)
        {
            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();

            return model;

        }

        public async Task<bool> UserExists(string badge)
        {
            return await _dbContext.Users.AnyAsync(u => u.Badge == badge);
        }
    }
}
