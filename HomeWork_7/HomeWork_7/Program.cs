using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{
     static class Program
    {
        static void Main(string[] args)
        {         

            List<Teacher> teachers = new List<Teacher>(2);
            teachers.Add(new Teacher("fffffffffff"));
           

            List<Student> students = new List<Student>(4);
            students.Add(new Student( "aaaaaaaaaaa"));
            students.Add(new Student("bbbbbbbbbbb"));
            students.Add(new Student("ccccccccccc"));
            students.Add(new Student("ddddddddddd"));

            List<Group> groups = new List<Group>();

            Console.WriteLine(groups.ToString());

            //foreach (Teacher t in teachers)
            //{
            //    Console.WriteLine($"Teacher: {t.TeacherName}");
            //}

            //foreach (Student s in students)
            //{
            //    Console.WriteLine($"Student: {s.StudentName}");
            //}
            Console.ReadKey();   
            
            
        }
        public static string ToString(this List<Group>groups)
        {
            string result = string.Empty;
            foreach(Group g in groups)
            {
                result = $"{g.Teachers.ToString()},{g.Students.ToString()}" ;// пока не получилось вывести, но я еще разберусь с этим.(
            }
            return result;
        }
    }
}
