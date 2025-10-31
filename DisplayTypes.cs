using System;

namespace FirstPrj
{
    internal class DisplayTypes
    {
        public void Display()
        {
            string fname, lname;
            Console.WriteLine("Enter your first name:");
            fname = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            lname = Console.ReadLine();

            Console.WriteLine($"Your first name is : {fname} and your last name is : {lname}");
            Console.WriteLine("Your first name is: " + fname + " and your last name is: " + lname);
            Console.WriteLine("Your first name is: {0} and your last name is: {1}", fname, lname);
        }
    }
}
