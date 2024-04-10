using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PortalHub.Models;
using PortalHub.Services.Contract;
using System.Security.Claims;

namespace PortalHub.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly PortalDbContext _dbContext;
        public UserService(PortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUser(int employeeNo, string password)
        {
            User user_found = await _dbContext.Users.Where(u => u.EmployeeNo == employeeNo && u.PasswordHash == password).FirstOrDefaultAsync();

            return user_found;
        }
        public async Task<User> SaveUser(User model)
        {
            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();

            return model;

        }

        public async Task<bool> UserExists(int employeeNo)
        {
            return await _dbContext.Users.AnyAsync(u => u.EmployeeNo == employeeNo);
        }

        public async Task<ClaimsPrincipal> CreateClaimsPrincipalAsync(User model)
        {
            var claims = new List<Claim>
            {
                new Claim("FirstName", model.FirstName ?? ""),
                new Claim("LastName", model.LastName ?? ""),
                new Claim("EmployeeNo", model.EmployeeNo.ToString()),
                new Claim("IdDepartment", model.IdDepartment.ToString() ?? ""),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return await Task.FromResult(new ClaimsPrincipal(identity));
        }
    }
}
