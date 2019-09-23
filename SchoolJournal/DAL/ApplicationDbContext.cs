namespace SchoolJournal.DAL
{
    using SchoolJournal.DAL.Models;
    using System.Data.Entity;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() 
            : base("name=WebJournal")
        {
        }

        public virtual DbSet<Mark> Marks { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<JournalRecord> JournalRecords { get; set; }

        //TODOREAD
        protected override void OnModelCreating(DbModelBuilder modelBuilder) // read about override 
        {
            base.OnModelCreating(modelBuilder);// read about base.methodName
        }
    }
}