﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketPrinter
{
    internal class TicketPrice
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your age: ");
            int age=int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the time: (24hr-Format)");
            int time=int.Parse(Console.ReadLine());

            int price;

            if (age < 12)
                price = 150;
            else
            {
                if (time < 18)
                    price = 250;
                else
                    price = 300;
            }

            Console.WriteLine("Ticket Price: "+price);

            Console.ReadLine();
        }
    }
}
