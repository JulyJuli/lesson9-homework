using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_1_Students_Teachers_groops.Classes
{
     public class ListOfPerson
    {
        public List<Person> PrsnList;

        public ListOfPerson()
        {
            PrsnList = new List<Person>();
        }

        public void AddPerson (Person one)
        {
            PrsnList.Add(one);
        }

        public void AddRangeOfPerson (List<Person> persons)
        {
            foreach (var ones in persons)
                PrsnList.Add(ones);
        }

        public void AddRangeOfStudents(List<Person> persons)
        {
            foreach (var ones in persons)
            {
                PrsnList.Add(ones);                
            } 
        }

        public bool AddRangeToGroupsForHurdCode(Teacher.TechersGroup profGr, Teacher.TechersGroup lectGr, 
            Teacher.TechersGroup assistGr)
        {
            int maxCountInProfGroup = 5;
            int maxCountInLectGroup = 3;
            int maxCountInAssistGroup = 6;
            bool IsAddedToGroup = true;
            for (int i = 0; i < PrsnList.Count; i++)
            {
                if ((int)PrsnList[i].TeacherRole == 1 && profGr.CountInGroup <= maxCountInProfGroup)
                {
                    profGr.AddToGroup(PrsnList[i]);
                }
                else if ((int)PrsnList[i].TeacherRole == 2 && lectGr.CountInGroup <= maxCountInLectGroup)
                {
                    lectGr.AddToGroup(PrsnList[i]);
                }
                else if ((int)PrsnList[i].TeacherRole == 3 && assistGr.CountInGroup <= maxCountInAssistGroup)
                {
                    assistGr.AddToGroup(PrsnList[i]);
                }
                else
                    IsAddedToGroup = false;
            }
            return IsAddedToGroup;
        }

        public void PrintList()
        {
            foreach (var ones in PrsnList)
                Console.WriteLine(ones);
        }

        public List<Person> GetList()
        {
            return PrsnList;
        }

        public List<Person> GetProfGroupByNumOfStdntGroup()
        {           
            List<Person> sortListByGroup = new List<Person>();
            for (int i = 0; i < PrsnList.Count; i++)
            {
                if (PrsnList[i].TeacherRole == EnmTeacherRole.Professor)
                    sortListByGroup.Add(PrsnList[i]);
            }            
                return sortListByGroup;
        }

        public List<Person> GetAssistGroupByNumOfStdntGroup()
        {           
            List<Person> sortListByGroup = new List<Person>();
            for (int i = 0; i < PrsnList.Count; i++)
            {
                if (PrsnList[i].TeacherRole == EnmTeacherRole.Assistant)
                    sortListByGroup.Add(PrsnList[i]);
            }
            return sortListByGroup;
        }

        public List<Person> GetLectureGroupByNumOfStdntGroup()
        {
            List<Person> sortListByGroup = new List<Person>();
            for (int i = 0; i < PrsnList.Count; i++)
            {
                if (PrsnList[i].TeacherRole == EnmTeacherRole.lector)
                    sortListByGroup.Add(PrsnList[i]);
            }
            return sortListByGroup;
        }

    }
}
 