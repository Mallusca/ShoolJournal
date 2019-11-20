

namespace SchoolJournal.BLL
{
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using SchoolJournal.ViewModels;
    using DAL.Interfaces;
    using Mapster;
    using System.Collections.Generic;
    using System.Linq;

    public class JournalGridColumnsService: IJournalGridColumnsService
    {
        private readonly IJournalGridColumnsRepository _journalGridColumnRepository;

        public JournalGridColumnsService(IJournalGridColumnsRepository journalGridColumnsRepository)
        {
            _journalGridColumnRepository = journalGridColumnsRepository;
        }
        public List<JournalGridColumnViewModel> GetJournalGridColumns()
        {
            return _journalGridColumnRepository
                .GetJournalGridColumnsForJournal()
                .ToList()
                .Adapt<List<JournalGridColumnViewModel>>();
        }
    }
}
