using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using UserManagement.Infrastructure.Models;
using UserManagement.Infrastructure.Repositories.Interfaces;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserManagementRepository : IUserManagementRepository
    {
        private readonly User[] _mockUsers = new[]
        {
            new User()
            {
                FirstName = "Billy",
                LastName = "Bob",
                Email = "FakeEmail.com"
            }
        };
        
        public UserManagementRepository(IConfiguration configuration)
        {
            
        }

        public async Task<User[]> GetUsers()
        {
            return await Task.FromResult(_mockUsers);
        }
    }
}