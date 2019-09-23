namespace SchoolJournal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InititalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JournalRecords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        RecordType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StudentId = c.Long(nullable: false),
                        JournalRecordId = c.Long(nullable: false),
                        Value = c.Int(nullable: false),
                        MarkType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JournalRecords", t => t.JournalRecordId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.JournalRecordId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Marks", "JournalRecordId", "dbo.JournalRecords");
            DropIndex("dbo.Marks", new[] { "JournalRecordId" });
            DropIndex("dbo.Marks", new[] { "StudentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Marks");
            DropTable("dbo.JournalRecords");
        }
    }
}
