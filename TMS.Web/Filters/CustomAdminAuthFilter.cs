//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TMS.Web.Filters
//{
//    public class CustomAdminAuthFilter :ActionFilterAttribute, IAuthenticationFilter
//    {
//        public void OnAuthentication(AuthenticationContext filterContext)
//        {

//            if (string.IsNullOrEmpty(User.GetUserId()))
//            {
//                filterContext.Result = new HttpUnauthorizedResult();
//            }
//        }
//        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
//        {
//            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
//            {
//                //Redirecting the user to the Login View of Account Controller  
//                filterContext.Result = new RedirectToRouteResult(
//                new RouteValueDictionary
//                {
//                     { "controller", "Account" },
//                     { "action", "Login" }
//                });
//            }
//        }
//    }
//}
