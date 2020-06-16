namespace BugTrackerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketCommentTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Created = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.TicketComments", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketComments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.TicketComments", new[] { "ApplicationUserId" });
            DropIndex("dbo.TicketComments", new[] { "TicketId" });
            DropTable("dbo.TicketComments");
        }
    }
}
