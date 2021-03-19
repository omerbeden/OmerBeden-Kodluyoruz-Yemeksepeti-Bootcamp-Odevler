using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Part2.Middlewares.Logging.Abstract
{
    public interface ITxtLogger
    {
        void LogRequest(HttpContext htpContext);
        void LogResponse(HttpContext htpContext);
    }
}
