using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Part8.Data.Models
{
    public class ApiError
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public ApiVersion Version { get; set; }
        
    }
}
