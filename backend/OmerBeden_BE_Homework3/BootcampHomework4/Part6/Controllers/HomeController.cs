using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Part6.Enums;
using Part6.Services;

namespace Part6.Controllers
{
    [Route("api/{ip}/[controller]")]
    //[Authorize(Roles = "Sales,HRPerson")]
    public class HomeController : ControllerBase
    {

        private readonly IHandleAuthService _handleAuthService;

        public HomeController(IHandleAuthService handleAuthService)
        {
            _handleAuthService = handleAuthService;
        }

        [HttpGet]
        public IActionResult GetHome(string ip)
        {
            return _handleAuthService.Handle<HomeController>(ip);


        }
    }
}
