using System;
using System.Collections.Generic;
using ConsoleTableLibrary;
using ConsoleValidationLibrary;

namespace EducationalProcessAutomation
{
    class Program
    {
        private static readonly List<string> TableTitlesGroup = new List<string> { "ID", "Name", "Group Teacher", "Students Count", "Max Count" };
        private static readonly List<int> TableShiftsGroup = new List<int> {2, 15, 15, 15, 9};
        
        private static readonly List<string> TableTitlesStudent = new List<string> { "ID", "Name", "Age", "Group Teacher" };
        private static readonly List<int> TableShiftsStudent = new List<int> {2, 15, 3, 15};
        
        private static readonly List<string> TableTitlesTeacher = new List<string> { "ID", "Name", "Age", "Position", "Max Group Size" };
        private static readonly List<int> TableShiftsTeacher = new List<int> {2, 15, 3, 10, 15};
        
        static void Main(string[] args)
        {
            List<Teacher> Teachers = new List<Teacher>();
            Teachers.Add(new Teacher("Fred", 50, TeacherType.Docent));
            Teachers.Add(new Teacher("Mark", 42, TeacherType.Lecturer));
            Teachers.Add(new Teacher("Arnold", 28,TeacherType.Assistant));
            
            List<Group> Groups = new List<Group>();
            Groups.Add(new Group("Test Group 1", Teachers[0]));
            Groups.Add(new Group("Test Group 2", Teachers[1]));
            Groups.Add(new Group("Test Group 3", Teachers[2]));
            
            List<Student> Students = new List<Student>();

            for (int i = 0; i < 18; i++)
            {
                Student newStudent = new Student($"Student {i + 1}", new Random().Next(17, 25)); 
                Students.Add(newStudent);
                AddStudentToGroup(newStudent, Groups);
            }

            EducationSystem(Groups, Teachers, Students);
        }
        
        public static void EducationSystem(List<Group> Groups, List<Teacher> Teachers, List<Student> Students)
        {
            Console.Clear();
            bool exit = false;

            // navigation

            Console.WriteLine("Educational Process Automation: \n");
            Console.WriteLine("1) View Groups, Teachers, Students.");
            Console.WriteLine("2) Add Group.");
            Console.WriteLine("3) Add Teacher.");
            Console.WriteLine("4) Add Student.");
            Console.WriteLine("5) Sort Students by Teachers.");
            Console.WriteLine("6) Exit.");

            char key = Console.ReadKey(true).KeyChar;

            Console.Clear();
            switch (key)
            {
                case (char)Navigation.ViewAll:

                    ViewAll(Groups, Teachers, Students);
                    break;

                case (char)Navigation.AddGroup:

                    AddGroup(Groups, Teachers);
                    break;

                case (char)Navigation.AddTeacher:

                    AddTeacher(Teachers, Groups);
                    break;

                case (char)Navigation.AddStudent:

                    AddStudent(Students, Groups);
                    break;

                case (char)Navigation.SortStudents:

                    SortStudents(Students, Groups);
                    break;

                case (char)Navigation.Exit:
                    // Exit

                    exit = true;
                    break;

                default:
                    EducationSystem(Groups, Teachers, Students);
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Press any key.");
                Console.ReadKey();
                EducationSystem(Groups, Teachers, Students);
            }
        }

        public static void ViewAll(List<Group> Groups, List<Teacher> Teachers, List<Student> Students)
        {
            Console.WriteLine("Groups table:");
            ShowGroupsTable(Groups, Teachers);
            
            Console.WriteLine("Teachers table:");
            ShowTeachersTable(Teachers, Groups);
            
            Console.WriteLine("Students table:");
            ShowStudentsTable(Students, Groups);
        }
        
        public static void AddGroup(List<Group> Groups, List<Teacher> Teachers)
        {
            string name = ValidationLibrary.GetStringVariable("Enter group name: ");
            
            ShowTeachersTable(Teachers, Groups);
            int TeacherID = ValidationLibrary.GetNumericVariable("Enter group teacher (numbers only): ", true, Teachers.Count) - 1;
            
            Groups.Add(new Group(name, Teachers[TeacherID]));

            Console.Write("\n");
            ShowGroupsTable(Groups, Teachers);
            Console.WriteLine("\nA new group has been added.\n");
        }
        
        public static void AddTeacher(List<Teacher> Teachers, List<Group> Groups)
        {
            string name = ValidationLibrary.GetStringVariable("Enter teacher name: ");
            int age = ValidationLibrary.GetNumericVariable("Enter teacher age: ", true);
            
            int position = ValidationLibrary.GetNumericVariable("Enter teacher position (Assistant = 1, Lecturer = 2, Docent = 3): ", true, 3) - 1;

            Teachers.Add(new Teacher(name, age, (TeacherType)position));
            
            Console.Write("\n");
            ShowTeachersTable(Teachers, Groups);
            Console.WriteLine("\nA new teacher has been added.\n");
        }
        
        public static void AddStudent(List<Student> Students, List<Group> Groups)
        {
            string name = ValidationLibrary.GetStringVariable("Enter student name: ");
            int age = ValidationLibrary.GetNumericVariable("Enter student age: ", true);
            
            Student newStudent = new Student(name, age); 
            Students.Add(newStudent);
            AddStudentToGroup(newStudent, Groups);
            
            Console.Write("\n");
            ShowStudentsTable(Students, Groups);
            Console.WriteLine($"\nA new student has been added and contains in \"{Groups.Find(x => x.Students.Contains(newStudent)).Name}\" group.\n");
        }
        
        public static void SortStudents(List<Student> Students, List<Group> Groups)
        {
            Console.WriteLine("Students table:");
            ShowStudentsTable(Students, Groups);
            
            Students.Sort(delegate(Student x, Student y)
            {
                Teacher xGroupTeacher = Groups.Find(group => group.Students.Contains(x)).GroupTeacher;
                Teacher yGroupTeacher = Groups.Find(group => group.Students.Contains(y)).GroupTeacher;
                if (xGroupTeacher.Name == null && yGroupTeacher.Name == null) return 0;
                if (xGroupTeacher.Name == null) return -1;
                if (yGroupTeacher.Name == null) return 1;
                return xGroupTeacher.Name.CompareTo(yGroupTeacher.Name);
            });
            
            Console.WriteLine("Sorted students table by teachers:");
            ShowStudentsTable(Students, Groups);
        }
        
        public static void AddStudentToGroup(Student newStudent, List<Group> Groups)
        {
            bool added = false;
            foreach (var group in Groups)
            {
                if (group.GroupTeacher.MaxGroupSize > group.Students.Count && !added)
                {
                    group.Students.Add(newStudent);
                    added = true;
                    return;
                }
            }

            if (!added)
            {
                Console.WriteLine($"Student \"{newStudent.Name}\" was not added to any of the groups. All groups are full.");
            }
        }
        
        public static void ShowGroupsTable(List<Group> Groups, List<Teacher> Teachers)
        {
            ConsoleTable table = new ConsoleTable(
                TableTitlesGroup,
                TableShiftsGroup
            );

            foreach (Group group in Groups)
            {
                table.Add(new string[]{
                    (Groups.IndexOf(group) + 1).ToString(),
                    group.Name,
                    group.GroupTeacher.Name,
                    group.Students.Count.ToString(),
                    group.GroupTeacher.MaxGroupSize.ToString()
                });
            }

            Console.WriteLine(table.ToString());
        }

        public static void ShowStudentsTable(List<Student> Students, List<Group> Groups)
        {
            ConsoleTable tableStudent = new ConsoleTable(
                TableTitlesStudent,
                TableShiftsStudent
            );

            foreach (Student student in Students)
            {
                tableStudent.Add(new string[]{
                    (Students.IndexOf(student) + 1).ToString(),
                    student.Name,
                    student.Age.ToString(),
                    Groups.Find(x => x.Students.Contains(student)).GroupTeacher.Name
                });
            }

            Console.WriteLine(tableStudent.ToString());
        }

        public static void ShowTeachersTable(List<Teacher> Teachers, List<Group> Groups)
        {
            ConsoleTable tableTeacher = new ConsoleTable(
                TableTitlesTeacher,
                TableShiftsTeacher
            );

            foreach (Teacher teacher in Teachers)
            {
                tableTeacher.Add(new string[]{
                    (Teachers.IndexOf(teacher) + 1).ToString(),
                    teacher.Name,
                    teacher.Age.ToString(),
                    teacher.Position.ToString(),
                    teacher.MaxGroupSize.ToString()
                });
            }

            Console.WriteLine(tableTeacher.ToString());
        }
    }
}