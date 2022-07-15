using Dapper;
using TMS.Dapper.Interfaces;
using TMS.Data.Interfaces;
using TMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Implementations
{
    public class UserCustomer : IUserMaster
    {
        private IDapperRepository _dapper;
        private ICrypto _crypto;
        public UserCustomer(IDapperRepository dapper, ICrypto crypto)
        {
            _dapper = dapper;
            _crypto = crypto;
        }
        public UserMaster Login(Login login)
        {
            DynamicParameters para = new DynamicParameters();
            DbConnection connection = _dapper.GetDbconnection();
            var viewModel = new UserMaster();
            para.Add("UserName", login.UserName, DbType.String);
            para.Add("Password", login.Password, DbType.String);            
            var reader = connection.QueryMultiple("Login", para, commandType: CommandType.StoredProcedure);
            viewModel = reader.Read<UserMaster>().FirstOrDefault();
            return viewModel;
        }
        //public int ManageCustomer(CustomerResponse customerResponse)
        //{
        //    DynamicParameters para = new DynamicParameters();
        //    para.Add("Type", customerResponse.Type, DbType.String);
        //    para.Add("CustomerId", customerResponse.CustomerId, DbType.Int32);
        //    para.Add("FirstName", customerResponse.FirstName, DbType.String);
        //    para.Add("LastName", customerResponse.LastName, DbType.String);
        //    para.Add("PanNo", customerResponse.PanNo, DbType.String);
        //    para.Add("MobileNo", customerResponse.MobileNo, DbType.String);
        //    para.Add("CustomerCode", customerResponse.CustomerCode, DbType.String);
        //    para.Add("AdminId", customerResponse.AdminId, DbType.Int32);
        //    para.Add("OTP", customerResponse.OTP, DbType.String);           

        //    var result = _dapper.Insert<int>("ManageCustomerMaster", para, CommandType.StoredProcedure);
        //    return result;
        //}        
        //public List<CustomerResponse> GetCustomers(CustomerRequest customerRequest)
        //{
        //    try
        //    {
        //        DynamicParameters para = new DynamicParameters();
        //        para.Add("Type", customerRequest.Type, DbType.String);
        //        para.Add("PanNo", customerRequest.PanNo ?? string.Empty, DbType.String);
        //        para.Add("OTP", customerRequest.OTP ?? string.Empty, DbType.String);
        //        para.Add("CustomerId", customerRequest.CustomerId, DbType.Int32);
        //        para.Add("FinancialYearId", customerRequest.FinancialYearId, DbType.Int32);
        //        para.Add("AdminId", customerRequest.AdminId, DbType.Int32);
        //        var result = _dapper.GetAll<CustomerResponse>("GetCustomers", para, CommandType.StoredProcedure);
        //        return result;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<DocumentDetails> GetDocuments(int customerId,int financialYearId,int adminId,string type,int documentId=0)
        //{
        //    DynamicParameters para = new DynamicParameters();
        //    para.Add("Type", type, DbType.String);
        //    para.Add("CustomerId", customerId, DbType.Int32);
        //    para.Add("FinancialYearId", financialYearId, DbType.Int32);
        //    para.Add("AdminId", adminId, DbType.Int32);
        //    para.Add("DocumentId", documentId, DbType.Int32);
        //    var result = _dapper.GetAll<DocumentDetails>("GetDocuments", para, CommandType.StoredProcedure);
        //    return result;
        //}
        
        //public CustomerResponse GetCustomer(CustomerRequest customerRequest)
        //{
        //    DynamicParameters para = new DynamicParameters();
        //    DbConnection connection = _dapper.GetDbconnection();
        //    var viewModel = new CustomerResponse();
        //    para.Add("Type", customerRequest.Type, DbType.String);
        //    para.Add("PanNo", customerRequest.PanNo, DbType.String);
        //    para.Add("OTP", customerRequest.OTP, DbType.String);
        //    para.Add("CustomerId", customerRequest.CustomerId, DbType.Int32);
        //    para.Add("FinancialYearId", customerRequest.FinancialYearId, DbType.Int32);
        //    para.Add("AdminId", customerRequest.AdminId, DbType.Int32);
        //    var reader = connection.QueryMultiple("GetCustomers", para, commandType: CommandType.StoredProcedure);
        //    viewModel = reader.Read<CustomerResponse>().FirstOrDefault();
        //    return viewModel;
        //}
        //public int ManageDocument(UploadRequest uploadRequest,DataTable dtDocuments)
        //{
        //    DynamicParameters para = new DynamicParameters();
        //    para.Add("Type", uploadRequest.Type, DbType.String);
        //    para.Add("CustomerId", uploadRequest.CustomerId, DbType.Int32);
        //    para.Add("DocumentId", uploadRequest.DocumentId, DbType.Int32);
        //    para.Add("AdminId", uploadRequest.AdminId, DbType.Int32);
        //    para.Add("FinancialYearId", uploadRequest.FinancialYearId, DbType.Int32);
        //    para.Add("ITEMS", dtDocuments, DbType.Object);
        //    var result = _dapper.Insert<int>("ManageDocuments", para, CommandType.StoredProcedure);
        //    return result;
        //}
    }
}
