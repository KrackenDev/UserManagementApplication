using System.Threading.Tasks;
using UserManagement.Infrastructure.Models;

namespace UserManagement.Api.Controllers.Actions.Interfaces
{
    public interface IUserManagementActions 
    {
        Task<User[]> GetUsers();
        Task<User> GetUser(int id);
        Task DeleteUser(int userId);
        Task CreateUser(User user);
        Task UpdateUser(User user);
    }
}