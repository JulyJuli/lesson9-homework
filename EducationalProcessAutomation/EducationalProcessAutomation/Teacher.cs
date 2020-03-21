using System.Collections.Generic;

namespace EducationalProcessAutomation
{
    public class Teacher
    {
        private int _maxGroupSize = 0;
        public string Name { get; set; }
        public int Age { get; set; }
        public TeacherType Position { get; set; }

        public int MaxGroupSize
        {
            get => _maxGroupSize;
            set
            {
                switch (value)
                {
                    case (int)TeacherType.Assistant:

                        _maxGroupSize = (int) TeacherSize.Assistant;
                        break;

                    case (int)TeacherType.Docent:

                        _maxGroupSize = (int) TeacherSize.Docent;
                        break;

                    case (int)TeacherType.Lecturer:

                        _maxGroupSize = (int) TeacherSize.Lecturer;
                        break;

                    default:

                        _maxGroupSize = 0;
                        break;
                }
            }
        }

        public Teacher(string name, int age, TeacherType position)
        {
            Name = name;
            Age = age;
            Position = position;
            MaxGroupSize = (int)position;
        }
    }
}