using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4PS3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.CustomerName = "Amman";
            customer.CustomerAddress = "Islampura";
            customer.CustomerContact = "123";
            Product computer = new Product();
            computer.Name = "Computer";
            computer.Category = "electronics";
            computer.Price = 12000;
            Product pent = new Product();
            pent.Name = "Pent";
            pent.Category = "clothing";
            pent.Price = 12000;
            customer.AddProduct(computer);
            customer.AddProduct(pent);
            Console.WriteLine("Customer details: ");
            Console.WriteLine("Name: " + customer.CustomerName);
            Console.WriteLine("Address: " + customer.CustomerAddress);
            Console.WriteLine("Contact: " + customer.CustomerContact);
            Console.WriteLine("Product details: ");
            foreach(var product in customer.GetAllProducts())
            {
                Console.WriteLine($"{product.Name}   {product.Price}    {product.CalculateTax()}" );
            }
            Console.WriteLine("Total Tax: " + customer.totalTax());




        }
    }
}
