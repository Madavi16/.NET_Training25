using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUtilityBillingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n===== Welcome to Online Utility Billing System =====");
            Console.WriteLine("Enter number of customers: ");
            int count=Convert.ToInt32(Console.ReadLine());

            for(int i=0;i<count;i++)
            {
                Console.WriteLine($"Enter details for Customer #{i+1}");
                Console.WriteLine($"Customer ID: ");
                int id=Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Customer Name: ");
                string name=Console.ReadLine();

                //Console.WriteLine("Enter the utility type: ");
                //string type=Console.ReadLine();

                Console.WriteLine("Enter Rate per Unit: ");
                decimal rate= Convert.ToDecimal(Console.ReadLine());

                Customer c = new Customer(id, name);

                c.CalculateBill(rate, out decimal usage, out decimal tax, out decimal netPayable);
                c.DisplayInvoice(usage, tax, netPayable);
            }

            Console.WriteLine("\nAll customer bills processed Successfully!");
            Console.ReadLine();
        }
    }
}
