using HW2_1_Students_Teachers_groops.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_1_Students_Teachers_groops
{
    public  static class LibMethods
    {
        public static ListOfPerson SortByTeacherRole(ListOfPerson teachers)
        {            
            Person item;
            for (int i = 0; i < teachers.GetList().Count; i++)
            {
                for (int j=i+1; j<teachers.GetList().Count; j++)
                {
                    if (teachers.GetList()[i].TeacherRole.CompareTo(teachers.GetList()[j].TeacherRole) == -1)
                    {
                        item=teachers.GetList()[i];
                        teachers.GetList()[i] = teachers.GetList()[j];
                        teachers.GetList()[j] = item;                           
                    }
                }
            }
            return teachers;
        } 
       
     
        public static EnmTeacherRole CheckNumOgGroup(out bool IsFindGroup, Teacher.TechersGroup profGr, Teacher.TechersGroup lectGr,
            Teacher.TechersGroup assistGr, Teacher prof, Teacher lectr, Teacher assnt)
        {
            IsFindGroup = true;
            EnmTeacherRole numGroup = 0;
            if (profGr.GetGroup().Count < prof.QuantityStdntsInGroup)
            {
                numGroup = EnmTeacherRole.Professor;
            }
            else if (lectGr.GetGroup().Count < lectr.QuantityStdntsInGroup)
            {
                numGroup = EnmTeacherRole.lector;
            }
            else if (assistGr.GetGroup().Count < assnt.QuantityStdntsInGroup)
            {
                numGroup = EnmTeacherRole.Assistant;
            }            
            return numGroup;
        }
    }
}
