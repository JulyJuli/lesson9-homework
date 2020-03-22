using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudProcess_DLL
{
    public class Student : Person
    {
        public override string ToString()
        {
            return $"Student {FirstName} {LastName}, member of {Group}";
        }
    }
}
