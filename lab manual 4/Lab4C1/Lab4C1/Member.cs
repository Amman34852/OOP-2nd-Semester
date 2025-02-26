using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4C1
{
    internal class Member
    {
        public string Name;
        public int MemberID;
        public List<string> BooksBought;
        public int NumberOfBooksBought;
        public double MoneyInBank;
        public double AmountSpent;
        public Member(string name, int memberId)
        {
            Name = name;
            MemberID = memberId;
            BooksBought = new List<string>();
            NumberOfBooksBought = 0;
            MoneyInBank = 0;
            AmountSpent = 0;
        }
        public Member()
        {
            Name = null;
            MemberID = 0;
            BooksBought = new List<string>();
            NumberOfBooksBought = 0;
            MoneyInBank = 0;
            AmountSpent = 0;
        }

        public void DisplayMember()
        {
            Console.WriteLine($"Name: {Name}\nMember ID: {MemberID}\nBooks Bought: {NumberOfBooksBought}\nAmount Spent: {AmountSpent}\n");
        }
        public bool MatchesQuery(string query)
        {
            return Name.Equals(query, StringComparison.OrdinalIgnoreCase) || MemberID.ToString().Equals(query, StringComparison.OrdinalIgnoreCase);
        }
        public void updateNM(string newName, int newId)
        {
            Name = newName;
            MemberID = newId;
            Console.WriteLine("Member name or id changed successfully");
        }
    }
}
