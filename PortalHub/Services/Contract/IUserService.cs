using Microsoft.EntityFrameworkCore;
using PortalHub.Models;
 
namespace PortalHub.Services.Contract
{
    public interface IUserService
    {
        Task<User>GetUser(string email, string password);
        Task<User> SaveUser(User model);
    }
}
