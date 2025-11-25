// See https://aka.ms/new-console-template for more information
using System;
using Microsoft.Extensions.DependencyInjection;
using ReferenceLibraryClass;
using static System.Console;

namespace NewFeatures_Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceCollection();

            service.AddSingleton<IEmployeeDataReader, MockEmployeeDataReader>();
            service.AddTransient<PayrollProcessor>(); 

            var provider=service.BuildServiceProvider();

            var payroll= provider.GetRequiredService<PayrollProcessor>();

            var employeeIdsToCheck = new[] { 101, 102, 103, 104, 999 };

            WriteLine("\n=============== Displaying Employee Records ===============\n");
            foreach(var id in employeeIdsToCheck)
            {
                decimal total = payroll.CalculateTotalCompensation(id);
                var r = provider.GetRequiredService<IEmployeeDataReader>().GetEmployeeRecord(id);

                WriteLine($" ID: {id}\n Name : {r.Name}\n Role: {r.Role}\n Veteran: {r.IsVeteran} ");
                WriteLine($" => Total Compensation (Base salary + Bonus ) = {total:F2}");
                WriteLine("\n------------------------------------------------------------\n");

            }

            WriteLine("Press Any Key to Exit.......... Bye Bye");
            Console.ReadLine();
        }
    }
}