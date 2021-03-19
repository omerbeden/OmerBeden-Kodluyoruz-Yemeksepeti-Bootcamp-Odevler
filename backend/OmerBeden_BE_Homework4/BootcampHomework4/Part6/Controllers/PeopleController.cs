using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part6.Services;

namespace Part6.Controllers
{
    [Route("api/{ip}/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IHandleAuthService _handleAuthService;

        public PeopleController(IHandleAuthService handleAuthService)
        {
            _handleAuthService = handleAuthService;
        }

        [HttpGet]
        public IActionResult GetHome(string ip)
        {
            return _handleAuthService.Handle<PeopleController>(ip);

        }

    }
}
