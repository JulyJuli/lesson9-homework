using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingProcess1
{
    class ProcessOptional
    {
        static string[] group1;
        static string[] group2;
        static string[] group3;
        public static void Professor()
        {
            string[] students1 = new string[] { "Petrov", "Ivanov", "Popova", "Badalov", "Budnik", "Radchenko", "Dmitrenko", "Nechaev" };
            group1 = new string[8];
            students1.CopyTo(group1, 0);
            foreach (var i in group1)
            {
                Console.WriteLine(i);
            }
        }
        public static void Lecturer()
        {
            string[] students2 = new string[] { "Kolubelova", "Tarareeva", "Babaev", "Petrenko" };
            group2 = new string[4];
            students2.CopyTo(group2, 0);
            foreach (var i in group2)
            {
                Console.WriteLine(i);
            }
        }
        public static void Assistant()
        {
            string[] students3 = new string[] { "Kriat", "Boichenko" };
            group3 = new string[2];
            students3.CopyTo(group3, 0);
            foreach (var i in group3)
            {
                Console.WriteLine(i);
            }
        }
        public static void Sorting()
            {
            Array.Sort(group1);
            Console.WriteLine("Group1:");
            foreach (var i in group1)
            {
                Console.WriteLine(i);
            }
            Array.Sort(group2);
            Console.Write("\nGroup2:\n");
            foreach (var j in group2)
            {
                Console.WriteLine(j);
            }
            Array.Sort(group3);
            Console.Write("\nGroup3:\n");
            foreach (var y in group3)
            {
                Console.WriteLine(y );
            }
        }
    }
}
