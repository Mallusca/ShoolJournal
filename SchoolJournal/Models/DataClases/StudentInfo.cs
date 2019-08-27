using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models.DataClases
{

    public class StudentInfo
    {

        public string studentName { get; set; }

        public long studentId { get; set; }



        public StudentInfo()
        {
            studentId = -1;
            studentName = "NoName";
        }
    }
}