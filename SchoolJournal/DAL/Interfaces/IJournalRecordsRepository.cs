namespace SchoolJournal.DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DomainModels;

    public interface IJournalRecordsRepository
    {
        Task<JournalRecord> Create(DomainModels.CreateJournalRecord model);

        IQueryable<JournalRecord> CreateMany(IEnumerable<CreateJournalRecord> records);

        IQueryable<JournalRecord> List();
    }
}
