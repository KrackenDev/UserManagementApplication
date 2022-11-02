using System.Threading.Tasks;
using UserManagement.Infrastructure.Models;

namespace UserManagement.Infrastructure.Repositories.Interfaces
{
    public interface IUserManagementRepository
    {
       Task<User[]> GetUsers();
       Task<User> GetUser(int id);
    }
}