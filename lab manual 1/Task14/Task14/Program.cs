﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, sum = 0;
            do
            {
                Console.Write("Enter number: ");
                num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }
            while (num != -1);
            sum = sum + 1;
            Console.WriteLine("The total sum is {0}", sum);
            Console.Read();

        }
    }
}
