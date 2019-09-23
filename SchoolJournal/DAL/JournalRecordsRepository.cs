namespace SchoolJournal.DAL
{
    using System.Linq;
    using DAL.Models;
    using System.Collections.Generic;
    using Mapster;
    using System.Threading.Tasks;
    using Interfaces;

    //TODOREAD read about mapster about mapping
    public class JournalRecordsRepository : RepositoryBase, IJournalRecordsRepository
    {
        public JournalRecordsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        //TODOREAD about asynchronouse code Task async await, read about EF DB asynchronouse code
        public async Task<DomainModels.JournalRecord> Create(DomainModels.CreateJournalRecord model)
        {
            JournalRecord dbModel = model.Adapt<JournalRecord>();

            DbContext.JournalRecords.Add(dbModel);
            await DbContext.SaveChangesAsync();

            return dbModel.Adapt<DomainModels.JournalRecord>();
        }

        public IQueryable<DomainModels.JournalRecord> CreateMany(IEnumerable<DomainModels.CreateJournalRecord> records)
        {
            throw new System.NotImplementedException();
        }

        //TODOREAD EXTENSION METHODS
        public IQueryable<DomainModels.JournalRecord> List()
        {
            // linq to entities always returns IQuryable<T>.
            // linq to entities will return from DbSet->IQueryable
            // DbSet<JournalRecord> -> IQueryable<DomainModels.JournalRecord>


            //TODO RESEARCH Watch in SQL Profiler sql requests. Companre requests and speed
            //IQueryable<DomainModels.JournalRecord> res1 = DbContext.JournalRecords.Select(x =>
            //    new DomainModels.JournalRecord
            //    {
            //        Id = x.Id,
            //        Date = x.Date,
            //        RecordType = x.RecordType
            //    });
            //IQueryable<DomainModels.JournalRecord> res2 = 
            //    DbContext.Set<JournalRecord>()
            //    .ProjectToType<DomainModels.JournalRecord>();

            return DbContext.Set<JournalRecord>().ProjectToType<DomainModels.JournalRecord>();
        }
    }
}