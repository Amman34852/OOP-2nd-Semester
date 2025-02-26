using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4C1
{
    internal class Book
    {
        public string Title;
        public string[] Authors = new string[4];
        public string Publisher;
        public string ISBN;
        public double Price;
        public int Stock;
        public int NoOfAuthors;
        public void DisplayBook()
        {
            Console.WriteLine($"Title: {Title}, Authors: {string.Join(", ",Authors)}, Publisher: {Publisher}, ISBN: {ISBN}, Price: {Price:C}, Stock: {Stock}\n");
        }
        public bool MatchesQuery(string query)
        {
            return Title.Equals(query, StringComparison.OrdinalIgnoreCase) || ISBN.Equals(query, StringComparison.OrdinalIgnoreCase);
        }
        public void UpdateStock(int newStock)
        {
            Stock = newStock;
            Console.WriteLine("Stock updated successfully!\n");
        }
    }
}
