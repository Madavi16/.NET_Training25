using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ElectricityBillWebApp.App_Code
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            string conStr = ConfigurationManager.ConnectionStrings["EBConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            return con;
        }
    }
}