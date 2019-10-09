using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace SchoolJournal.DAL.Models
{
    public class StudentRecords
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Key, ForeignKey("JournalRecord")]
        public long RecordId { get; set; }

        [Key, ForeignKey("Student")]
        public long StudentId { get; set; }

        public virtual Student Student { get; set; }

        public virtual JournalRecord JournalRecord { get; set; }
    }
}