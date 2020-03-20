using HW2_1_Students_Teachers_groops.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_1_Students_Teachers_groops
{
    class Program
    {
        public static int ReadNumberForMenu(int itemOfMenu)
        {
            int number = 0;
            while (!int.TryParse(Console.ReadLine(), out number) || number < 0 || number > itemOfMenu)
            {
                PrntErrMes();
            }
            return number;
        }

        public static void PrntErrMes()
        {
            Console.WriteLine("Wrong format!! Try again...");
        }

        public static void PrntErrMes1()
        {
            Console.WriteLine("No free teacheres!!");
        }
        public static void PrntErrMes2(EnmTeacherRole numGroup, Teacher.TechersGroup a)
        {
            Console.WriteLine($"This student will be added in {numGroup}'s group, count persons in group is" +
                $" {a.CountInGroup} now");
        }

        public static string ValidSttring(string input)
        {
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Incorrect! Your string is empty! Try again!");
                //Console.WriteLine($"Input {nameof(input)}");
                input = Console.ReadLine();
            }
            return input;
        }
        public static string PrntContinueMenu(string anothItem)
        {
            Console.WriteLine("Do you want to continue? (press y/n)");
            anothItem = Console.ReadLine();

            while ((anothItem != "y") && (anothItem != "n"))
            {
                PrntErrMes();
                Console.WriteLine("Do you want to continue? (press y/n)");
                anothItem = Console.ReadLine();
            }
            return anothItem;
        }

        static void Main(string[] args)
        {
            string anotherItem = "y";
           
            var teachersList = new ListOfPerson();
            var studentsList = new ListOfPerson();
            var profGroup = new Teacher.TechersGroup();
            //profGroup.AddToGroup(new Student("ilia", "Smirnij", EnmTeacherRole.Professor));

            var assistGroup = new Teacher.TechersGroup();
            var lectGroup = new Teacher.TechersGroup();
            lectGroup.AddToGroup(new Student("fffff", "ffffff", EnmTeacherRole.lector));

            var professor = new Teacher("Andrey", "Smirnov", EnmTeacherRole.Professor, profGroup, 0);
            var lector = new Teacher("Oleg", "Petrov", EnmTeacherRole.lector, lectGroup, 0);
            var assistant = new Teacher("Svetlana", "Onishenko", EnmTeacherRole.Assistant, assistGroup, 0);
            teachersList.AddRangeOfPerson(new List<Person> { professor, lector, assistant });

            //var newTeacher = new Teacher("Elena", "Karpova", EnmTeacherRole.Assistant, new Teacher.TechersGroup(),0);

            studentsList.AddRangeOfPerson(
                new List<Person> {
                    new Student("Irina","Smirnova",EnmTeacherRole.Assistant),
                    new Student("Oleg","Vavilov",EnmTeacherRole.Professor),
                    new Student("Svetlana","Jarovaja",EnmTeacherRole.Assistant),
                    new Student("Katya","Rud",EnmTeacherRole.lector),
                    new Student("Marija","Rudova",EnmTeacherRole.lector),
                    new Student("Evgen","Shmat",EnmTeacherRole.Assistant),
                    new Student("Petr","Zirka",EnmTeacherRole.Professor),
                    new Student("Kiril","Pudov",EnmTeacherRole.Professor),
                    new Student("Ivan","Likov",EnmTeacherRole.Assistant),
                });
            if (studentsList.AddRangeToGroupsForHurdCode(profGroup, lectGroup, assistGroup) == false)
            {
                PrntErrMes1();
            }
            int itemsOfMenu = 8;
            Console.WriteLine("\tYou are in the \"Programm to create and add student to group\":\n");
            do
            {
                Console.WriteLine("You can choose your action:\n\t1- Create new student & add item into the base of students & add to teacher\n" +
                    "\t\t(professor has 5 students in group, assistant-6, lectures-3;" +
                       "\n\t2- Print all students;\n\t3- Print all teachers;\n\t4- Print professor's group;" +
                       "\n\t5- Print lecture's group;\n\t6- Print assistant's group;\n\t7- Sort base of teachers by pozition;" +
                       "\n\t8- Exit the program;");
                int chooseNum = ReadNumberForMenu(itemsOfMenu);
                switch (chooseNum)
                {
                    case (1):
                        Console.WriteLine("Please input first name of student:");
                        string firstName = Console.ReadLine();
                        firstName=ValidSttring(firstName);
                        Console.WriteLine("Please input last name of student:");
                        string lastName = Console.ReadLine();
                        lastName=ValidSttring(lastName);
                        EnmTeacherRole numGroup = LibMethods.CheckNumOgGroup(out bool IsFindGroup, profGroup, lectGroup,
                            assistGroup, professor, lector, assistant);
                        if (IsFindGroup == false)
                            PrntErrMes1();
                       
                        Student newStdnt = new Student(firstName, lastName, numGroup);
                        studentsList.AddPerson(newStdnt);

                        if ((int)numGroup == 1)
                        {
                            profGroup.AddToGroup(newStdnt);
                            PrntErrMes2(numGroup, profGroup);
                        }
                        else if ((int)numGroup == 2)
                        {
                            lectGroup.GetGroup().Add(newStdnt);
                            PrntErrMes2(numGroup, lectGroup);
                        }
                        else if ((int)numGroup == 3)
                        {
                            assistGroup.GetGroup().Add(newStdnt);
                            PrntErrMes2(numGroup, assistGroup);
                        }
                        anotherItem = PrntContinueMenu(anotherItem);
                        break;

                    case (2):
                        Console.WriteLine("\n\tDate Base of students:\n");
                        studentsList.PrintList();
                        Console.WriteLine("\n\n");
                        anotherItem = PrntContinueMenu(anotherItem);
                        break;

                    case (3):
                        Console.WriteLine("\n\tDate Base of teachers:\n");
                        teachersList.PrintList();
                        anotherItem = PrntContinueMenu(anotherItem);
                        break;

                    case (4):                        
                        Console.WriteLine($"\n\tProfessor's group ({profGroup.CountInGroup}prs," +
                            $" {professor.QuantityStdntsInGroup - profGroup.CountInGroup} places free):\n");
                        profGroup.PrintGroup();
                        anotherItem = PrntContinueMenu(anotherItem);
                        break;

                    case (5):
                        Console.WriteLine($"\n\tLector's group ({lectGroup.CountInGroup}prs, " +
                            $"{lector.QuantityStdntsInGroup - lectGroup.CountInGroup} places free):\n");
                        lectGroup.PrintGroup();                        
                        anotherItem = PrntContinueMenu(anotherItem);
                        break;

                    case (6):
                        Console.WriteLine($"\n\tAssistant's group ({assistGroup.CountInGroup}prs," +
                            $" {assistant.QuantityStdntsInGroup - assistGroup.CountInGroup} places free):\n");
                        assistGroup.PrintGroup();                       
                        anotherItem = PrntContinueMenu(anotherItem);
                        break;

                    case (7):
                        LibMethods.SortByTeacherRole(teachersList);
                        teachersList.PrintList();
                        anotherItem = PrntContinueMenu(anotherItem);
                        break;

                    case (8):
                        anotherItem = "n";
                        break;
                }
            }
            while (anotherItem == "y");
            Console.WriteLine("The end!");

        }
    }
}
