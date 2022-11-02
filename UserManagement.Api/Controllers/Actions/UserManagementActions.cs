using System.Threading.Tasks;
using UserManagement.Api.Controllers.Actions.Interfaces;
using UserManagement.Infrastructure.Models;

namespace UserManagement.Api.Controllers.Actions
{
    public class UserManagementActions : IUserManagementActions
    {
        public Task<User> GetUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}