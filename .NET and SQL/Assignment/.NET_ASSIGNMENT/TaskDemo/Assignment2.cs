using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TaskDemo
{
    internal class Assignment2
    {
        public static void Run()
        {
            Task<int> t1 = Task.Run(() =>
            {
                int res = 15 + 5;
                return res;
            });

            Task<int> t2 = Task.Run(() =>
            {
                int res = 10 * 2;
                return res;
            });

            Task<int> t3 = Task.Run(() =>
            {
                int res = 678 - 321;
                return res;
            });


          

            //another method

            Task execute = Task.Run(() =>
            {
                Task.WaitAll(t1, t2, t3);
            });

            execute.ContinueWith(t=>
            {
                int r1 = t1.Result;
                int r2 = t2.Result;
                int r3 = t3.Result;

                WriteLine($"Result form Task 1: {r1}");
                WriteLine($"Result form Task 2: {r2}");
                WriteLine($"Result form Task 3: {r3}");

                int sum = r1 + r2 + r3;
                WriteLine($"Sum of all values of the three tasks: {sum}");
            }).Wait();


        }
    }
}
