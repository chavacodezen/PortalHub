using Microsoft.EntityFrameworkCore;
using PortalHub.Models;
 
namespace PortalHub.Services.Contract
{
    public interface IUserService
    {
        Task<User>GetUser(int employeeNo, string password);
        Task<User>SaveUser(User model);
        Task<bool>UserExists(int employeeNo);
    }
}
