using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Part8.Data.Models;

namespace Part8.Filters
{
    public class JsonExceptionFilters : IExceptionFilter
    {
        private IWebHostEnvironment _environment;

        public JsonExceptionFilters(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            var isDevelopment = _environment.IsDevelopment();

            var err = new ApiError
            {
                Version = context.HttpContext.GetRequestedApiVersion(),
                Message = isDevelopment ? context.Exception.Message : "hata olustu",
                Detail = isDevelopment ? context.Exception.StackTrace : context.Exception.Message
            };

            context.Result = new ObjectResult(err) { StatusCode = 500 };
        }
    }
}
