using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4PS1
{
    internal class Student
    {
      public string name;
      public int rollNumber;
      public float cgpa;
      public int matricMarks;
      public int fscMarks;
      public int ecatMarks;
      public string homeTown;
      public bool isHostelite;
      public bool isTakingScholarship;
      public float calculateMerit()
        {
            return ((60 * fscMarks / 1100) + (40 * ecatMarks / 400));
        }
      public bool isEligibleforScholarship(float meritPercentage)
        {
            return (meritPercentage > 80 && isHostelite);
        }
    }
}
