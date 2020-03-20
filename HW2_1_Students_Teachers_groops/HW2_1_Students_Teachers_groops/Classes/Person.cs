using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_1_Students_Teachers_groops.Classes
{
    public abstract class Person
    {
        private string _firstName;
        public Person(string fName, string lName, EnmTeacherRole teacherRole)
        {
            FirstName= fName;
            LastName = lName;
            TeacherRole = teacherRole;           
        }

        public EnmTeacherRole TeacherRole { get; set; }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _firstName = value;
                    //isInputedFirstNameValid = true;
                }
                else
                {
                    PrintValidMes($"{nameof(FirstName)}", value);
                }
            }
        }

        protected void PrintValidMes(string propertyName, string value)
        {
            Console.WriteLine($"{propertyName} {value} is invalid. Try again.");
        }

        public string LastName { get; set; }

        public abstract EnmPersonRole PersonRole { get;}// set; 

        public override string ToString()
        {
            return $"First name {FirstName,10}|Last name {LastName,12}|--{PersonRole,10}";
        }

    }
}
