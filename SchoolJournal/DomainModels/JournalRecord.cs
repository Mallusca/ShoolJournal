namespace SchoolJournal.DomainModels
{
    //TODOREAD why we should write usings inside namespace
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using SchoolJournal.DAL.Enums;
    using System.Collections.ObjectModel;

    public class JournalRecord
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public RecordType RecordType { get; set; }
    }
}