using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_2
{
    public class ATM
    {
        public double balance;
        List <string> transactionHistory = new List<string>();
        public ATM() 
        {
            balance = 0;
        }
        public void deposit(double amount)
        {
            balance = balance + amount;
            transactionHistory.Add("Amount Deposited " + amount);
            Console.WriteLine("Amount : " + amount + " deposited successfully !");
        }
        public void withdraw(double amount)
        {
            if (amount < balance)
            {
                balance -= amount;
                transactionHistory.Add("Amount deducted " + amount);
                Console.WriteLine("Amount : " + amount + "deducted successfully !");

            }
            else
            {
                Console.WriteLine("Balance is not enough");
            }
        }
        public void check_balance()
        {
            Console.WriteLine("Current balance is : " + balance);
        }
        public void transaction_history()
        {
            if (transactionHistory.Count > 0)
            {
                Console.WriteLine("Transaction History ");
                for (int i = 0; i<transactionHistory.Count; i++)
                {
                    Console.WriteLine(transactionHistory[i]);
                }
            }
            else
            {
                Console.WriteLine("No Any transactions Yet");
            }
        }
        internal class Task3
        {
            static void Main(string[] args)
            {
                ATM atm = new ATM();
                while (true)
                {
                    int choice;
                    Console.WriteLine("1.Deposit amount");
                    Console.WriteLine("2.Withdraw amount");
                    Console.WriteLine("3.Check balace");
                    Console.WriteLine("4.Transaction history");
                    Console.WriteLine("5.Exit");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.WriteLine("Enter the amount you want to deposit");
                        double amount =double.Parse(Console.ReadLine());
                        atm.deposit(amount);
                        Console.ReadKey();
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Enter the amount you want to Withdraw");
                        double amount = double.Parse(Console.ReadLine());
                        atm.withdraw(amount);
                        Console.ReadKey();
                    }
                    else if (choice == 3)
                    {
                        atm.check_balance();
                        Console.ReadKey();
                    }
                    else if (choice == 4)
                    {
                        atm.transaction_history();
                        Console.ReadKey();
                    }
                    else if(choice == 5)
                    {
                        break;
                    }
                }
            }
        }
    }
}