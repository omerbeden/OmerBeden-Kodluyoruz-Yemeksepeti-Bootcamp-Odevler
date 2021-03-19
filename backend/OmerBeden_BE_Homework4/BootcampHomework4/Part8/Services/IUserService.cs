using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part8.Data.Models;

namespace Part8.Services
{
    public interface IUserService
    {
        Task<UserInfo> Authenticate(TokenRequest req);
        Task<UserInfo> RefreshToken(TokenRefreshRequest refreshRequest);
    }
}
