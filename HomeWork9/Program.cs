using System;
using System.Collections.Generic;
using UniversityLibrary;

namespace HomeWork9
{
    class Program
    {       
        static void Main(string[] args)
        {
            Teacher docent = new Teacher("Gennadiy", "Petrov", 45, TeacherCategory.docent);
            Teacher assistant = new Teacher("Natalia", "Ivanova", 33, TeacherCategory.assistant);
            Teacher lecturer = new Teacher("Maria", "Ptushkina", 50, TeacherCategory.lecturer);

            List<Teacher> teachers = new List<Teacher>() { docent, assistant, lecturer };

            Console.WriteLine("Teachers:\n");
            foreach (var item in teachers)
            {
                Console.WriteLine(item.ToString());
            }

            List<Student> students = new List<Student>()
            {new Student("Alina", "Gromova", 20),
             new Student("Olga", "Pushkina", 22),
             new Student("Maxim", "Savinov", 19),
             new Student("Ksenia", "Ivanchenko", 23),
             new Student("Petr", "Denisov", 24),
             new Student("Aleksej", "Alioshin", 21),
             new Student("Marina", "Kostina", 20),
             new Student("Oksana", "Kostina", 20),
             new Student("Grigorij", "Kulikova", 20),
             new Student("Daria", "Anisimova", 20),
             new Student("Tatiana", "Custenko", 25),
             new Student("Ihor", "Bortnyj", 22),
             new Student("Alisa", "Liapina",19),
             new Student("Andrej", "Shevchenko", 24),
             new Student("Yulia", "Bohuta", 23)};

            Console.WriteLine("\nStudents:\n");

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].ToString()}");
            }

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"\nPlease, select in wich group do you want to add the current student\n\n{students[i].ToString()}\n\n\"1\" - add to Docent group\n\"2\" - add to Assistant group\n\"3\" - add to Lecturer group\n");
                string selectKey = Console.ReadLine();
                students[i].Studentgroup = Distribution.AddStudent(students[i], selectKey);             
            }
            Console.Clear();
            Distribution.PrintInfo();

            Console.WriteLine("\nStudents:\n");

            PrintInfoStudentsInGroups(students, docent, assistant, lecturer);

            Console.WriteLine("\nTeachers after sorting:\n");

            SortItems.SortTeachers(teachers);

            foreach (var item in teachers)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        public static void PrintInfoStudentsInGroups(List<Student> students, Teacher docent, Teacher assistant, Teacher lecturer)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Studentgroup == StudentGroup.docentGroup)
                {
                    Console.WriteLine($"{i + 1}. {students[i].ToString()} {students[i].Studentgroup}:\t {docent.ToString()}");
                }

                if (students[i].Studentgroup == StudentGroup.assistantGroup)
                {
                    Console.WriteLine($"{i + 1}. {students[i].ToString()}{students[i].Studentgroup}:\t {assistant.ToString()}");
                }

                if (students[i].Studentgroup == StudentGroup.lecturerGroup)
                {
                    Console.WriteLine($"{i + 1}. {students[i].ToString()}{students[i].Studentgroup}:\t {lecturer.ToString()}");
                }
            }
        }  
    }
}


