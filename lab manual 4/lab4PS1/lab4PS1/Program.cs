using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace lab4PS1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.name = "Amman";
            student.rollNumber = 9;
            student.cgpa = 3.4f;
            student.matricMarks = 1089;
            student.fscMarks = 988;
            student.ecatMarks = 276;
            student.homeTown = "Lahore";
            student.isHostelite = false;
            student.isTakingScholarship = false;
            Console.WriteLine("Student Name: " + student.name);
            Console.WriteLine("Aggregate: " + student.calculateMerit() + "%");
            Console.WriteLine("Eligible for scholarship: " + student.isEligibleforScholarship(student.calculateMerit()));
    }
    }
}
