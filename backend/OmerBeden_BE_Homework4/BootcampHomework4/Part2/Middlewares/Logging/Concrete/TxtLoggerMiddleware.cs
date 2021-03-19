using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Part2.Middlewares.Logging.Abstract;

namespace Part2.Middlewares.Logging.Concrete
{
    public class TxtLoggerMiddleware : ITxtLogger
    {
        private RequestDelegate _next;

        private static int logId;

        private const string RequestLogDirName = "request.txt";
        private const string ResponseLogDirName = "response.txt";
        private readonly string _requestPath;
        private readonly string _responsePath;

        public TxtLoggerMiddleware(RequestDelegate next)
        {
            
            _next = next;


            string workingPath = Directory.GetCurrentDirectory();
            _requestPath = Path.Combine(workingPath, RequestLogDirName);
            _responsePath = Path.Combine(workingPath, ResponseLogDirName);

            
        }
        
        
        public async Task Invoke(HttpContext context)
        {
            logId = File.ReadLines(_requestPath).Count();
            LogRequest(context);
            await _next.Invoke(context);
            LogResponse(context);
      
        }
        

        public void LogRequest(HttpContext htpContext)
        {
            using (StreamWriter writer = new StreamWriter(_requestPath, true))
            {
               

                DateTime dataTime = DateTime.Now;
                String url = htpContext.Request.Path;
                String requestedMethod = htpContext.Request.Method;

                String LogMessage = $"{logId}" +
                                    $"\t {dataTime}" +
                                    $"\t {url}" +
                                    $"\t {requestedMethod}";

                writer.WriteLine(LogMessage);
            }
        }

        public void LogResponse(HttpContext htpContext)
        {
            using (StreamWriter writer = new StreamWriter(_responsePath, true))
            {
                
                DateTime dataTime = DateTime.Now;
                String url = htpContext.Request.Path;
                String responseStatusCode = htpContext.Response.StatusCode.ToString();

                String LogMessage = $"{logId}" +
                                    $"\t {dataTime}" +
                                    $"\t {url}" +
                                    $"\t {responseStatusCode}";

                writer.WriteLine(LogMessage);
            }
        }

    }
}
