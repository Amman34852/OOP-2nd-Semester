using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_2
{
    internal class product
    {
        public string Name;
            public int ID;
            public string Category;
            public string BrandName;
            public string Country;
            public int Price;
            public product() { }
            public product(string name, int id, string category, string brandname, string country, int price)
            {
                Name = name;
                ID = id;
                Category = category;
                BrandName = brandname;
                Country = country;
                Price = price;
            }

            public void displayProducts()
            {
                Console.WriteLine("Product Name : " + Name);
                Console.WriteLine("Product ID : " + ID);
                Console.WriteLine("Category : " + Category);
                Console.WriteLine("BrandName : " + BrandName);
                Console.WriteLine("Country : " + Country);
                Console.WriteLine("Price : " + Price);
            }
            public int storeWorth(List<int> price)
            {
                int sum = 0;
                for (int i = 0; i < price.Count; i++)
                {
                    sum += price[i];
                }
                return sum;
            }
        }
    }

