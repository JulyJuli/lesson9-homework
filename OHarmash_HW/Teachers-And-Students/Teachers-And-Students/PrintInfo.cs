using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Teachers_And_Students
{
    internal class PrintInfo
    {
        
        internal static void ShowGeneralStat()
        {
            Console.Clear();
            var tab = "";

            Console.WriteLine("Assistant {0, -1} has {1, -3} students in group", tab, Groups.Teachers.Assistant.Count);
            Console.WriteLine("Lecturer {0, -2} has {1, -3} students in group", tab, Groups.Teachers.Lecturer.Count);
            Console.WriteLine("Docent {0, -4} has {1, -3} students in group \n", tab, Groups.Teachers.Docent.Count);
        }


        internal static void ShowDetailedStat()
        {
            Console.Clear();

            Console.WriteLine("\n  Assistant group:");
            StdOutDetailedStat(Groups.Teachers.Assistant);

            Console.WriteLine("\n  Lecturer group:");
            StdOutDetailedStat(Groups.Teachers.Lecturer);

            Console.WriteLine("\n  Docent group:");
            StdOutDetailedStat(Groups.Teachers.Docent);
        }

        internal static void StdOutDetailedStat(Dictionary<string, StudentType> TeacherGroup)
        {
            Console.WriteLine("\n  {0} group:", nameof(TeacherGroup));
            foreach (KeyValuePair<string, StudentType> student in TeacherGroup)
            {
                StudentType theStudent = student.Value;
                Console.WriteLine("Name: {0}, Age: {1}", theStudent.Name, theStudent.Age);
            }
        }

        internal static void GroupOverloaded()
        {
            Console.WriteLine("! ! ! All grpups are overloaded. Wait for next year ! ! !");
        }
    }
}
