using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Part6.Services
{
    public interface IHandleAuthService
    {
        IActionResult Handle<T>(string ip) where T : ControllerBase;
    }
}
