using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{
    public class Group
    {
        public Group(string nameOfGroup,Student studentName,Teacher teacherName)
        {
            NameOfGroup = nameOfGroup;
            Student StudentName = studentName;
            Teacher TeacherName = teacherName;

        }
        public string NameOfGroup { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }



       
    }


}
