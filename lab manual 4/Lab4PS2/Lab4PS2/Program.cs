using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4PS2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chapters = new List<string>() { "Overview", "Introduction", "History", "Progmming", "DataTypes", "Variable", "CRC"};
            Book book = new Book("C-Sharp","Abdus Salam", 400,chapters, 150, 1000, true);
            Console.WriteLine("Book Name: " + book.title);
            Console.WriteLine("Author Name: " + book.author);
            Console.WriteLine("Total page: " + book.price);
            Console.WriteLine("Price: " + book.price);
            Console.WriteLine("Is Book Available: " + book.isBookAvailable());
            Console.WriteLine("Book Mark: " + book.getBookMark());
            if (book.isBookAvailable())
            {
                Console.WriteLine("Enter the chapter number: ");
                int chap = int.Parse(Console.ReadLine());
                Console.WriteLine("The name of the chapter is: " + book.getChapter(chap));
            }
                
        }
    }
}