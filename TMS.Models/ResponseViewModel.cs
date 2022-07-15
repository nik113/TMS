using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Models
{
    public class ResponseViewModel
    {
        public bool Status { get; set; }
        public StatusCode StatusCode { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
