using TMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Interfaces
{
    public interface IAdmin
    {
        AdminLoginResponse AdminLogin(AdminLoginRequest adminLoginRequest);
        int AddAdmin(AdminLoginResponse adminLoginResponse);
        List<AdminLoginResponse> GetAdmins(AdminLoginRequest adminLoginRequest);
        int ToggleAdmin(int adminId, bool status);
        int UpdateAdmin(AdminLoginResponse adminLoginResponse);
    }
}
