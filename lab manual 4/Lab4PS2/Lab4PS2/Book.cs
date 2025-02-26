using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4PS2
{
    internal class Book
    {
        public string title;
        public string author;
        public int pages;
        public List<string> chapters;
        public int bookMark;
        public int price;
        public bool isAvailable;
        public Book(string Title, string Author, int Pages, List<string> Chapters, int BookMark, int Price, bool IsAvailable)
        {
            title = Title;
            author = Author;
            pages = Pages;
            chapters = Chapters;
            bookMark = BookMark;
            price = Price;
            isAvailable = IsAvailable;
            chapters = Chapters;
        }
        public bool isBookAvailable() 
        { 
            return isAvailable;
        }
        public string getChapter(int chapterNo)
        {
            return chapters[chapterNo];
        }
        public int getBookMark()
        {
            return bookMark;
        }
    }
}
