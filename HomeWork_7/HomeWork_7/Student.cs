using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{
    public class Student
    {

        public Student(string studentName)
        {
            StudentName = studentName;
        
        }
        public string StudentName { get; set; }
                 
    }
    public class Teacher
    {        
        public Teacher(string teacherName)
        {
            TeacherName = teacherName;


        }
        public string TeacherName { get; set; }

    }
}
