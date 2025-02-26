using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            float marks;
            Console.Write("Enter the marks: ");
            input = Console.ReadLine();
            marks = float.Parse(input);
            if (marks > 50)
            {
                Console.WriteLine("Yoy are passed");
            }
            else 
            {
                Console.WriteLine("You are failed");
            }
            Console.ReadKey();
        }
    }
}
