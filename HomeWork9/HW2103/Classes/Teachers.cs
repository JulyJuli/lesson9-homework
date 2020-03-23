using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2103
{
    public class Teachers : Person
    {
        public static int counter = 0;
        public Teachers (string firstname, string surname, int age, Position po) : base (firstname, surname, age)
        {
            Po = po;
            counter++;
        }
        public Position Po { get; }             

        public override string Print()
        {
            return $"Name: {Firstname.PadRight(7)} Surname: {Surname.PadRight(10)} Age: {Age} Position: {Po}";
        }
    }
}
