using System;
using System.Collections.Generic;
using System.Linq;

namespace HW2103
{
    class Program
    {
        static void Main(string[] args)
        {
            string again;
            Console.WriteLine("Hello, this is A-Level university, please assign students to your groups\n");
            do
            {
                //Creating students, so as not to enter manually
                Console.Write("How many students do you want to create: ");
                int count = MainMethods.ValidationStr(Console.ReadLine());
                Console.Clear();
                MainMethods.GeneratoinStudent(count);

                //Sort the created list alphabetically
                MainMethods.SortStudentList();

                //Print created list
                MainMethods.PrintListStudent();                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nCreate! Total students: {Students.counter}");
                Console.ResetColor();

                //Creating trechers
                MainMethods.listTrechers = new List<Teachers>()
                {
                new Teachers("Roman", "Shuvalov", 35, (Position)1),
                new Teachers("Evgeniy", "Kolesnik", 30, (Position)2),
                new Teachers("Julia", "Nechiporuk", 25, (Position)3)
                };

                //Sort the created list enum(Position)
                MainMethods.SortTeachersList();

                //Print created list
                MainMethods.PrintListTeachers();
                Console.WriteLine();

                //Variables that limit the number of students on the list
                int maxAssistantCount = 5;
                int maxLecturerCount = 15;
                int maxDocentCount = 20;

                //Distribute to student groups
                for (int i = 0; i < MainMethods.listStudent.Count; i++)
                {

                    Console.Write($"\nTo which teacher do you want to send the student?\n");
                    Console.Write($"\nStudent - {MainMethods.listStudent[i].Print()}\n\nPress 1 - {MainMethods.listTrechers[0].Print()}\nPress 2 - {MainMethods.listTrechers[1].Print()}\nPress 3 - {MainMethods.listTrechers[2].Print()}\nYour choice: ");                    

                    int group = MainMethods.CheckPosition(MainMethods.ValidationStr(Console.ReadLine()));

                    //Adding students
                    MainMethods.AddToGroup(group, maxAssistantCount, maxDocentCount, maxLecturerCount, i);

                    int allAddedStudent = MainMethods.assistantGroup.Count() + MainMethods.docentGroup.Count() + MainMethods.lecturerGroup.Count();
                    Console.Clear();

                    //We remove from the main list of students who have already been distributed
                    MainMethods.Delete(i);
                    i--;

                    //Print student
                    MainMethods.PrintListStudent();                    

                    //Print status
                    MainMethods.PrintStatus(group, count, maxAssistantCount, maxDocentCount, maxLecturerCount, allAddedStudent);
                }
                //We print the final result 
                Console.Clear();                
                MainMethods.PrintGroup();

                //Reuse request
                Console.Write("\nPress Y to again\nPress any key to exit\nYour choice: ");
                again = Console.ReadLine();
                Console.Clear();
            } while (again.Equals("Y") || again.Equals("y"));
            
        }
    }
}
