using System.Collections.Generic;

namespace Teachers_And_Students
{
    internal class Groups
    {
        internal class Teachers
        {
            //Available teachers
            public static Dictionary<string, StudentType> Assistant = new Dictionary<string, StudentType>();
            public static Dictionary<string, StudentType> Lecturer = new Dictionary<string, StudentType>();
            public static Dictionary<string, StudentType> Docent = new Dictionary<string, StudentType>();
        }

        internal class Limits
        {
            //Group limits
            public static int AssistantLimit = 5;
            public static int LecturerLimit = 15;
            public static int DocentLimit = 20;
        }
    }
}
