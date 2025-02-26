using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4C4
{
    internal class Student
    {
        public string Name;
        public int Age;
        public double FSCMarks;
        public double ECATMarks;
        public List<string> Preferences = new List<string>();
        public string AdmissionStatus;
        public List<Subject> RegisteredSubjects = new List<Subject>();
        public double TotalFees;
    }
}
