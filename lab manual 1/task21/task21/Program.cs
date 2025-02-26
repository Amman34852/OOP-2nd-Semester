using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter minimum number of orders: ");
            int minOrders = int.Parse(Console.ReadLine());
            Console.Write("Enter minimum price per order: ");
            int minPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("\nCustomers eligible for a free pizza:");
            freePizza(minOrders, minPrice);
        }
        static void freePizza(int minOrders, int minPrice)
        {
            string filePath = "C:\\Users\\dell\\Desktop\\task21\\data.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: File not found!");
                return;
            }

            string[] lines = File.ReadAllLines(filePath); 
            bool found = false; 

            foreach (string line in lines)
            {
                string[] parts = line.Split(' '); 
                string name = parts[0]; 
                int orderCount = int.Parse(parts[1]); 
                string orderData = parts[2].Trim('[', ']');

                string[] orderPrices = orderData.Split(','); 
                int validOrderCount = 0;

                foreach (string price in orderPrices)
                {
                    if (int.Parse(price) >= minPrice)
                    {
                        validOrderCount++;
                    }
                }

                if (validOrderCount >= minOrders)
                {
                    Console.WriteLine(name);
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No customer qualifies for a free pizza.");
            }
        }


    }
