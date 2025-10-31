﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetails
{
    internal class StudentResult
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Student Name: ");
            string name=Console.ReadLine();

            Console.WriteLine("Enter your marks between 0 and 100: ");
            int marks= Convert.ToInt32(Console.ReadLine());

            string grade;

            if (marks >= 90)
                grade = "A+";
            else if (marks >= 80)
                grade = "A";
            else if (marks >= 70)
                grade = "B";
            else if (marks >= 60)
                grade = "C";
            else if (marks >= 50)
                grade = "D";
            else
                grade = "Fail";


            Console.WriteLine("Student Result: \n************************");

            Console.WriteLine($"Student Name: {name}");
            Console.WriteLine($"Marks: {marks}");
            Console.WriteLine($"Grade: {grade}");

            Console.WriteLine("************************");

            Console.ReadLine();
        }
    }
}
