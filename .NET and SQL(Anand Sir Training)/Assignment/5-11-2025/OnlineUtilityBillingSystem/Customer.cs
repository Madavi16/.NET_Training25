using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUtilityBillingSystem
{
    internal class Customer
    {
        public int storeCustomerID;
        public string customerName;
        //public string utilityType;

        public Customer(int id,string name)
        {
            this.storeCustomerID = id;
            this.customerName = name;
            //this.utilityType = type;
        }

        //params method
        public decimal TotalUsage(params decimal[] readings)
        {
            decimal usage = 0;
            foreach (var unit in readings)
            {
                usage += unit;
            }
            return usage;
        }

        //non-static method
        public void CalculateBill(decimal ratePerUnit, out decimal usage, out decimal tax, out decimal netPayable)
        {
            Console.WriteLine("\nEnter the number of readings: ");
            int n = Convert.ToInt32(Console.ReadLine());
            decimal[] readings = new decimal[n];

            Console.WriteLine("Enter the values: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nReading {i + 1}");
                readings[i] = Convert.ToDecimal(Console.ReadLine());
            }


            usage = TotalUsage(readings);

            decimal basicCharge = usage * ratePerUnit;
            tax = Utility.CalculateTax(basicCharge);
            netPayable = basicCharge + tax + Utility.serviceCharge;
        }
        public void DisplayInvoice(decimal usage, decimal tax, decimal netPayable)
           {
            Console.WriteLine("\n------------ Utility Bill -------------");
            Console.WriteLine($"Customer Id\t: {storeCustomerID}");
            Console.WriteLine($"Customer Name\t; {customerName}");
            Console.WriteLine($"Service Charge\t: {Utility.serviceCharge}");
            Console.WriteLine($"Total Usage\t: {usage}");
            Console.WriteLine($"Tax Applied\t: {tax}");
            Console.WriteLine($"Net Payable\t: {netPayable}");
            Console.WriteLine("\n========================================\n");
            Console.ReadLine();
        }
    }
}
