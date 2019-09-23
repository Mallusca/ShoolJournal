using SchoolJournal.Models.DataClases;
using SchoolJournal.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models.DbModel
{
    public class JournalContext:DbContext
    {
        public DbSet<RatingInfo> Students { get; set; }
        public DbSet<StudentInfo> StudentInfos { get; set; }
        public DbSet<TableColumn> TableColumns { get; set; }
        public DbSet<JournalModel> JournalModels { get; set; }
        public DbSet<DbFunctions> DbFunctions { get; set; }
    }
    public class JournalDbInitializator : DropCreateDatabaseIfModelChanges<JournalContext>
    {
        protected override void Seed(JournalContext context)
        {
        }
    }
}


// MVC
// MODEL VIEW CONTROLLER

    // transcation id, ownerId, amount, date, state
    
    // credits: transaction - bonusAmount 
    // money: transaction - items - what was purchased

    // Credits 
    // Items for money


// DAL - data access layer DBContext\entities-DBModels | LinqToSql repositories \\ REPOSITORIES

// BLL - business logics layer | Services 
// WEB - Controller - data conversion\model creation\ authorisation

// Views - html js template шаблонизатор


// What data in what format do you need