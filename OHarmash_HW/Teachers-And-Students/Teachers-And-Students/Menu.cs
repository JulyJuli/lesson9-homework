using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teachers_And_Students
{
    internal static class Menu
    {
        internal enum Actions
        {
            Exit,
            ShowGeneralStat,
            ShowDetailedStat,
            Automation,
            Interactive
        }


        internal static void ShowMenu()
        {
            string message = "\n" +
                "Make choice for required action \n" +
                "0) EXIT \n" +
                "1) Show General statistic \n" +
                "2) Show detatiled statistic \n" +
                "3) Add new student (automated action) \n" +
                "4) Add new student (Interactive)";

            Console.WriteLine(message);
            var readAction = Console.ReadKey(true).KeyChar.ToString();
            Enum.TryParse<Actions>(readAction, out Actions userChoice);

            switch (userChoice)
            {
                case Actions.ShowGeneralStat:
                    PrintInfo.ShowGeneralStat();
                    ShowMenu();
                    return;
                case Actions.ShowDetailedStat:
                    PrintInfo.ShowDetailedStat();
                    ShowMenu();
                    return;
                case Actions.Automation:
                    AddStudent.Generate();
                    ShowMenu();
                    return;
                case Actions.Interactive:
                    AddStudent.Interactive();
                    ShowMenu();
                    return;
                case Actions.Exit:
                    return;
                default:
                    return;
            }

        }
    }
}
