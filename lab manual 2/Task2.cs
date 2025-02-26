using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_2
{
    internal class Task2
    {
        public class calculator
        {
            float num1, num2;
            public float add()
            {
                return num1 + num2;
            }
            public float mul() 
            {
                return num1 * num2;
            }
            public float div()
            {
                return num1 / num2;
            }
            public float sab()
            {
                return num1 - num2;
            }
            public calculator(float number1 , float number2)
            {
                num1 = number1;
                num2 = number2;
            }
        }
        static void Main(string[] args)
        {
            float x, y;
            Console.WriteLine("Enter the first Number");
            x = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second Number");
            y = float.Parse(Console.ReadLine());
            calculator calculator = new calculator(x,y);
            Console.WriteLine("Addition : " + calculator.add());
            Console.WriteLine("Sabtraction : "+calculator.sab());
            Console.WriteLine("Multiplication :"+calculator.mul());
            Console.WriteLine("Division :"+calculator.div());
            Console.ReadKey();
        }
    }
}
