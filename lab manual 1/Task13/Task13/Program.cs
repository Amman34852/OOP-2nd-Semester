using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, sum = 0;
            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine());
            while (num != -1)
            {
                sum = sum + num;
                Console.Write("Enter number: ");
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The total sum is {0}", sum);
            Console.Read();
        }
    }
}
