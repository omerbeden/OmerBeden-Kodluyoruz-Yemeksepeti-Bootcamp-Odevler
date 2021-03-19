using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Part2.Middlewares.Logging.Concrete;

namespace Part2.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseTxtLogger(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<TxtLoggerMiddleware>();
            return builder;
        }
    }
}
