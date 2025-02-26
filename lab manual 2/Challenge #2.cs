using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_LAB_2
{
    internal class Challenge___2
    {
       static void Main(string[] args)
        { 
            List<product> pro = new List<product>();
            List<int> Price = new List<int>();
            while (true)
            {
                int ch;
                Console.WriteLine("1.ADD Product ");
                Console.WriteLine("2.Show Products");
                Console.WriteLine("3.Store Worth");
                Console.WriteLine("4.Exit");
                ch = int.Parse(Console.ReadLine());

                if (ch == 1)
                {
                    product Products = new product();
                    Console.WriteLine("Enter the product name ");
                    Products.Name = Console.ReadLine();
                    Console.WriteLine("Enter the product ID ");
                    Products.ID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter product category ");
                    Products.Category = Console.ReadLine();
                    Console.WriteLine("Enter Brand name  ");
                    Products.BrandName = Console.ReadLine();
                    Console.WriteLine("Enter the price of product ");
                    Products.Price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the country name");
                    Products.Country = Console.ReadLine();
                    pro.Add(Products);
                }
                else if (ch == 2)
                {
                    if (pro.Count > 0)
                    {
                        for (int i = 0; i < pro.Count; i++)
                        {
                            Console.WriteLine($"Product {i + 1}");
                            pro[i].displayProducts();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No product added yet ");
                    }
                }
                else if (ch == 3)
                {
                    int totalWorth = 0;
                    foreach (var product in pro)
                    {
                        totalWorth += product.Price;
                    }
                    Console.WriteLine($"💰 Total Worth of Store: {totalWorth}");
                }
                else if (ch == 4)
                {
                    break;
                }
            }
        }
    }
}
