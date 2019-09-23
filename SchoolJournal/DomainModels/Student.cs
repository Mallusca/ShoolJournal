using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolJournal.DomainModels
{
    public class Student
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FIO {
            get
            {
                //TODOREAD differences with concatenation
                return string.Format("{0} {1} {2}", FirstName, LastName, MiddleName);
            }
        }
    }
}