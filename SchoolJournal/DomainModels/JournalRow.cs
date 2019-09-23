using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.DomainModels
{
    public class JournalRow
    {
        public Student Student { get; set; }
        
        public IEnumerable<Mark> Marks { get; set; }
    }
}