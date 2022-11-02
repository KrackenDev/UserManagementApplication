using System;
using System.Threading.Tasks;
using UserManagement.Api.Controllers.Actions.Interfaces;
using UserManagement.Infrastructure.Models;
using UserManagement.Infrastructure.Repositories.Interfaces;

namespace UserManagement.Api.Controllers.Actions
{
    public class UserManagementActions : IUserManagementActions
    {
        private readonly IUserManagementRepository _userManagementRepo;

        public UserManagementActions(IUserManagementRepository repository)
        {
            _userManagementRepo = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        
        public async Task<User[]> GetUsers() => await _userManagementRepo.GetUsers();
        public async Task<User> GetUser(int id) => await _userManagementRepo.GetUser(id);
        public async Task DeleteUser(int id) => await _userManagementRepo.DeleteUser(id);
        public async Task CreateUser(User user) => await _userManagementRepo.CreateUser(user);
        public Task UpdateUser(User user) => _userManagementRepo.UpdateUser(user);
    }
}