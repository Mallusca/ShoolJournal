namespace SchoolJournal.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public abstract class RepositoryBase
    {
        protected RepositoryBase(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected ApplicationDbContext DbContext { get; set; }
    }
}