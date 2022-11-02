﻿using System;
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
        
        public async Task<User[]> GetUsers()
        {
            return await _userManagementRepo.GetUsers();
        }
    }
}