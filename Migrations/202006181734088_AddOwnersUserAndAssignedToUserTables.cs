namespace BugTrackerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnersUserAndAssignedToUserTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "OwnerUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Tickets", "AssignedToUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "OwnerUserId");
            CreateIndex("dbo.Tickets", "AssignedToUserId");
            AddForeignKey("dbo.Tickets", "AssignedToUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "OwnerUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "OwnerUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "AssignedToUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "AssignedToUserId" });
            DropIndex("dbo.Tickets", new[] { "OwnerUserId" });
            DropColumn("dbo.Tickets", "AssignedToUserId");
            DropColumn("dbo.Tickets", "OwnerUserId");
        }
    }
}
