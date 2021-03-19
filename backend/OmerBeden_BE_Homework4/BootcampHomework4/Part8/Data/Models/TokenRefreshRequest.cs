using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part8.Data.Models
{
    public class TokenRefreshRequest
    {
        public string LoginUser { get; set; }
        public string LoginPassword { get; set; }
        public DateTime ExpireTime { get; set; }
        public string Token { get; set; }
    }
}
