using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TupleDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TuplesDemoExample ob = new TuplesDemoExample();
            //var res = ob.tupleDemo();

            //WriteLine($"Id: {res.Item1}");
            //WriteLine($"Name: {res.Item2}");
            //WriteLine($"Mark: {res.Item3}");



            //(var id, var name, var mark) = ob.tupleDemo();
            //WriteLine($"ID: {id}\nName: {name}\nMark: {mark}");

            // ob.outDemo();

            //ob.patternMacthing();

            //ob.Readability();

            //ob.LocalFunc(100);

            ob.throwexpDemo();
            ReadLine();


        }

        
    }
}
