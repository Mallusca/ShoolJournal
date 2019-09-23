using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJournal.Models.DataClases;
using SchoolJournal.Models.DbModel;

namespace SchoolJournal.Models.Models
{

    public class JournalModel
    {
        public virtual ICollection<StudentInfo> StudentInfos { get; set; }
        public virtual ICollection<RatingInfo> RatingInfos { get; set; }
        public virtual ICollection<TableColumn> TableColumns { get; set; }

        public List<StudentInfo> students { get; set; }

        public List<TableColumn> columns { get; set; }

        public TableColumn average { get; set; }


        public JournalModel()
        {
            try
            {
                students = new List<StudentInfo>();
                columns = new List<TableColumn>();
                average = new TableColumn();

                using(DbFunctions df = new DbFunctions())
                {

                    students = df.loadStudents();

                    columns = df.loadTableColumns();

                    average = df.loadAverage(students);
                }
            }
            catch { }
        }
    }
}