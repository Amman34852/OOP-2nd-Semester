using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\dell\\Desktop\\Task20\\test.txt";
            string[] names = new string[5];
            string[] password = new string[5];
            int option;
            do
            {
                readData(path, names, password);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    signIn(n, p, names, password);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter New Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                }
            }
            while (option < 3);
            Console.Read();
        }
        static int menu()
        {
            int option;
            Console.WriteLine("1.Sign In");
            Console.WriteLine("2.Sign Up");
            Console.WriteLine("Enter option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void readData(string path, string[] name, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while((record = fileVariable.ReadLine()) != null)
                {
                    name[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exist");
            }
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static void signIn(string n, string p, string[] name, string[] password)
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                if (n == name[i] && p == password[i])
                {
                    Console.WriteLine("Valid user");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("invalid user");
            }
            Console.ReadKey();
        }
        static void signUp(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
    }
}
