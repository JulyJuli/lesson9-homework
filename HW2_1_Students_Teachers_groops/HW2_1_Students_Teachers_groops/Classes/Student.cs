using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_1_Students_Teachers_groops.Classes
{
    public class Student: Person
    {        
        public override EnmPersonRole PersonRole => EnmPersonRole.PrsnStudent;        
        public int Group { get; set; }
        public Student(string fName, string lName, EnmTeacherRole teacherRole) : base(fName, lName, teacherRole)
        {
            Group = (int)teacherRole;
        }

        public override string ToString()
        {
            return $"First name {FirstName,10}|Last name {LastName,12}|--{PersonRole,10}| group:{Group,4}";
        }
    
    }
}
