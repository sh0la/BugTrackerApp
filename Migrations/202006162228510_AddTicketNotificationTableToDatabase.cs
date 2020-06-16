namespace BugTrackerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketNotificationTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketNotifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketNotifications", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketNotifications", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.TicketNotifications", new[] { "ApplicationUserId" });
            DropIndex("dbo.TicketNotifications", new[] { "TicketId" });
            DropTable("dbo.TicketNotifications");
        }
    }
}
