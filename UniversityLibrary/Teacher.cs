
namespace UniversityLibrary
{
    public class Teacher : Human
    {
        public Teacher(string firstName, string lastName, int age, TeacherCategory teacherCategory) : base(firstName, lastName, age)
        {
            _teacherCategory = teacherCategory;
        }

        private TeacherCategory _teacherCategory;

        public TeacherCategory TeacherCategory
        {
            get => _teacherCategory;
            set
            {
                if (teacherCategoryValid((int)value))
                    _teacherCategory = value;
            }
        }

        public int CountOfStudentsInGroup { get; }

        private bool teacherCategoryValid(int teacherCategory)
        {
            return teacherCategory > 0 && teacherCategory < 4;
        }

        public override string ToString()
        {
            return $"{TeacherCategory}  \t{FirstName}    \t{LastName}  \t{Age} years";
        }
    }
}
