using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TupleDemo
{
    internal class TuplesDemoExample
    {
        //public (int, string, double) tupleDemo()
        //{
        //    //Features : using tuple u can return multiple values
        //    //now its standards
        //    //how to use tuple - using ()
        //    int id = 100;
        //    string name = "Deepa";
        //    double radius = 3.15;

        //    return (id, name, radius);

        //}
        //deconstruction - it will be used along with tuples
        //out keyword
        //try parse bettery way to type casting
        //avoid run time errors

        //int.Parse // converts string to int
        //double.Parse // convert string to double
        //float.Parse // string to float
        //public void outDemo()
        //{
        //    //int a =int.Prase(console.Readline());

        //    //int x;
        //    var res = int.TryParse(Console.ReadLine(), out int x);
        //    WriteLine("U have entered " + x);
        //    if (res == true)
        //    {
        //        WriteLine("U have entered " + x);
        //    }
        //    else
        //    {
        //        WriteLine("Convertion failed");
        //    }

        //}

        //public void patternMacthing()
        //{
        //    //Feature: avoid typecasting - performance down
        //    //will also make code look compact and very widely used in switch and if condition

        //    //object shape = "Circle";
        //    //object int =123;
        //    object shape = 90.2;
        //    WriteLine(shape.GetType().Name);
        //    switch (shape.GetType().Name)
        //    {
        //        case "Int32":
        //            int n = (int)shape;
        //            if (n > 0)
        //                WriteLine("Positive number");
        //            else
        //                WriteLine("Unknown");
        //            break;
        //        case "String":

        //            string s = (string)shape;
        //            if (s == "Circle")
        //                WriteLine("It is a circle");
        //            else
        //                WriteLine("Unknown");
        //            break;
        //        default:
        //            WriteLine("Unknown");
        //            break;
        //    }

            //real pattern matching
            //imporvised method with less line of code using when keyword and intializing the method to the cases of switch

           // object shapes = "Circle";
           //// object shapes = 123;

           // switch (shapes)
           // {
           //     case int n when n > 0:
           //         WriteLine("Positive number");
           //         break;
           //     case string s when s == "Circle":
           //         WriteLine("Its a circle");
           //         break;
           //     default:
           //         WriteLine("Unknown");
           //         break;

           // }


            //another example for switch cases
            //int marks = Convert.ToInt64(Console.ReadLine());
            //string result = marks switch
            //{
            //    >= 90 => "Excellent",
            //    >= 75 => "good",
            //    >= 56 => "Average",
            //    _ => "Fail"
            //};

        //}
        //public void Readability() //better readability
        //{
        //    //Feature:  using _ insead of comma 
        //    int x = 10_000_0000;
        //    WriteLine(x);

        //}
        
        //public string LocalFunc(int a)
        //{
        //    //Feature: function inside a func
        //    //how to nest the function: use this feature if the func grows too long
        //    string greatest(int a) 
        //    {
        //        if (a > 10) 
        //            return "a is greater than 10 ";
        //        else
        //            return "a is not greater than 10";

        //    }
        //    return greatest(a);

        //}

        public void throwexpDemo()
        {
            string st = null;

            ////old way
            //if(st==null)
            //{
            //    throw new ArgumentException("Execption occurs");
            //}

            //new way
           string GetMessage(string name) => st ?? throw new ArgumentException("Exp occurs");

            //string res = st ?? throw new ArgumentException("exp occurs");
        }

    }
}
