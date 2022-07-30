using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMS.Models
{
    public class AdminLoginResponse
    {
        //public int AdminId { get; set; }
        //[Required(ErrorMessage = "Name is required")]
        //public string Name { get; set; }
        //[Required(ErrorMessage = "UserName is required")]
        //public string UserName { get; set; }
        //[Required(ErrorMessage = "Password is required")]
        //public string Password { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public bool IsActive { get; set; }
        //public bool IsMasterAdmin { get; set; }
        //[Required(ErrorMessage = "MobileNo is required")]
        //public string MobileNo { get; set; }
        //[Required(ErrorMessage = "City is required")]
        //public string City { get; set; }
        //[Required(ErrorMessage = "Address is required")]
        //public string Address { get; set; }
        //[Required(ErrorMessage = "CompanyName is required")]
        //public string CompanyName { get; set; }

        public int AdminId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
