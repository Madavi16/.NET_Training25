using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


namespace ElectricityProject.App_Code
{
    public class BillValidator
    {
        public string ValidateUnitsConsumed(int unitsConsumed)
        {
            if (unitsConsumed < 0)
            {
                return "Given units is invalid";
            }
            return "Valid";
        }
    }
}