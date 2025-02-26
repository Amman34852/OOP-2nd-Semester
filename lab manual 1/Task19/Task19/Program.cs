using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\dell\\Desktop\\Task19\\test.txt";
            StreamWriter fileVariable = new StreamWriter(path, true);
            fileVariable.WriteLine("Hello AK");
            fileVariable.Flush();
            fileVariable.Close();
        }
    }
}
