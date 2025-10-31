﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker
{
    internal class PassStrengthCheck
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your password: (Should contain one CAPS letter, a integer and a special character)");

            string password=Console.ReadLine();

            int length=password.Length;
            string strength;

            if (length < 6)
                strength = "Weak";
            else if (length <= 10)
                strength = "Medium";
            else
                strength = "Strong";

            Console.WriteLine($"Password Strength: {strength}");

            Console.ReadLine();
        }
    }
}
