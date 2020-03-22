using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudProcess_DLL
{
    public class Teacher : Person
    {
        public Teacher(string firstName, string lastName, Groups group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Group = group;
        }

        public override string ToString()
        {
            return $"Teacher {FirstName} {LastName}, curator of {Group}.";
        }
    }
}
