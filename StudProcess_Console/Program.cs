using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudProcess_DLL;

namespace StudProcess_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            Person[] docentGroup = new Person[4];
            Person[] lecturerGroup = new Person[3];
            Person[] assistantGroup = new Person[2];

            Person[][] groupsList = new Person[3][] { docentGroup, lecturerGroup, assistantGroup };

            Teacher docent = new Teacher("Denis", "Dubchenko", Teacher.Groups.DocentGroup);
            docentGroup[0] = docent;

            Teacher lecturer = new Teacher("Leonid", "Leschenko", Teacher.Groups.LecturerGroup);
            lecturerGroup[0] = lecturer;

            Teacher assistant = new Teacher("Andrey", "Artamonov", Teacher.Groups.AssistantGroup);
            assistantGroup[0] = assistant;

            string input;

            do
            {
                Console.WriteLine("================== MENU ==================");
                Console.WriteLine("Enter 'student' to add a new student.");
                Console.WriteLine("Enter 'view' to view the list student groups.");
                Console.WriteLine("Enter 'end' to finish working with the app.");

                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "student":
                        Student student = CreateStudent();

                        switch ((int)student.Group)
                        {
                            case 1:
                                AddStudentToGroup(student, assistantGroup);

                                break;
                            case 2:
                                AddStudentToGroup(student, lecturerGroup);
                                
                                break;
                            case 3:
                                AddStudentToGroup(student, docentGroup);
                                
                                break;
                        }

                        Console.WriteLine();
                        break;
                    case "view":
                        ViewList(groupsList);

                        Console.WriteLine();

                        break;
                    case "end":
                        return;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            } while (input.Equals("end") == false);
        }

        public static Student CreateStudent()
        {
            Student student = new Student();

            Console.Write("Etner student's first name: ");
            student.FirstName = Console.ReadLine();

            Console.Write("Etner student's last name: ");
            student.LastName = Console.ReadLine();

            Console.WriteLine("Enter student's group number:\n1 - AssistantGroup\n2 - LecturerGroup\n3 - DocentGroup");
            student.Group = (Student.Groups)int.Parse(Console.ReadLine());

            return student;
        }

        public static void ViewList(Person[][] groupsArray)
        {
            foreach(Person[] group in groupsArray)
            {
                foreach(Person person in group)
                {
                    if (person != null)
                    {
                        int index = Array.IndexOf(group, person);
                        Console.WriteLine($"{index + 1}. {person.ToString()}");
                    }                   
                }
                Console.WriteLine();
            }
        }

        public static void AddStudentToGroup(Student student, Person[] studentGroup)
        {
            int index = Array.FindIndex(studentGroup, stud => stud == null);
            if (index == -1)
            {
                Console.WriteLine("This group is already full!");
            }
            else
            {
                studentGroup[index] = student;
                Console.WriteLine($"The student {student.FirstName} {student.LastName} was added to group '{student.Group}'");
            }
        }
    }
}
