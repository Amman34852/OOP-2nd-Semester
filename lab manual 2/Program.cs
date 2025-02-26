using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_2
{
    class Transaction
    {
        public int TransactionId;
        public string ProductName;
        public float Amount;
        public string Date;
        public string Time;
        public Transaction() { }
        public Transaction(Transaction trans)
        {
            TransactionId = trans.TransactionId;
            ProductName = trans.ProductName;
            Amount = trans.Amount;
            Date = trans.Date;
            Time = trans.Time;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Transaction transaction = new Transaction();
            transaction.TransactionId = 123;
            transaction.ProductName = "ABC";
            transaction.Amount = 100;
            transaction.Date = "26 - 1 - 24";
            transaction.Time = "12:00 am";
            Transaction transaction1 = new Transaction(transaction);
            Console.WriteLine(transaction.ProductName);
            Console.WriteLine(transaction1.ProductName);
            Console.ReadKey();
        }
    }
}
