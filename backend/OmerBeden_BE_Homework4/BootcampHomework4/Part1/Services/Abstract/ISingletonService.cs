using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Part1.Services.Abstract
{
    public interface ISingletonService
    {
        string LogRequestToConsole(HttpContext context);
    }
}
