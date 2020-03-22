
namespace UniversityLibrary
{
    public class Student : Human
    {
        public Student(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public Student(string firstName, string lastName, int age, StudentGroup studentGroup) : base(firstName, lastName, age)
        {
            Studentgroup = studentGroup;
        }
        public StudentGroup Studentgroup { get; set; }

        public override string ToString()
        {
            return $"{FirstName}   \t{LastName}    \t{Age}years";
        }
    }
}
