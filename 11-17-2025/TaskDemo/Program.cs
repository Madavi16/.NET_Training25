using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace TaskDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("\n========== Assignment1 ==========\n");
            Assignment1.RunTask();

            WriteLine("\n========== Assignment2 ==========\n");
            Assignment2.Run();


            WriteLine("\n=========== Assignment3 ===========\n");
            WriteLine("Enter a number to find factorial: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Task<int> factorailRes = Assignment3.getFactorial(num);
            factorailRes.Wait(); 

            //int res = factorailRes.Result;

            Console.WriteLine($"Factorial of {num} is: {factorailRes.Result}");
            Console.ReadLine();
        }
    }
}
