using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age, toyPrice, amount = 0; 
            float machinePrice = 0, sum = 0, difference;
            Console.Write("Enter the age: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter the machine price: ");
            machinePrice = float.Parse(Console.ReadLine());
            Console.Write("Enter the price of toy: ");
            toyPrice = int.Parse(Console.ReadLine());
            int m_age = age % 2;
            int x = age / 2;
            if (m_age == 0)
            {
                for (int i = 1; i <= x; i++)
                {
                    amount = amount + ( i * 10) ;
                }
                sum = amount + (x * toyPrice) - x;
            }
            else if(m_age != 0)
            {
                for (int i = 1; i <= x; i++)
                {
                    amount = amount + (i * 10);
                }
                sum = amount + ((x+1) * toyPrice) - x;
            }
            if(sum < machinePrice)
            {
                difference = machinePrice - sum;
                Console.WriteLine("Yes! {0}", difference);
            }
            else
            {
                difference = sum - machinePrice;
                Console.WriteLine("No! {0}", difference);
            }
        }
    }
}
