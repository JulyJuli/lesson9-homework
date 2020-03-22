using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudProcess_DLL
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public enum Groups
        {
            AssistantGroup = 1,
            LecturerGroup,
            DocentGroup
        }
        public Groups Group { get; set; }
    }
}
