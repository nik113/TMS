using TMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Interfaces
{
    public interface IUserMaster
    {
        UserMaster Login(Login login);
        //int ManageCustomer(CustomerResponse customerResponse);
        //List<CustomerResponse> GetCustomers(CustomerRequest customerRequest);
        //CustomerResponse GetCustomer(CustomerRequest customerRequest);
        //int ManageDocument(UploadRequest uploadRequest, DataTable dtDocuments);
        //List<DocumentDetails> GetDocuments(int customerId, int financialYearId, int adminId, string type, int documentId = 0);
    }
}
