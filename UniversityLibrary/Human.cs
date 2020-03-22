using System;

namespace UniversityLibrary
{
    public abstract class Human
    {
        public Human(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _firstName = value;
                }
            }
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _lastName = value;
                }
            }
        }


        private int _age;

        public int Age
        {
            get => _age;
            set
            {
                if (ageValid(value))
                    _age = value;
            }
        }
        private static bool ageValid(int age)
        {
            return age > 0 && age < 99;
        }
    }
}
