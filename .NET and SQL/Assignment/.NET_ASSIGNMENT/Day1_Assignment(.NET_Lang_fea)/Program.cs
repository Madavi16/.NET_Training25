using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Day1_Assignment_.NET_Lang_fea_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("\n========== Partial Class Demo ==========\n");
            List<Student> s1 = new List<Student>()
            {
                new Student { Name = "Alice", Age = 20 },
                new Student { Name = "Bob", Age = 22  },
                new Student { Name = "Charlie", Age = 19  },
                new Student { Name = "Diana", Age = 21  }

            };
          
            foreach (var student in s1)
            {
                student.DisplayDetails();
            }

            WriteLine("\n========== Extension Method Demo ==========\n");
            WriteLine("Enter a string to check if it is in uppercase:");
            string str=Console.ReadLine();

            WriteLine($"String is in Uppercase: {str.IsUpper()}");

            WriteLine("\n========== Sum of Squares Extension Method Demo ==========\n");
            List<int> numbers = new List<int>()
            {2,3,4 };
            
            WriteLine("Sum of Squares: " + numbers.SumOfSquares());

            Console.ReadLine();
        }
    }
}
