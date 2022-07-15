using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Models
{
    public class AdminLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public int AdminId { get; set; }
    }
}
