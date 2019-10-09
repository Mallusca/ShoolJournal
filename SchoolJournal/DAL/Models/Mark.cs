using SchoolJournal.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolJournal.DAL.Models
{
    public class Mark
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Student")]
        public long StudentId { get; set; }

        [ForeignKey("JournalRecord")]
        public long JournalRecordId { get; set; }

        public int Value { get; set; }

        public MarkType MarkType { get; set; }

        //TODOREAD navigation property
        public virtual Student Student { get; set; }

        public virtual JournalRecord JournalRecord { get; set; }
    }
}

