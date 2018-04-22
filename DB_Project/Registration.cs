using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Registration
{
    public class Registration
    {
        #region Declaration
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int usertype { get; set; }
        #endregion
    }

}