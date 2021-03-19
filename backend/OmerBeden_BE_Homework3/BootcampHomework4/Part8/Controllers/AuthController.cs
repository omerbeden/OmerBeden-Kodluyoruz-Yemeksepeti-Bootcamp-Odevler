using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Part8.Data.Models;
using Part8.Services;

namespace Part8.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        
        [AllowAnonymous]
        [HttpPost(Name = nameof(Authenticate))]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Authenticate([FromBody] TokenRequest request)
        {
            if (request==null)
            {
                return BadRequest();
            }

            var result = await _userService.Authenticate(request);
            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Refresh([FromBody] TokenRefreshRequest request)
        {
            var identities = this.HttpContext.User.Identities.ToList();
            var result = _userService.RefreshToken(request);
            return Ok(result);
        }
    }
}
