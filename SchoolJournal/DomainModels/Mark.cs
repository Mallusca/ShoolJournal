using SchoolJournal.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolJournal.DomainModels
{
    public class Mark
    {
        public long Id { get; set; }

        public long StudentId { get; set; }

        public long JournalRecordId { get; set; }

        public int Value { get; set; }

        public MarkType MarkType { get; set; }
    }
}