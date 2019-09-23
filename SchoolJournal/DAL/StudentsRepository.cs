namespace SchoolJournal.DAL
{
    using SchoolJournal.DAL.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class StudentsRepository : RepositoryBase, IStudentsRepository
    {
        public StudentsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}