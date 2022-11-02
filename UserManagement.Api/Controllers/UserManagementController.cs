using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Api.Controllers.Actions.Interfaces;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementActions _userManagementActions;

        public UserManagementController(IUserManagementActions userManagementActions)
        {
            _userManagementActions = userManagementActions ?? throw new ArgumentNullException(nameof(userManagementActions));
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _userManagementActions.GetUsers();
                return Ok(result);
            }
            catch (Exception e)
            {
                // TODO: Add ILogger.
                Console.WriteLine(e);
                return BadRequest("Error getting users");
            }
        }
    }
}