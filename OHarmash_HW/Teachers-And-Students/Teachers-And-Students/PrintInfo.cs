using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Teachers_And_Students
{
    internal static class PrintInfo
    {
        
        internal static void ShowGeneralStat()
        {
            Console.Clear();

            var assistantStudent = Groups.Assistant.Count;
            var lecturerStudent = Groups.Lecturer.Count;
            var docentStudent = Groups.Docent.Count;
            var tab = "";

            Console.WriteLine("Assistant {0, -1} has {1, -3} students in group", tab, assistantStudent);
            Console.WriteLine("Lecturer {0, -2} has {1, -3} students in group", tab, lecturerStudent);
            Console.WriteLine("Docent {0, -4} has {1, -3} students in group \n", tab, docentStudent);
        }


        internal static void ShowDetailedStat()
        {
            Console.Clear();

            Console.WriteLine("\n  Assistant group:");
            foreach (KeyValuePair<string, Student> student in Groups.Assistant)
            {
                Student theStudent = student.Value;
                Console.WriteLine("Name: {0}, Age: {1}", theStudent.Name, theStudent.Age);
            }

            Console.WriteLine("\n  Lecturer group:");
            foreach (KeyValuePair<string, Student> student in Groups.Lecturer)
            {
                Student theStudent = student.Value;
                Console.WriteLine("Name: {0}, Age: {1}", theStudent.Name, theStudent.Age);
            }

            Console.WriteLine("\n  Docent group:");
            foreach (KeyValuePair<string, Student> student in Groups.Docent)
            {
                Student theStudent = student.Value;
                Console.WriteLine("Name: {0}, Age: {1}", theStudent.Name, theStudent.Age);
            }
        }

        internal static void GroupOverloaded()
        {
            Console.WriteLine("! ! ! All grpups are overloaded. Wait for next year ! ! !");
        }
    }
}
