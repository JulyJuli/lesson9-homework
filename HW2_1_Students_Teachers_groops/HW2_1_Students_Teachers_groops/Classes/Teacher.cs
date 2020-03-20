using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_1_Students_Teachers_groops.Classes
{
    public class Teacher : Person
    {
        //private EnmTeacherRole _teacherRole;
        private int _quantityInGroup;
        public override EnmPersonRole PersonRole => EnmPersonRole.PrsnTeacher;
        
        public TechersGroup Group{ get; set; }
        public Teacher(string fName, string lName, EnmTeacherRole teacherRole, TechersGroup group, int quant) :base(fName, lName,  teacherRole)
        {
            QuantityStdntsInGroup = quant; 
            Group = group;
        }

        public int QuantityStdntsInGroup
        {
            get { return _quantityInGroup; }
            set
            {
                if (TeacherRole == EnmTeacherRole.Professor)
                {
                    value = 5;
                    _quantityInGroup = value;
                }
                if (TeacherRole == EnmTeacherRole.Assistant)
                {
                    value = 6;
                    _quantityInGroup = value;
                }
                if (TeacherRole == EnmTeacherRole.lector)
                {
                    value = 3;
                    _quantityInGroup = value;
                }                
            }
        }

        public override string ToString()
        {
            return $"First name {FirstName,10}|Last name {LastName,12}|-- {TeacherRole,10}| maxCauntInGroup={QuantityStdntsInGroup,4}";//{PersonRole,10} :
        }

        public class TechersGroup
        {
            private List<Person> group =new List<Person>();

            public int CountInGroup
            {
                get { return group.Count; }                                
            }

            public void PrintGroup()
            {
                foreach(var item in group)
                    Console.WriteLine(item);
            }
            public void AddToGroup(Person ones)
            {                
                group.Add(ones);               
            }
           
            public List<Person>GetGroup()
            {
                return group;
            }
        }
    }
}
