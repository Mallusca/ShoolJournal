

namespace SchoolJournal.DAL.Interfaces
{
    using System.Linq;
    using Domain;

    public interface IJournalGridColumnsRepository
    {
        IQueryable<JournalGridColumnModel> GetJournalGridColumnsForJournal();
    }
}
