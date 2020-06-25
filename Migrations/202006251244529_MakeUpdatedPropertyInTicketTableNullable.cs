namespace BugTrackerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeUpdatedPropertyInTicketTableNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Updated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Updated", c => c.DateTime(nullable: false));
        }
    }
}
