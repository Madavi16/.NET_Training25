using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace TaskDemo
{
    internal class Assignment3
    {
        //using extension methods
        public static Task<int> getFactorial(int num)
        {
            return Task.Run(() =>
            {
                int fact = 1;
                for (int i = 1; i <= num; i++)
                {
                    fact *= i;
                }
                return fact;
            });

           
           

        }
    }
}
