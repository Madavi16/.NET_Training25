using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


namespace ElectricityProject.App_Code
{
    using System;

    public class ElectricityBill
    {
        // private fields
        private string consumerNumber;
        private string consumerName;
        private int unitsConsumed;
        private double billAmount;

        // public properties
        public string ConsumerNumber
        {
            get { return consumerNumber; }
            set
            {
                // Validation 1
                if (!value.StartsWith("EB") || value.Length != 7)
                {
                    throw new FormatException("Invalid Consumer Number");
                }
                consumerNumber = value;
            }
        }

        public string ConsumerName
        {
            get { return consumerName; }
            set { consumerName = value; }
        }

        public int UnitsConsumed
        {
            get { return unitsConsumed; }
            set { unitsConsumed = value; }
        }

        public double BillAmount
        {
            get { return billAmount; }
            set { billAmount = value; }
        }
    }
}