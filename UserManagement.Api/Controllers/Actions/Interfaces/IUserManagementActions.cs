using System.Threading.Tasks;
using UserManagement.Infrastructure.Models;

namespace UserManagement.Api.Controllers.Actions.Interfaces
{
    public interface IUserManagementActions 
    {
        Task<User[]> GetUsers();
    }
}