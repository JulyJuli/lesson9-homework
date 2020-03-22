using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teachers_And_Students
{
    internal static class Groups
    {
        //Available teachers
        public static Dictionary<string, Student> Assistant = new Dictionary<string, Student>();
        public static Dictionary<string, Student> Lecturer = new Dictionary<string, Student>();
        public static Dictionary<string, Student> Docent = new Dictionary<string, Student>();

        //Group limits
        public static int AssistantLimit = 5;
        public static int LecturerLimit = 15;
        public static int DocentLimit = 20;
    }


    internal class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }


}
