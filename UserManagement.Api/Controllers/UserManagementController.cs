using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserManagement.Api.Controllers.Actions.Interfaces;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementActions _userManagementActions;
        private readonly ILogger<UserManagementController> _logger;

        public UserManagementController(IUserManagementActions userManagementActions, ILogger<UserManagementController> logger)
        {
            _userManagementActions = userManagementActions ?? throw new ArgumentNullException(nameof(userManagementActions));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _userManagementActions.GetUsers();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in GetUsers");
                return BadRequest("Error getting users");
            }
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            if (id is null or "")
                return BadRequest("Id is required");
            if (!int.TryParse(id, out var userId))
                return BadRequest("Id must be an integer");
            
            try
            {
                var result = await _userManagementActions.GetUser(userId);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in GetUser");
                return BadRequest("Error getting user");
            }
        }
    }
}