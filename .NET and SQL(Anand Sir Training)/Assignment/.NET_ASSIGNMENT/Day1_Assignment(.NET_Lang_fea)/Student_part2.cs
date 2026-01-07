using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace Day1_Assignment_.NET_Lang_fea_
{
    internal partial class Student
    {
        public void DisplayDetails()
        {
            WriteLine("Displaying Student Details");
            WriteLine($"Student Name: {Name}");
            WriteLine($"Student Age: {Age}");
        }

    }
}
