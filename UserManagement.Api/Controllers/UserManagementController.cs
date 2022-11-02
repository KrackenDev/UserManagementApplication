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
            if (!UserIdIsValid(id))
                return BadRequest("Id is invalid");
            
            try
            {
                var result = await _userManagementActions.GetUser(int.Parse(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in GetUser");
                return BadRequest("Error getting user");
            }
        }
        
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            if (!UserIdIsValid(id))
                return BadRequest("Id is invalid");

            try
            {
                await _userManagementActions.DeleteUser(int.Parse(id));
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in DeleteUser");
                return BadRequest("Error deleting user");
            }
        }

        private static bool UserIdIsValid(string id)
        {
            return (id is not (null or "")) && int.TryParse(id, out _);
        }
    }
}