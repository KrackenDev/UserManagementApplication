using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using UserManagement.Infrastructure.Models;

namespace UserManagement.Infrastructure.Repositories
{
    sealed class UserManagementRepository
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

        public Task<User[]> GetUsers()
        {
            return Task.FromResult(_mockUsers);
        }
    }
}