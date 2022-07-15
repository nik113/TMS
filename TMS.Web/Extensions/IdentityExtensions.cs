using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TMS.Web.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            ClaimsPrincipal currentUser = user;
            return Convert.ToString(currentUser?.Claims?.FirstOrDefault(c => c.Type == "UserName")?.Value);
        }

        public static int GetAdminId(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return 0;

            ClaimsPrincipal currentUser = user;
            return Convert.ToInt32(currentUser?.Claims?.FirstOrDefault(c => c.Type == "AdminId")?.Value);
        }
        public static int GetCustomerId(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return 0;

            ClaimsPrincipal currentUser = user;
            return Convert.ToInt32(currentUser?.Claims?.FirstOrDefault(c => c.Type == "CustomerId")?.Value);
        }
        public static string GetRole(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return string.Empty;

            ClaimsPrincipal currentUser = user;
            return Convert.ToString(currentUser?.Claims?.FirstOrDefault(c => c.Type == "RoleName")?.Value);
        }
        public static string GetName(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return string.Empty;

            ClaimsPrincipal currentUser = user;
            return Convert.ToString(currentUser?.Claims?.FirstOrDefault(c => c.Type == "Name")?.Value);
        }
        public static string GetFirstName(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return string.Empty;

            ClaimsPrincipal currentUser = user;
            return Convert.ToString(currentUser?.Claims?.FirstOrDefault(c => c.Type == "FirstName")?.Value);
        }
        public static string GetLastName(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return string.Empty;

            ClaimsPrincipal currentUser = user;
            return Convert.ToString(currentUser?.Claims?.FirstOrDefault(c => c.Type == "LastName")?.Value);
        }
        public static string GetCompanyName(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return string.Empty;

            ClaimsPrincipal currentUser = user;
            return Convert.ToString(currentUser?.Claims?.FirstOrDefault(c => c.Type == "CompanyName")?.Value);
        }
    }
}
