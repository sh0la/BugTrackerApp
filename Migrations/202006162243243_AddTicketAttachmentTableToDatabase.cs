namespace BugTrackerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketAttachmentTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketAttachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        FilePath = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        FileUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketAttachments", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketAttachments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.TicketAttachments", new[] { "ApplicationUserId" });
            DropIndex("dbo.TicketAttachments", new[] { "TicketId" });
            DropTable("dbo.TicketAttachments");
        }
    }
}
