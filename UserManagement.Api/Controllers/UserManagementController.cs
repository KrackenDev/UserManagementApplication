using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserManagement.Api.Controllers.Actions.Interfaces;
using UserManagement.Infrastructure.Models;

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
                return GenerateBadResponse("Error getting users", "Error in GetUsers endpoint", e);
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
                return GenerateBadResponse("Error getting user", "Error in GetUser endpoint", e);
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
                return GenerateBadResponse("Error deleting user", "Error in DeleteUser endpoint", e);
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (!user.IsValid())
                return BadRequest("User is invalid");

            try
            {
                await _userManagementActions.CreateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return GenerateBadResponse("Error creating user", "Error in CreateUser endpoint", e);
            }
        }
        
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            if (!user.IsValid())
                return BadRequest("User is invalid");

            try
            {
                await _userManagementActions.UpdateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return GenerateBadResponse("Error updating user", "Error in UpdateUser endpoint", e);
            }
        }
        
        private static bool UserIdIsValid(string id)
        {
            return (id is not (null or "")) && int.TryParse(id, out _);
        }

        private IActionResult GenerateBadResponse(string httpMessage, string logMessage, Exception exception)
        {
            _logger.LogError(exception, logMessage);
            return BadRequest(httpMessage);
        }
    }
}