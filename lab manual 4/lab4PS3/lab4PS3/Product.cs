using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4PS3
{
    internal class Product
    {
        public string Name;
        public string Category;
        public int Price;
        public float CalculateTax()
        {
            float taxRate;
            if (Category == "electronics")
                taxRate = 0.5f; 
            else if (Category == "clothing")
                taxRate = 0.08f; 
            else if (Category== "grocery")
                taxRate = 0.02f; 
            else
                taxRate = 0.10f; 
            return Price * taxRate;
        }

    }
}
