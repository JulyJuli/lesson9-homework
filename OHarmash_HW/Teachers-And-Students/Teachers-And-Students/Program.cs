namespace Teachers_And_Students
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Preset for TESTING
            for (var i = 0; i <= 6; i++)
            {
                StudentAddNew.Generate();
            }

            //Show menu
            Menu.ShowMenu();
        }
    }
}
