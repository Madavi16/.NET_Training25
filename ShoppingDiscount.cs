﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    internal class ShoppingDiscount
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter purchase amount: ");
            double purchaseAmt=Convert.ToDouble(Console.ReadLine());

            double discountPercentage;

            if (purchaseAmt < 1000)
                discountPercentage = 0;
            else if (purchaseAmt <= 5000)
                discountPercentage = 10;
            else
                discountPercentage = 20;

            double discountAmt = (discountPercentage / 100) * purchaseAmt;
            double TotalAmount = purchaseAmt - discountAmt;

            Console.WriteLine($"\nPurchase amount: {purchaseAmt} \nDiscount Applied: {discountPercentage} \nTotal Amount with Discount: {TotalAmount}");

            Console.ReadLine();
        }
    }
}
