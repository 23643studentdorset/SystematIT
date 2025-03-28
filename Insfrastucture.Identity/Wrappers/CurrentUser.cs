using Infrastucture.Identity.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Identity.Wrappers
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId
        {
            get { return Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == IdentitySettings.ClaimUserId).Value); }
        }  

        public string Email
        {
            get { return _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == IdentitySettings.ClaimEmail).Value; }
        }

        public int CompanyId
        {
            get { return Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == IdentitySettings.ClaimCompanyId).Value); }
        }
    }
}
