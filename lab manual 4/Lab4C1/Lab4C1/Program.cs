using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4C1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            List<Member> members = new List<Member>();
            int option = 0;
            while (option != 10)
            {
                Console.Clear();
                Console.WriteLine("*************************BOOK STORE****************************");
                Console.WriteLine("1.Show all books");
                Console.WriteLine("2.Add Book");
                Console.WriteLine("3.Search Book");
                Console.WriteLine("4.Update Book Stock");
                Console.WriteLine("5.Add a Member");
                Console.WriteLine("6.Search for a Member");
                Console.WriteLine("7.Update Member Information");
                Console.WriteLine("8.Purchase a Book");
                Console.WriteLine("9.Display Total Sales and Membership Stats");
                Console.WriteLine("10.Exit");
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    Console.Clear();
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No book available.");
                    }
                    foreach (var book in books)
                    {
                        book.DisplayBook();
                    }
                    Console.ReadKey();
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Book book121 = new Book();
                    Console.Write("Enter Title: ");
                    book121.Title = Console.ReadLine();
                    Console.Write("Enter number of authors (max 4): ");
                    book121.NoOfAuthors = int.Parse(Console.ReadLine());
                    for (int i = 0; i < book121.NoOfAuthors; i++)
                    {
                        Console.Write($"Enter Author {i + 1}: ");
                        book121.Authors[i] = Console.ReadLine();
                    }
                    Console.Write("Enter Publisher: ");
                    book121.Publisher = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    book121.ISBN = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    book121.Price = double.Parse(Console.ReadLine());
                    Console.Write("Enter Stock: ");
                    book121.Stock = int.Parse(Console.ReadLine());
                    books.Add(book121);
                    Console.WriteLine("Book added successfully");
                }
                else if (option == 3)
                {
                    Console.Clear();
                    Console.Write("Enter Title or ISBN to search: ");
                    string query = Console.ReadLine();
                    Book book = books.Find(b => b.MatchesQuery(query));
                    if (book != null)
                        book.DisplayBook();
                    else
                        Console.WriteLine("Book not found.\n");
                    Console.ReadKey();
                }
                else if (option == 4)
                {
                    Console.Clear();
                    Console.Write("Enter ISBN to update stock: ");
                    string isbn = Console.ReadLine();
                    Book book = books.Find(b => b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));

                    if (book != null)
                    {
                        Console.Write("Enter new stock quantity: ");
                        int newStock = int.Parse(Console.ReadLine());
                        book.UpdateStock(newStock);
                    }
                    else
                        Console.WriteLine("Book not found.\n");
                }
                else if (option == 5)
                {
                    Member member = new Member();
                    Console.Clear();
                    Console.Write("Enter Name: ");
                    member.Name = Console.ReadLine();
                    Console.Write("Enter Member ID (0 for non-member): ");
                    member.MemberID = int.Parse(Console.ReadLine());
                    members.Add(member);
                    Console.WriteLine("Member added successfully!\n");
                }
                else if (option == 6)
                {
                    Console.Clear();
                    Console.Write("Enter Name or Member ID: ");
                    string query = Console.ReadLine();
                    List<Member> nonMembers = members.FindAll(m => m.MatchesQuery(query));
                    if (nonMembers != null)
                    {
                        foreach (var member in nonMembers)
                        {
                            member.DisplayMember();
                        }
                    }
                    else
                        Console.WriteLine("Member not found.\n");
                    Console.ReadKey();
                }
                else if (option == 7)
                {
                    Console.Clear();
                    Console.Write("Enter Name or Member ID to update: ");
                    string query = Console.ReadLine();
                    Member member = members.Find(m => m.MatchesQuery(query));
                    if (member != null)
                    {
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new MemberID: ");
                        int newID = int.Parse(Console.ReadLine());
                        member.updateNM(newName, newID);
                    }
                    else
                        Console.WriteLine("Member not found.\n");

                }
                else if (option == 8)
                {
                    Console.Clear();
                    Console.Write("Enter Buyer Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Member ID (0 for non-member): ");
                    int memberId = int.Parse(Console.ReadLine());

                    // Search for the member
                    Member member = members.Find(m => m.MemberID == memberId && m.Name == name);
                    bool isMember = member != null;

                    // If the member doesn't exist and is not a non-member (ID != 0), add them to the list
                    if (!isMember && memberId == 0)
                    {
                        member = new Member(name, memberId);
                        members.Add(member);
                    }

                    // Search for the book
                    Console.Write("Enter ISBN of the book to purchase: ");
                    string isbn = Console.ReadLine();
                    Book book = books.Find(b => b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));

                    if (book == null)
                    {
                        Console.WriteLine("❌ Book not found.\n");
                        Console.ReadKey();
                        return;
                    }

                    // Get the quantity
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    if (book.Stock < quantity)
                    {
                        Console.WriteLine("Not enough stock available.\n");
                        Console.ReadKey();
                        return;
                    }

                    // Calculate total cost
                    double totalCost = book.Price * quantity;

                    // Apply 5% discount only for members
                    if (isMember)
                    {
                        totalCost *= 0.95;

                        // Ensure `BooksBought` list is initialized
                        if (member.BooksBought == null)
                        {
                            member.BooksBought = new List<string>();
                        }

                        member.NumberOfBooksBought += quantity;
                        member.BooksBought.Add(book.Title);

                        // Apply membership benefit (every 11th book free)
                        if (member.NumberOfBooksBought % 11 == 0)
                        {
                            double avgCost = totalCost / 10;
                            totalCost -= avgCost;
                        }

                        // Update member's total amount spent
                        member.AmountSpent += totalCost;
                    }
                    else if(!isMember)
                    {

                        if (member.BooksBought == null)
                            member.BooksBought = new List<string>();

                        member.NumberOfBooksBought += quantity;
                        member.BooksBought.Add(book.Title);
                        member.AmountSpent += totalCost;
                    }

                    // Reduce stock after purchase
                    book.Stock -= quantity;

                    Console.WriteLine($"Purchase successful! Total Cost: ${totalCost:F2}\n");
                    Console.ReadKey();



                }
                else if (option == 9)
                {
                    Console.Clear();
                    int totalMembers = members.Count(m => m.MemberID != 0);
                    double totalMembershipFee = totalMembers * 50;

                    // Calculate total revenue from sold books, not remaining stock
                    double totalSales = members.Sum(m => m.AmountSpent);

                    Console.WriteLine($"Total Members: {totalMembers}");
                    Console.WriteLine($"Total Membership Fees Collected: ${totalMembershipFee:F2}");
                    Console.WriteLine($"Total Sales from Books: ${totalSales:F2}\n");
                    Console.ReadKey();
                }
                else if (option == 10)
                {
                    break;
                }

            }
        }
    }
}