using Microsoft.EntityFrameworkCore;
using PortalHub.Models;
using System.Security.Claims;

namespace PortalHub.Services.Contract
{
    public interface IUserService
    {
        Task<User>GetUser(int employeeNo, string password);
        Task<User>SaveUser(User model);
        Task<bool>UserExists(int employeeNo);
        Task<ClaimsPrincipal>CreateClaimsPrincipalAsync(User model);
    }
}
