using System;
using Microsoft.AspNetCore.Http;
using Part1.Services.Abstract;

namespace Part1.Services.Concrete
{
    public class SingletonService:ISingletonService
    {
        private readonly Guid _ServiceId = Guid.NewGuid();

        public string LogRequestToConsole(HttpContext context)
        {
            String firstMessage = "Exucuting Singleton Service with id:" + _ServiceId + "\n";
            DateTime date = DateTime.Now;
            string logMessage = String.Concat(firstMessage, date + " ", context.Request.Method.ToString());
            return logMessage;
        }
    }
}