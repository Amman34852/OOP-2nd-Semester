using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_LAB_3
{
    class products
    {
        public string productName;
        public string Category;
        public long Price;
        public long Quantity;
        public long MinimumQuantity;
        public products() { }
        public products(string productname , string category , long price , long quantity ,long minimumquantity)
        {
            productName = productname;
            Category = category;
            Price = price;
            Quantity = quantity;
            MinimumQuantity = minimumquantity;
        }
        public void showAllProducts()
        {
            Console.WriteLine("Name : "+productName);
            Console.WriteLine("Category : "+Category);
            Console.WriteLine("Price : " +Price);
            Console.WriteLine("Quantity : "+Quantity);
            Console.WriteLine("Minimum Quantity : "+MinimumQuantity);
        }
        public int maxUnitProduct(List<long> price)
        {
            long max = price[0];
            int maxi = 0;
            for (int i = 1; i < price.Count; i++)
            {
                if(max < price[i])
                {
                    max = price[i];
                    maxi = i;
                }
            }
            return maxi;
        }
        public void salesTax(List<products> product)
        {
            double salesTax =0;
            for (int i = 0; i < product.Count; i++)
            {
                if (product[i].Category == "Grocery" || product[i].Category == "grocery")
                {
                    salesTax = product[i].Price *0.1;
                }
                else if (product[i].Category == "fruit" || product[i].Category == "Fruit")
                {
                    salesTax = product[i].Price*0.05;
                }
                else
                {
                    salesTax = product[i].Price*0.15;
                }
                Console.WriteLine("Product Name : " + product[i].productName +" Sales Tax : "+ salesTax);
            }
        }
        public void productToBeOrdered(List<products> product)
        {
            Console.WriteLine("Products to be ordered are :");
            for(int i=0; i<product.Count; i++)
            {
                if (product[i].Quantity < product[i].MinimumQuantity)
                {
                    Console.WriteLine(product[i].productName);
                }
            }
        }
    }
    internal class Challenge__2
    {
        static void Main(string[] args)
        {
             string productName;
             string Category;
             long Price;
             long Quantity;
             long MinimumQuantity;
            products Products = new products();
            List<long> price = new List<long>();
            List<string> category = new List<string>();
            List <products> product = new List <products> ();
            while (true)
            {
                int ch;
                Console.WriteLine("1.Add Product.");
                Console.WriteLine("2.View All Product.");
                Console.WriteLine("3.Find Product with the Highest Unit Price");
                Console.WriteLine("4.View Sales Tax of All Products.");
                Console.WriteLine("5.Products to be Ordered.");
                Console.WriteLine("6.Exit");
                ch = int.Parse (Console.ReadLine());
                if (ch == 1)
                {
                    Console.WriteLine("Enter the name of product : ");
                    productName = Console.ReadLine();
                    Console.WriteLine("Enter the Category");
                    Category = Console.ReadLine();
                    Console.WriteLine("Enter the price : ");
                    Price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the quantity");
                    Quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter ther minimum quantity");
                    MinimumQuantity = int.Parse(Console.ReadLine());
                    products Product = new products(productName, Category, Price, Quantity, MinimumQuantity);
                    product.Add(Product);
                }
                else if (ch == 2)
                {
                    for (int i = 0; i < product.Count; i++)
                    {
                        Console.WriteLine($"product {i+1}");
                        product[i].showAllProducts();
                    }
                }
                else if(ch == 3)
                {
                    for(int i = 0;i < product.Count; i++)
                    {
                        price.Add(product[i].Price) ;
                    }
                    Console.WriteLine($"Product with highest unit price is : {product[Products.maxUnitProduct(price)].productName}");
                }
                else if(ch == 4)
                {
                    Products.salesTax(product);

                }
                else if (ch==5)
                {
                    Products.productToBeOrdered(product);
                }
                else if(ch==6)
                {
                    break;
                }
            }
        }
    }
}
