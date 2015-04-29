using System.Data.Entity.Migrations;

namespace Timelog.DataAccess.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingCode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagTreeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TagTree", t => t.TagTreeId)
                .Index(t => t.TagTreeId);
            
            CreateTable(
                "dbo.TagTree",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelatedTagTreeId = c.Int(),
                        TagId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TagTree", t => t.RelatedTagTreeId)
                .ForeignKey("dbo.Tag", t => t.TagId)
                .Index(t => t.RelatedTagTreeId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        TagTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeEntry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeEntryCreated = c.DateTime(nullable: false),
                        TimeEntryDuration = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeEntryDescription = c.String(),
                        TimeEntryDate = c.DateTime(nullable: false),
                        BookingCodeId = c.Int(),
                        TimeEntryCreatorId = c.Int(),
                        TimeEntryUserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookingCode", t => t.BookingCodeId)
                .ForeignKey("dbo.User", t => t.TimeEntryCreatorId)
                .ForeignKey("dbo.User", t => t.TimeEntryUserId)
                .Index(t => t.BookingCodeId)
                .Index(t => t.TimeEntryCreatorId)
                .Index(t => t.TimeEntryUserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeEntry", "TimeEntryUserId", "dbo.User");
            DropForeignKey("dbo.TimeEntry", "TimeEntryCreatorId", "dbo.User");
            DropForeignKey("dbo.TimeEntry", "BookingCodeId", "dbo.BookingCode");
            DropForeignKey("dbo.BookingCode", "TagTreeId", "dbo.TagTree");
            DropForeignKey("dbo.TagTree", "TagId", "dbo.Tag");
            DropForeignKey("dbo.TagTree", "RelatedTagTreeId", "dbo.TagTree");
            DropIndex("dbo.TimeEntry", new[] { "TimeEntryUserId" });
            DropIndex("dbo.TimeEntry", new[] { "TimeEntryCreatorId" });
            DropIndex("dbo.TimeEntry", new[] { "BookingCodeId" });
            DropIndex("dbo.TagTree", new[] { "TagId" });
            DropIndex("dbo.TagTree", new[] { "RelatedTagTreeId" });
            DropIndex("dbo.BookingCode", new[] { "TagTreeId" });
            DropTable("dbo.User");
            DropTable("dbo.TimeEntry");
            DropTable("dbo.Tag");
            DropTable("dbo.TagTree");
            DropTable("dbo.BookingCode");
        }
    }
}
