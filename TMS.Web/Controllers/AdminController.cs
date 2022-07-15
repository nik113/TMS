using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TMS.Data.Interfaces;
using TMS.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TMS.Data;
using TMS.Web.Extensions;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TMS.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdmin _admin;

        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }
        [NoDirectAccess]
        public IActionResult Index()
        {
            if (User.GetRole() == "MasterAdmin")
            {
                var adminList = _admin.GetAdmins(new AdminLoginRequest() { Type = "_getall" });
                return View(adminList);
            }
            else return RedirectToAction("List", "Customer");
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminLoginRequest model)
        {
            ResponseViewModel vm = new ResponseViewModel();
            try
            {
                if (model != null)
                {
                    AdminLoginResponse _model = _admin.AdminLogin(model);
                    if (_model != null)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim("AdminId",_model.AdminId.ToString()),
                            new Claim("UserName",_model.UserName.ToString()),
                            new Claim("Name",_model.Name),
                            new Claim("IsMasterAdmin",_model.IsMasterAdmin.ToString()),
                            new Claim("Role",_model.IsMasterAdmin ? "MasterAdmin":"Admin")
                        };
                        var identity = new ClaimsIdentity(claims, _model.UserName.ToString());
                        var userPrincipal = new ClaimsPrincipal(new[] { identity });
                        HttpContext.SignInAsync(userPrincipal);

                        vm.Status = true;
                        vm.Data = _model;
                        vm.Msg = "Login successfully";
                        vm.Data = new { URL = "/Admin/Index" };
                    }
                    else
                    {
                        vm.Status = false;
                        vm.Msg = "UserName Or Password Wrong";
                        vm.StatusCode = Models.StatusCode.ValidationError;
                    }
                }
                else
                {
                    vm.Status = false;
                    vm.StatusCode = Models.StatusCode.ValidationError;
                }
            }
            catch (Exception ex)
            {
                vm.Status = false;
                vm.Msg = "UserName Or Password Wrong";
                vm.StatusCode = Models.StatusCode.ServerError;
            }
            return Json(vm);
        }
        [NoDirectAccess]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [NoDirectAccess]
        public IActionResult Create(AdminLoginResponse model)
        {
            ResponseViewModel vm = new ResponseViewModel();
            try
            {
                int i = _admin.AddAdmin(model);
                if (i > 0)
                {
                    vm.Status = true;
                    vm.Msg = "Added successfully";
                    vm.Data = new { URL = "/Admin/Index" };
                }
                else
                {
                    vm.Status = true;
                    vm.Msg = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                vm.Status = false;
                vm.Msg = ex?.ToString();
                vm.StatusCode = Models.StatusCode.ServerError;
            }
            return Json(vm);
        }

        [HttpGet]
        [NoDirectAccess]
        public IActionResult ToggleAdmin(int adminId, bool status)
        {
            ResponseViewModel vm = new ResponseViewModel();
            try
            {
                int i = _admin.ToggleAdmin(adminId, status);
                if (i > 0)
                {
                    vm.Status = true;
                }
                else
                {
                    vm.Status = true;
                    vm.Msg = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                vm.Status = false;
                vm.Msg = ex?.ToString();
                vm.StatusCode = Models.StatusCode.ServerError;
            }
            return Json(vm);
        }

        [NoDirectAccess]
        public IActionResult Edit(int id)
        {
            var admins = _admin.GetAdmins(new AdminLoginRequest() { AdminId = id, Type = "_get"});
            return View(admins.FirstOrDefault());
        }

        [HttpPost]
        [NoDirectAccess]
        public IActionResult Edit(AdminLoginResponse model)
        {
            ResponseViewModel vm = new ResponseViewModel();
            try
            {
                int i = _admin.UpdateAdmin(model);
                if (i > 0)
                {
                    vm.Status = true;
                    vm.Msg = "Updated successfully";
                    vm.Data = new { URL = "/Admin/Index" };
                }
                else
                {
                    vm.Status = true;
                    vm.Msg = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                vm.Status = false;
                vm.Msg = ex?.ToString();
                vm.StatusCode = Models.StatusCode.ServerError;
            }
            return Json(vm);
        }
    }
}
