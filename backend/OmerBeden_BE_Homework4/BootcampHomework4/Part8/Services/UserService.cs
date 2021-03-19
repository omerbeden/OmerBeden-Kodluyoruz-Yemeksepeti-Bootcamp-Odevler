using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Part8.Data.Context;
using Part8.Data.Models;

namespace Part8.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private HotelApiDbContext _dbContext;

        private IConfiguration _configuration;

        public UserService(IMapper mapper, HotelApiDbContext dbContext, IConfiguration configuration)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<UserInfo> Authenticate(TokenRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.LoginUser) || string.IsNullOrWhiteSpace(req.LoginPassword))
            {
                return null;
            }

            var user = await _dbContext.Users.SingleOrDefaultAsync(user =>
                user.LoginName == req.LoginUser && user.Password == req.LoginPassword);

            if (user == null)
            {
                return null;
            }

            var secretKey = _configuration.GetValue<string>("JwtTokenKey");
            var tokenHandler = new JwtSecurityTokenHandler();
            var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256Signature),
            };

            var newToken = tokenHandler.CreateToken(tokenDesc);
            var userInfo = _mapper.Map<UserInfo>(user);
            userInfo.ExpireTime = tokenDesc.Expires.Value;
            userInfo.Token = tokenHandler.WriteToken(newToken);

            return userInfo;
        }


        /*
         * Eğer access token a sahip bir user refresh isteğinde bulunursa refresh edilip yeni token ile islemine devam edebilecek
         * user ın token ı var ama expired olmussa ozaman hata dondurecek
         */
        
        public async Task<UserInfo> RefreshToken(TokenRefreshRequest refreshRequest)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var readedToken = tokenHandler.ReadJwtToken(refreshRequest.Token);

            if (refreshRequest.ExpireTime<DateTime.Now)
            {
                throw new ArgumentNullException("Token is no longer available ");
            }
            
            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.LoginName == refreshRequest.LoginUser &&
                                                                 user.Password == refreshRequest.LoginPassword);
            if (user==null)
            {
                return null;
            }
            var secretKey = _configuration.GetValue<string>("JwtTokenKey");
            var claims = readedToken.Claims;
            var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var refreshTokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256Signature),
            };

            var refreshToken = tokenHandler.CreateToken(refreshTokenDescription);
            var userInfo = _mapper.Map<UserInfo>(user);
            userInfo.ExpireTime = refreshTokenDescription.Expires ?? DateTime.Now.AddHours(1);
            userInfo.Token = tokenHandler.WriteToken(refreshToken);

            return userInfo;
        }
    }
}
