using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Identity
{
    public class IdentitySettings
    {
        public static readonly string ClaimEmail = "Email";
        public static readonly string ClaimUserId = "UserId";
        public static readonly string ClaimCompanyId = "CompanyId";

        public static readonly string RoleRegular = "Regular";
        public static readonly string RoleManager = "Manager";
        public static readonly string RoleAdmin = "Admin";
    }
}
