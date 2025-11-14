using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUtilityBillingSystem
{
    internal class Utility
    {
        //static variable doesnt need object we can access it with the class name itself
        public static decimal serviceCharge = 50;

        //static method
        public static decimal CalculateTax(decimal amount)
        {
            return amount * 0.10m;
        }
    }
}
