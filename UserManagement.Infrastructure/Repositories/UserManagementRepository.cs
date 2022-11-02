using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UserManagement.Infrastructure.DAL;
using UserManagement.Infrastructure.Models;
using UserManagement.Infrastructure.Repositories.Interfaces;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserManagementRepository : IUserManagementRepository
    {
        private readonly UserDbContext _context;
        private readonly ILogger<UserManagementRepository> _logger;

        public UserManagementRepository(UserDbContext context, ILogger<UserManagementRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<User[]> GetUsers()
        {
            try
            {
                return await _context.Users.ToArrayAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting users from database");
                throw;
            }
        }

        public Task<User> GetUser(int id)
        {
            try
            {
                return _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting user from database");
                throw;
            }
        }

        public async Task<int> DeleteUser(int id)
        {
            try
            {
                User userToDelete = _context.Users.FirstOrDefault(u => u.Id == id);
                if(userToDelete is null)
                    throw new Exception("User not found");
                
                _context.Users.Remove(userToDelete);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error deleting user from database");
                throw;
            }
        }

        public Task CreateUser(User user)
        {
            try
            {
                if(!user.IsValid())
                    throw new Exception("User is not valid");
                
                _context.Users.Add(user);
                return _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error creating user in database");
                throw;
            }
        }

        public Task UpdateUser(User user)
        {
            try
            {
                if(!user.IsValid())
                    throw new Exception("User is not valid");
                
                _context.Users.Update(user);
                return _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error updating user in database");
                throw;
            }
        }
    }
}