using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Day1_Assignment_.NET_Lang_fea_
{
    internal static class ExtensionMethodDemo
    {
        public static bool IsUpper(this string str)
        {
            //return str == str.ToUpper();
            return str.All(c=>c.Equals(Char.ToUpper(c)));

        }
    }
}
public static class  NumberExtension
{
    public static int SumOfSquares(this List<int> numbers)
    {
        //int sum = 0;
        //foreach(int n in numbers)
        //{
        //    sum += n * n;
        //}
        //return sum;
        return numbers.Select(n => n * n).Sum();
    }
}