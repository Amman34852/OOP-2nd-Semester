using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_2
{
    class student
    {
        public string Name;
        public int matricMarks;
        public int fscMarks;
        public float ecatMarks;
        public student() { }
        public student(string name, int MatricMarks, int FscMarks, float EcatMarks)
        {
            Name = name;
            matricMarks = MatricMarks;
            fscMarks = FscMarks;
            ecatMarks = EcatMarks;
        }

        public void displayStudent()
        {
            Console.WriteLine("Student Name : " + Name);
            Console.WriteLine("Matric Marks : "+matricMarks);
            Console.WriteLine("FSC Marks : "+fscMarks);
            Console.WriteLine("Ecat Marks : "+ecatMarks);
        }
        public double aggregate()
        {
            double aggragate;
            aggragate = ((0.2*matricMarks)/1100 + (0.5*fscMarks)/1200 + (0.3*ecatMarks)/400)*100;
            return aggragate;
        }
        public List<int> topStudents(List<double> aggregate)
        {
            List<int> top = new List<int>();
            for (int j = 0; j < 3; j++)
            {
                double max = -1; 
                int maxIndex = -1;
                for (int i = 0; i < aggregate.Count; i++)
                {
                    if (aggregate[i] > max)
                    {
                        max = aggregate[i];
                        maxIndex = i;
                    }
                }
                top.Add(maxIndex);
                aggregate[maxIndex] = 0;
            }
            return top;
        }
    }
    internal class Challenge___1
    {
       
        static void Main(string[] args)
        {
            List <double> aggregate = new List<double>();
             string Name;
             int matricMarks;
             int fscMarks;
             int ecatMarks;
            student Student = new student();
            List <student> students = new List <student>();
            while (true)
            {
                int ch;
                Console.WriteLine("1.ADD Student ");
                Console.WriteLine("2.Display Student");
                Console.WriteLine("3.calculate aggregate");
                Console.WriteLine("4.Top students");
                Console.WriteLine("5.Exit");
                ch = int.Parse(Console.ReadLine());
                if (ch == 1)
                {
                    Console.WriteLine("Enter the student name ");
                    Name = Console.ReadLine();
                    Console.WriteLine("Enter the matric marks ");
                    matricMarks = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter fsc marks ");
                    fscMarks = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter ecat marks ");
                    ecatMarks = int.Parse(Console.ReadLine());
                    student student = new student(Name ,matricMarks,fscMarks,ecatMarks );
                    students.Add(student);
                }
                else if (ch == 2)
                {
                    if(students.Count>0)
                    {
                        for(int i =0; i<students.Count;i++)
                        {
                            Console.WriteLine($"student {i+1}");
                            students[i].displayStudent();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No student added yet ");
                    }
                }
                else if (ch == 3)
                {
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine($"student {i + 1}");
                        aggregate.Add(students[i].aggregate());
                        Console.WriteLine($"Aggregate : {aggregate[i]}");
                    }
                }
                else if (ch == 4)
                {
                    List <int> top  = Student.topStudents(aggregate);
                    Console.WriteLine("Top students ARE :");
                    Console.WriteLine("Top 1 : " + students[top[0]].Name);
                    Console.WriteLine("Top 2 : " + students[top[1]].Name);
                    Console.WriteLine("Top 3 : " + students[top[2]].Name);
                }
                else if (ch == 5) 
                {
                    break;
                }
            }
        }
    }
}
