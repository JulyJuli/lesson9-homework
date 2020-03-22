using System;
using System.Collections.Generic;


namespace UniversityLibrary
{
    public static class Distribution
    {
        static int countDocentGroup = 0;
        static int countAssistantGroupp = 0;
        static int countLecturerGroup = 0;

        static List<Student> docentGroup = new List<Student>();
        static List<Student> assistantGroup = new List<Student>();
        static List<Student> lecturerGroup = new List<Student>();

        public static StudentGroup AddStudent(Student student, string selectKey)
        {
            int limitDocentGroup = 3;
            int limitAssistantGroup = 5;
            int limitLecturerGroup = 7;

            bool isAddToGroup;

            do
            {
                isAddToGroup = true;
                switch (selectKey)
                {
                    case "1":
                        {
                            if (countDocentGroup < limitDocentGroup)
                            {
                                docentGroup.Add(student);
                                countDocentGroup++;
                                Console.WriteLine($"{student.ToString()} were added to Docent group");
                                student.Studentgroup = StudentGroup.docentGroup;

                            }
                            else
                            {
                                Console.WriteLine("There are no places in this group. Would you like to add a student to another group? Press 2 or 3");
                                selectKey = Console.ReadLine();
                                isAddToGroup = false;
                            }
                            break;
                        }

                    case "2":
                        {
                            if (countAssistantGroupp < limitAssistantGroup)
                            {
                                assistantGroup.Add(student);
                                countAssistantGroupp++;
                                Console.WriteLine($"{student.ToString()} were added to Assistant group");
                                student.Studentgroup = StudentGroup.assistantGroup;
                            }
                            else
                            {
                                Console.WriteLine("There are no places in this group. Would you like to add a student to another group? Press 1 or 3");
                                selectKey = Console.ReadLine();
                                isAddToGroup = false;
                            }
                            break;
                        }
                    case "3":
                        {
                            if (countLecturerGroup < limitLecturerGroup)
                            {
                                lecturerGroup.Add(student);
                                countLecturerGroup++;
                                Console.WriteLine($"{student.ToString()} were added to Lecturer group");
                                student.Studentgroup = StudentGroup.lecturerGroup;
                            }
                            else
                            {
                                Console.WriteLine("There are no places in this group. Would you like to add a student to another group? Press 1 or 2");
                                selectKey = Console.ReadLine();
                                isAddToGroup = false;
                            }
                            break;
                        }
                }
            }
            while (isAddToGroup == false);

            return student.Studentgroup;
        }

        public static void PrintInfo()
        {
            Console.WriteLine($"\n{countDocentGroup} students were added to Docent group:\n");

            foreach (var item in docentGroup)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine($"\n{countAssistantGroupp} students were added to Assistant group:\n");

            foreach (var item in assistantGroup)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine($"\n{countLecturerGroup} students were added to Lecturer group:\n");

            foreach (var item in lecturerGroup)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
