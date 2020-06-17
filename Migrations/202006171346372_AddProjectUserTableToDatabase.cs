namespace BugTrackerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectUserTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectUsers", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ProjectUsers", new[] { "ApplicationUserId" });
            DropIndex("dbo.ProjectUsers", new[] { "ProjectId" });
            DropTable("dbo.ProjectUsers");
        }
    }
}
