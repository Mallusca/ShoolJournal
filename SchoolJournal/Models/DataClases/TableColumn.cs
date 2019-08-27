using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models.DataClases
{

    public class TableColumn
    {

        public enum columnType
        {
            Ур = 0,
            Экз = 1,
            Лаб = 2,
            Кур = 3
        }


        public long id { get; set; }


        public DateTime date { private get; set; }


        public byte type { get; set; }


        public string getType
        {
            get
            {
                return ((columnType)type).ToString();
            }
        }


        public string getDate
        {
            get
            {
                return date.Day.ToString();
            }
        }



        public Dictionary<long, RatingInfo> values { get; set; }

        public TableColumn()
        {

            values = new Dictionary<long, RatingInfo>();
            date = DateTime.Now;
            type = 0;
            id = -1;
        }
    }
}