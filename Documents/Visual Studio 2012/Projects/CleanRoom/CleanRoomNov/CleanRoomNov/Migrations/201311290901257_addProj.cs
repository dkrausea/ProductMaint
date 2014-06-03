namespace CleanRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            AddColumn("dbo.WaferLots", "Project_ProjectID", c => c.Int());
            AddForeignKey("dbo.WaferLots", "Project_ProjectID", "dbo.Projects", "ProjectID");
            CreateIndex("dbo.WaferLots", "Project_ProjectID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.WaferLots", new[] { "Project_ProjectID" });
            DropForeignKey("dbo.WaferLots", "Project_ProjectID", "dbo.Projects");
            DropColumn("dbo.WaferLots", "Project_ProjectID");
            DropTable("dbo.Projects");
        }
    }
}
