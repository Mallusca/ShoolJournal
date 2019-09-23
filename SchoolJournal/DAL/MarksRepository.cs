using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.DAL.Interfaces
{
    public class MarksRepository: RepositoryBase, IMarksRepository
    {
        public MarksRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}