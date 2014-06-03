namespace CleanRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProjFoundryDDListsToWLot : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WaferLots", "Foundry_FoundryID", "dbo.Foundries");
            DropForeignKey("dbo.WaferLots", "Project_ProjectID", "dbo.Projects");
            DropIndex("dbo.WaferLots", new[] { "Foundry_FoundryID" });
            DropIndex("dbo.WaferLots", new[] { "Project_ProjectID" });
            RenameColumn(table: "dbo.WaferLots", name: "Foundry_FoundryID", newName: "FoundryID");
            RenameColumn(table: "dbo.WaferLots", name: "Project_ProjectID", newName: "ProjectID");
            AddForeignKey("dbo.WaferLots", "FoundryID", "dbo.Foundries", "FoundryID", cascadeDelete: true);
            AddForeignKey("dbo.WaferLots", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            CreateIndex("dbo.WaferLots", "FoundryID");
            CreateIndex("dbo.WaferLots", "ProjectID");
            DropColumn("dbo.WaferLots", "Foundry");
            DropColumn("dbo.WaferLots", "Project");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WaferLots", "Project", c => c.String());
            AddColumn("dbo.WaferLots", "Foundry", c => c.String());
            DropIndex("dbo.WaferLots", new[] { "ProjectID" });
            DropIndex("dbo.WaferLots", new[] { "FoundryID" });
            DropForeignKey("dbo.WaferLots", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.WaferLots", "FoundryID", "dbo.Foundries");
            RenameColumn(table: "dbo.WaferLots", name: "ProjectID", newName: "Project_ProjectID");
            RenameColumn(table: "dbo.WaferLots", name: "FoundryID", newName: "Foundry_FoundryID");
            CreateIndex("dbo.WaferLots", "Project_ProjectID");
            CreateIndex("dbo.WaferLots", "Foundry_FoundryID");
            AddForeignKey("dbo.WaferLots", "Project_ProjectID", "dbo.Projects", "ProjectID");
            AddForeignKey("dbo.WaferLots", "Foundry_FoundryID", "dbo.Foundries", "FoundryID");
        }
    }
}
