using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4PS3
{
    internal class Customer
    {
        public string CustomerName;
        public string CustomerAddress;
        public string CustomerContact;
        public List<Product> Products = new List<Product>();
        public void AddProduct(Product p)
        {
            Products.Add(p);
        }
        public List<Product> GetAllProducts()
        {
            return Products;
        }
        public float totalTax()
        {
            float tax = 0f;
            foreach (var product in Products)
            {
                tax += product.CalculateTax();
            }
            return tax;
        }
    }
}
