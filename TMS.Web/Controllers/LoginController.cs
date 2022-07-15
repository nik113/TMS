using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using TMS.Web.Extensions;
using TMS.Data.Interfaces;

namespace TMS.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserMaster _userMaster;
        public LoginController(IUserMaster userMaster)
        {
            _userMaster = userMaster;
        }
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(Login model)
        {
            ResponseViewModel vm = new ResponseViewModel();            
            try
            {
                var _model = _userMaster.Login(model);
                if (_model != null)
                {
                   
                    var claims = new List<Claim>()
                        {
                            new Claim("UserId",_model.UserId.ToString()),
                            new Claim("FirstName",_model.FirstName.ToString()),
                            new Claim("LastName",_model.LastName.ToString()),
                            new Claim("LastName",_model.MiddleName.ToString()),
                            new Claim("RoleId",_model.RoleId.ToString()),
                            new Claim("RoleName",_model.RoleId.ToString()),
                        };
                    var identity = new ClaimsIdentity(claims, _model.FirstName);
                    var userPrincipal = new ClaimsPrincipal(new[] { identity });
                    HttpContext.SignInAsync(userPrincipal);
                    vm.Status = true;
                    vm.Data = _model;
                    vm.Msg = "Login successfully";
                    vm.Data = new { URL = "Dashboard/Index" };
                }
                else
                {
                    vm.Status = false;
                    vm.Msg = "Something went Wrong";
                    vm.StatusCode = Models.StatusCode.ValidationError;
                }
            }
            catch (Exception ex)
            {
                vm.Status = false;
                vm.Msg = ex.Message;
                vm.StatusCode = Models.StatusCode.ValidationError;
            }
            return Json(vm);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();
            if (User.GetRole() == "Customer")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
    }
}