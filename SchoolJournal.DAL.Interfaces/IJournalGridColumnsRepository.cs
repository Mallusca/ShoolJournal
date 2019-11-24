

namespace SchoolJournal.DAL.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using SchoolJournal.ViewModels;

    public interface IJournalGridColumnsRepository
    {
        IQueryable<JournalGridColumnModel> GetJournalGridColumnsForJournal();

        void CreatelGridColumnsForJournal(IEnumerable<ColumnMarkViewModel> marks);
    }
}
