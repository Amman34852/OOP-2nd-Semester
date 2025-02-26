using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab4C4
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<Student> students = new List<Student>();
           List<DegreeProgram> degree = new List<DegreeProgram>();

        int option = 0;
        while (option != 8)
        {
            Console.Clear();
            Console.WriteLine("1.Add Student");
            Console.WriteLine("2.Add Degree Program");
            Console.WriteLine("3.Generate Merit");
            Console.WriteLine("4.View Registered Students");
            Console.WriteLine("5.View Students of a Specific Program");
            Console.WriteLine("6.Register Subjects for a Specific Student");
            Console.WriteLine("7.Calculate Fee for All Registered Students");
            Console.WriteLine("8.Exit");
            Console.Write("Select an option: ");
            option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                Console.Clear();
                Student student = new Student();
                Console.Write("Enter Student Name: ");
                student.Name = Console.ReadLine();
                Console.Write("Enter Student Age: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter Student FSc Marks: ");
                student.FSCMarks = int.Parse(Console.ReadLine());
                Console.Write("Enter Student ECAT Marks: ");
                student.ECATMarks = int.Parse(Console.ReadLine());
                student.Preferences = new List<string>();
                Console.WriteLine("Available Degree Programs:");
                foreach (var program in degree)
                {
                    Console.WriteLine(program.DegreeTitle);
                }
                Console.Write("Enter number of preferences: ");
                int preferencesCount = int.Parse(Console.ReadLine());
                for (int i = 0; i < preferencesCount; i++)
                {
                    Console.Write($"Enter Preference {i + 1}: ");
                    string preference = Console.ReadLine();
                    student.Preferences.Add(preference);
                }
                student.AdmissionStatus = "Not Admitted";
                students.Add(student);
                Console.WriteLine("Student added successfully! Press any key to continue...");
                Console.ReadKey();
            }
            else if (option == 2)
            {
                Console.Clear();
                DegreeProgram degreeProgram = new DegreeProgram();
                Console.Write("Enter Degree Name: ");
                degreeProgram.DegreeTitle = Console.ReadLine();
                Console.Write("Enter Degree Duration (years): ");
                degreeProgram.Duration = int.Parse(Console.ReadLine());
                Console.Write("Enter Available Seats: ");
                degreeProgram.seats = int.Parse(Console.ReadLine());
                degreeProgram.Subjects = new List<Subject>();
                Console.Write("Enter number of subjects: ");
                int subjectCount = int.Parse(Console.ReadLine());
                for (int i = 0; i < subjectCount; i++)
                {
                    Subject subject = new Subject();
                    Console.Write("Enter Subject Code: ");
                    subject.code = Console.ReadLine();
                    Console.Write("Enter Subject Type: ");
                    subject.subjectType = Console.ReadLine();
                    Console.Write("Enter Subject Credit Hours: ");
                    subject.creditHours = int.Parse(Console.ReadLine());
                    Console.Write("Enter Subject Fees: ");
                    subject.fees = int.Parse(Console.ReadLine());
                    degreeProgram.Subjects.Add(subject);
                }
                degree.Add(degreeProgram);
                Console.WriteLine("Degree program added successfully!");
                Console.ReadKey();
            }
            else if (option == 3)
            {
                Console.Clear();
                students.Sort((s1, s2) =>
                    (((s2.FSCMarks * 70) / 1100 + (s2.ECATMarks * 30) / 400)).CompareTo((s1.FSCMarks * 70) / 1100 + (s1.ECATMarks * 30) / 400));

                foreach (var s in students)
                {
                    double merit = ((s.FSCMarks * 70) / 1100) + ((s.ECATMarks * 30) / 400);
                    foreach (var program in degree)
                    {
                        if (s.Preferences.Contains(program.DegreeTitle) && program.seats > 0)
                        {
                            s.AdmissionStatus = $"Admitted to {program.DegreeTitle} (Merit: {merit:F2})";
                            program.seats--;
                            break;
                        }
                    }
                    if (string.IsNullOrEmpty(s.AdmissionStatus))
                    {
                        s.AdmissionStatus = $"Not Admitted (Merit: {merit:F2})";
                    }
                }
                Console.WriteLine("Final Merit List:");
                foreach (var st in students)
                {
                    Console.WriteLine($"{st.Name}: {st.AdmissionStatus}");
                }
                Console.ReadKey();
            }
            else if (option == 4)
            {
                Console.Clear();
                Console.WriteLine("Registered Students:");
                foreach (var stu in students)
                {
                    Console.WriteLine($"Name: {stu.Name}, Age: {stu.Age}, FSc Marks: {stu.FSCMarks}, ECAT Marks: {stu.ECATMarks}");
                }
                Console.ReadKey();
            }
            else if (option == 5)
            {
                Console.Clear();
                Console.Write("Enter Degree Program Name: ");
                string programName = Console.ReadLine();

                Console.WriteLine($"Students admitted in {programName}:");
                bool found = false;

                foreach (var stu in students)
                {
                    if (stu.AdmissionStatus.Contains(programName))
                    {
                        Console.WriteLine($"{stu.Name}");
                        found = true;
                    }
                }

                if (!found)
                    Console.WriteLine("No students found in this program.");

                Console.ReadKey();
            }
            else if (option == 6)
            {
                Console.Clear();
                Console.Write("Enter Student Name: ");
                string studentName = Console.ReadLine();
                Student stu = students.Find(s => s.Name.Equals(studentName, StringComparison.OrdinalIgnoreCase));
                if (stu == null || stu.AdmissionStatus.StartsWith("Not Admitted"))
                {
                    Console.WriteLine("Student not found or not admitted to any program.");
                    Console.ReadKey();
                    continue;
                }
                string admittedProgram = stu.AdmissionStatus.Replace("Admitted to ", "").Split(' ')[0];
                DegreeProgram program = degree.Find(p => p.DegreeTitle == admittedProgram);
                if (program == null)
                {
                    Console.WriteLine("Error: Admitted program not found.");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine($"Available Subjects for {admittedProgram}:");
                foreach (var sub in program.Subjects)
                {
                    Console.WriteLine($"- {sub.code}: {sub.subjectType} ({sub.creditHours} Credit Hours, Fees: {sub.fees})");
                }
                Console.Write("Enter the number of subjects to register (Max 9 Credit Hours): ");
                int count = int.Parse(Console.ReadLine());
                int totalCreditHours = 0;
                stu.RegisteredSubjects = new List<Subject>();
                while (count-- > 0)
                {
                    Console.Write("Enter Subject Code: ");
                    string code = Console.ReadLine();

                    Subject sub = program.Subjects.Find(s => s.code == code);
                    if (sub != null && (totalCreditHours + sub.creditHours) <= 9)
                    {
                        stu.RegisteredSubjects.Add(sub);
                        totalCreditHours += sub.creditHours;
                    }
                    else
                    {
                        Console.WriteLine("Invalid subject or exceeding credit limit.");
                    }
                }
                Console.WriteLine("Subjects registered successfully!");
                Console.ReadKey();
            }
            else if (option == 7)
            {
                Console.Clear();
                foreach (var stu in students)
                {
                    stu.TotalFees = 0;
                    foreach (var sub in stu.RegisteredSubjects)
                    {
                        stu.TotalFees += sub.fees;
                    }

                    Console.WriteLine($"{stu.Name}   Total Fees: {stu.TotalFees}");
                }

                Console.ReadKey();
            }
            else if (option == 8)
            {
                break;
            }
            }
        }
    }
}

