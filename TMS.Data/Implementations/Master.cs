using Dapper;
using TMS.Dapper.Interfaces;
using TMS.Data.Interfaces;
using TMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TMS.Data.Implementations
{
    public class Master : IMaster
    {
        private IDapperRepository _dapper;
        public Master(IDapperRepository dapper)
        {
            _dapper = dapper;
        }
       
    }
}
