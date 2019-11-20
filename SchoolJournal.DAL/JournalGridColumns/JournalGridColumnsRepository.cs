
namespace SchoolJournal.DAL.JournalGridColumns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using SchoolJournal.Domain;

    public class JournalGridColumnsRepository : RepositoryBase, IJournalGridColumnsRepository
    {
        public JournalGridColumnsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IQueryable<JournalGridColumnModel> GetJournalGridColumnsForJournal()
        {
            var data = (from c in DbContext.Columns
                        join cm in DbContext.ColumnMarks on c.Id equals cm.ColumnId into cmGroup
                        orderby c.Date
                        select new JournalGridColumnModel
                        {
                            Id = c.Id,
                            Date = c.Date,
                            Marks = (from m in DbContext.Marks
                                     where cmGroup.Any(x => x.MarkId == m.Id)
                                     select new ColumnMarkModel
                                     {
                                         StudentId = m.StudentId,
                                         Id = m.Id,
                                         Value = m.Value
                                     }).ToList()
                        });

            return data;
        }
    }
}
