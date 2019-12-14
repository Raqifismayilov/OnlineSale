using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace OnlineSale.Areas.AdminPart.Models.AdoConnect
{
    public class SqlConnect
    {
        public string ConnectStr;
        public SqlConnect(string connectName)
        {
            string str = WebConfigurationManager.ConnectionStrings[connectName].ConnectionString;
            SqlConnectionStringBuilder bld = new SqlConnectionStringBuilder(str);
            if (ConnectStr != null)
            {
                ConnectStr = string.Empty;
            }
            else
                this.ConnectStr = bld.ConnectionString;
        }
    }
}