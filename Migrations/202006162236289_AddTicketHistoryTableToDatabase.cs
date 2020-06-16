namespace BugTrackerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketHistoryTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        Property = c.String(),
                        OldValue = c.String(),
                        NewValue = c.String(),
                        Changed = c.String(),
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
            DropForeignKey("dbo.TicketHistories", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketHistories", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.TicketHistories", new[] { "ApplicationUserId" });
            DropIndex("dbo.TicketHistories", new[] { "TicketId" });
            DropTable("dbo.TicketHistories");
        }
    }
}
