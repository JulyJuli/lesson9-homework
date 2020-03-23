using System;
using System.Collections.Generic;
using System.Linq;

namespace HW2103
{
    class MainMethods
    {
        //Create static list
        public static List<Students> listStudent = new List<Students>();
        public static List<Students> ListCopyStudents = new List<Students>();
        public static List<Students> assistantGroup = new List<Students>();
        public static List<Students> docentGroup = new List<Students>();
        public static List<Students> lecturerGroup = new List<Students>();
        public static List<Teachers> listTrechers = new List<Teachers>();
        

        //Generation student
        public static void GeneratoinStudent(int count)
        {
            Random rndName = new Random();
            Random rndAge = new Random();

            for (int i = 0; i < count; i++)
            {
                var stud = new Students(Convert.ToString((Firstname)rndName.Next(1, 15)), Convert.ToString((Surnames)rndName.Next(1, 15)), rndAge.Next(18, 40), "Programmist");
                Add(stud);
            }
        }
        //Sorting list
        public static void SortStudentList ()
        {

            listStudent.Sort(delegate (Students student1, Students student2)
            { 
                return student1.Firstname.CompareTo(student2.Firstname); 
            });           

        }
        //Sorting list
        public static void SortTeachersList()
        {

            listTrechers.Sort(delegate (Teachers teachers1, Teachers teachers2)
            {
                return Convert.ToString(teachers1.Po).CompareTo(Convert.ToString(teachers2.Po));
            });

        }
        
        //Print list student
        public static void PrintListStudent()
        {
            Console.WriteLine("Students list:\n");
            for (int i = 0; i < listStudent.Count; i++)
            {
                int number = i + 1;
                string strNumber = Convert.ToString(number) + ")";
                Console.WriteLine($"{strNumber.PadRight(3)} {listStudent[i].Print()}");
            }
        }
        //Print list teachers
        public static void PrintListTeachers()
        {
            Console.WriteLine("\nTrechers list:\n");
            for (int i = 0; i < listTrechers.Count; i++)
            {                
                int number = i + 1;
                string strNumber = Convert.ToString(number) + ")";
                Console.WriteLine($"{strNumber.PadRight(3)} {listTrechers[i].Print()}");
            }
        }

        //Delete methods 
        public static void Delete(int delete)
        {
            listStudent.RemoveAt(delete);
        }

        //Delete add 
        public static void Add(Students student)
        {
            listStudent.Add(student);
        }

        //Check for entering a number
        public static int ValidationStr(string str)
        {
            int number;
            while (!int.TryParse(str, out number))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Insert the number. Try again: ");
                Console.ResetColor();
                str = Console.ReadLine();
            }
            return number;
        }

        //Checking the correct choice of teacher
        public static int CheckPosition(int number)
        {
            int maxTeachers = 3;
            int minTeachers = 1;
            while (number > maxTeachers || number < minTeachers)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("No such position. Try again: ");
                number = ValidationStr(Console.ReadLine());
                Console.ResetColor();
            }
            return number;
        }
        //We show the process of adding
        public static void PrintStatus(int group, int count, int maxAssistantCount, int maxDocentCount, int maxLecturerCount, int allAddedStudent)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nStudent added to group: {listTrechers[group - 1].Print()} group\n");
            Console.ResetColor();
            Console.WriteLine($"Status:\nAll student {allAddedStudent} of {count}\nAssistant group: {assistantGroup.Count()} of {maxAssistantCount}\nDocent group: {docentGroup.Count()} of {maxDocentCount}\nLecturer group: {lecturerGroup.Count()} of {maxLecturerCount}");
            
        }
        //Print goup, if one of the sheets is empty it will not print
        public static void PrintGroup()
        {
            if (assistantGroup.Count() > 0)
            {
                Console.WriteLine($"\nGroup: {listTrechers[0].Print()} complete:\n");
                {
                    for (int i = 0; i < assistantGroup.Count(); i++)
                    {
                        int number = i + 1;
                        string strNumber = Convert.ToString(number) + ")";
                        Console.WriteLine($"{strNumber.PadRight(3)} {assistantGroup[i].Print()}");
                    }
                }
            }
           
            if (docentGroup.Count() > 0)
            {
                Console.WriteLine($"\nGroup: {listTrechers[1].Print()} complete:\n");
                {
                    for (int i = 0; i < docentGroup.Count(); i++)
                    {
                        int number = i + 1;
                        string strNumber = Convert.ToString(number) + ")";
                        Console.WriteLine($"{strNumber.PadRight(3)} {docentGroup[i].Print()}");
                    }
                }
            }
            if (lecturerGroup.Count() > 0)
            {
                Console.WriteLine($"\nGroup: {listTrechers[2].Print()} complete:\n");
                {
                    for (int i = 0; i < lecturerGroup.Count(); i++)
                    {
                        int number = i + 1;
                        string strNumber = Convert.ToString(number) + ")";
                        Console.WriteLine($"{strNumber.PadRight(3)} {lecturerGroup[i].Print()}");
                    }
                }
            }            
        }

        //Adding students by Group
        public static void AddToGroup (int group, int maxAssistantCount, int maxDocentCount, int maxLecturerCount, int i)
        {
            switch (group)
            {
                case 1:
                    {
                        if (assistantGroup.Count() < maxAssistantCount)
                        {
                            assistantGroup.Add(listStudent[i]);
                        }
                        else
                        {
                            if (group == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Assistant group max 5 student, set other gruop: ");
                                Console.ResetColor();
                                group = CheckPosition(ValidationStr(Console.ReadLine()));
                                AddToGroup(group, maxAssistantCount, maxDocentCount, maxLecturerCount, i);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        if (docentGroup.Count() < maxDocentCount)
                        {
                            docentGroup.Add(listStudent[i]);
                        }
                        else
                        {
                            if (group == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Docent group max 20 student, set other gruop:");
                                Console.ResetColor();
                                group = CheckPosition(ValidationStr(Console.ReadLine()));
                                AddToGroup(group, maxAssistantCount, maxDocentCount, maxLecturerCount, i);
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        if (lecturerGroup.Count() < maxLecturerCount)
                        {
                            lecturerGroup.Add(listStudent[i]);
                        }
                        else
                        {
                            if (group == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Docent group max 15 student, set other gruop:");
                                Console.ResetColor();
                                group = CheckPosition(ValidationStr(Console.ReadLine()));
                                AddToGroup(group, maxAssistantCount, maxDocentCount, maxLecturerCount, i);
                            }
                        }
                        break;
                    }
            }
        }
    }
}
