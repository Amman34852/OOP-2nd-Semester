﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String str;
            Console.WriteLine("Enter floating point value: ");
            str = Console.ReadLine();
            float num = float.Parse(str);
            Console.WriteLine("The floating value is: ");
            Console.Write(num);
            Console.ReadKey();
        }
    }
}
