using System.Collections.Generic;

namespace EducationalProcessAutomation
{
    public class Group
    {
        public string Name { get; set; }
        public Teacher GroupTeacher { get; set; }
        public List<Student> Students = new List<Student>();
        
        public Group(string name, Teacher teacher)
        {
            Name = name;
            GroupTeacher = teacher;
        }
    }
}