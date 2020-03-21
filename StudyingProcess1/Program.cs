using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingProcess1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Students list in group1, Professor: ");
            ProcessOptional.Professor();
            Console.WriteLine($"\nStudents list in group2, Lecturer: ");
            ProcessOptional.Lecturer();
            Console.WriteLine($"\nStudents list in group3, Assistant: ");
            ProcessOptional.Assistant();
            Console.WriteLine($"\nSorting: ");
            ProcessOptional.Sorting();

            Console.ReadLine(); 
        }
    }
}
