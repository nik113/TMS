using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Models
{
    public class DashboardResponse
    {
        public int TotalDocuments { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalCAs { get; set; }
    }
}
