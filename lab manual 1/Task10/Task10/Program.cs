using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float length, area;
            string str;
            Console.WriteLine("Enter length: ");
            str = Console.ReadLine();
            length = float.Parse(str);
            area = length * length;
            Console.WriteLine("The area is: ");
            Console.Write(area);
            Console.ReadKey();
        }
    }
}
