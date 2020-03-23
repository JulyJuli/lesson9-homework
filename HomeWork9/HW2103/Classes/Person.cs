namespace HW2103
{
    abstract public class Person
    {

        public Person(string firstname, string surname, int age)
        {
            Firstname = firstname;
            Surname = surname;
            Age = age;
        }

        public string Firstname { get; }
        public string Surname { get; }
        public int Age { get; }

        public virtual string Print()
        {
            return $"{Firstname} {Surname} {Age}";

        }
    }
}
