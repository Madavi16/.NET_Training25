using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//#Assignment1
namespace TaskDemo
{
    internal class Assignment1
    {
        public static void RunTask()
        {
            var t1 = Task.Run(() =>
            {
                for(int i=0;i<5;i++)
                {
                    WriteLine($"Task1: #{i + 1}");
                }
            });

            var t2 = Task.Run(() =>
            {
                for(int i=5;i<10;i++)
                {
                    WriteLine($"Task2: #{i + 1}");
                }
            });

            var t3 = Task.Run(() =>
            {
                WriteLine("All Tasks Executed Successfully");

            });

            Task.WaitAll(t1, t2, t3);

            WriteLine("Done");
            
        }
    }
}
