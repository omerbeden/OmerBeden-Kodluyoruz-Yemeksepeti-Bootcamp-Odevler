using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Part6.Enums;

namespace Part6.Services
{
    public class HandleAuthService : IHandleAuthService
    {
        private IConfiguration _configuration;

        public HandleAuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Handle<T>(string ip) where T : ControllerBase
        {

            var roles = _configuration.GetSection($"IPWhiteList:{ip}").Get<string[]>();

            if (roles == null)
            {
                return new BadRequestObjectResult("kullanıcını hiçbir yetkisi yok");
            }

            if (!roles.Contains(typeof(T).Name))
            {
                return new UnauthorizedObjectResult("Kullanıcının bu controllere erişemez");
            }

            return new OkObjectResult(ip);
        }
    }
}
