namespace SchoolJournal.DomainModels
{
    using System;
    using SchoolJournal.DAL.Enums;

    public class CreateJournalRecord
    {
        public DateTime Date { get; set; }

        public RecordType RecordType { get; set; }
    }
}