using Dapper;
using TMS.Dapper.Interfaces;
using TMS.Data.Interfaces;
using TMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Implementations
{
    public class Admin : IAdmin
    {
        private IDapperRepository _dapper;
        private ICrypto _crypto;
        public Admin(IDapperRepository dapper, ICrypto crypto)
        {
            _dapper = dapper;
            _crypto = crypto;
        }
        public AdminLoginResponse AdminLogin(AdminLoginRequest adminLoginRequest)
        {
            DynamicParameters para = new DynamicParameters();            
            para.Add("UserName", adminLoginRequest.UserName, DbType.String);
            para.Add("Password", _crypto.EncryptPassword(adminLoginRequest.Password), DbType.String);
            var result = _dapper.Get<AdminLoginResponse>("AdminLogin", para, CommandType.StoredProcedure);
            return result;
        }
        public int AddAdmin(AdminLoginResponse adminLoginResponse)
        {
            DynamicParameters para = new DynamicParameters();
            para.Add("Type", "_insert", DbType.String);
            para.Add("AdminId", adminLoginResponse.AdminId, DbType.Int32);
            //para.Add("Name", adminLoginResponse.Name, DbType.String);
            para.Add("UserName", adminLoginResponse.UserName, DbType.String);
            para.Add("Password", _crypto.EncryptPassword(adminLoginResponse.Password), DbType.String);
            para.Add("MobileNo", adminLoginResponse.MobileNo, DbType.String);
            //para.Add("City", adminLoginResponse.City, DbType.String);
            //para.Add("Address", adminLoginResponse.Address, DbType.String);
            //para.Add("CompanyName", adminLoginResponse.CompanyName, DbType.String);
            var result = _dapper.Insert<int>("ManageAdminMaster", para, CommandType.StoredProcedure);
            return result;
        }
        public int UpdateAdmin(AdminLoginResponse adminLoginResponse)
        {
            DynamicParameters para = new DynamicParameters();
            para.Add("Type", "_update", DbType.String);
            para.Add("AdminId", adminLoginResponse.AdminId, DbType.Int32);
            //para.Add("Name", adminLoginResponse.Name, DbType.String);
            para.Add("UserName", adminLoginResponse.UserName, DbType.String);
            para.Add("Password", _crypto.EncryptPassword(adminLoginResponse.Password), DbType.String);
            para.Add("MobileNo", adminLoginResponse.MobileNo, DbType.String);
            //para.Add("City", adminLoginResponse.City, DbType.String);
            //para.Add("Address", adminLoginResponse.Address, DbType.String);
            //para.Add("CompanyName", adminLoginResponse.CompanyName, DbType.String);
            var result = _dapper.Update<int>("ManageAdminMaster", para, CommandType.StoredProcedure);
            return result;
        }
        public List<AdminLoginResponse> GetAdmins(AdminLoginRequest adminLoginRequest)
        {
            DynamicParameters para = new DynamicParameters();
            para.Add("Type", adminLoginRequest.Type, DbType.String);
            para.Add("UserName", adminLoginRequest.UserName, DbType.String);
            para.Add("Password", _crypto.EncryptPassword(adminLoginRequest.Password), DbType.String);
            para.Add("AdminId", adminLoginRequest.AdminId, DbType.Int32);
            var result = _dapper.GetAll<AdminLoginResponse>("GetAdminMaster", para, CommandType.StoredProcedure);
            if (result.Any())
            {
                result.ForEach(x =>
                {
                    if (!string.IsNullOrEmpty(x.Password))
                        x.Password = _crypto.DecryptPassword(x.Password);
                });
            }
            return result;
        }
        public int ToggleAdmin(int adminId, bool status)
        {
            DynamicParameters para = new DynamicParameters();
            para.Add("Status", status, DbType.Boolean);
            para.Add("AdminId", adminId, DbType.Int32);
            var result = _dapper.Update<int>("ToggleAdmin", para, CommandType.StoredProcedure);
            return result;
        }
    }
}
