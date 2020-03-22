using System;
using System.Collections.Generic;

namespace UniversityLibrary
{
    public class SortItems
    {
        public static List<Teacher> SortTeachers(List<Teacher> teachers)
        {
            Teacher item;
            for (int i = 0; i < teachers.Count; i++)
            {
                for (int j = 0; j < teachers.Count - i - 1; j++)
                {
                    int result = Convert.ToString(teachers[j].TeacherCategory).CompareTo(Convert.ToString(teachers[j + 1].TeacherCategory));

                    if (result > 0)
                    {
                        item = teachers[j + 1];
                        teachers[j + 1] = teachers[j];
                        teachers[j] = item;
                    }
                }
            }
            return teachers;
        }
    }
}
