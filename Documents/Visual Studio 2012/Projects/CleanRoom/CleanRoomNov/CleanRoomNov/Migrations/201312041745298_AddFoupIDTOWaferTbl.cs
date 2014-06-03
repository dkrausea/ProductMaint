namespace CleanRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoupIDTOWaferTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wafers", "FoupID", c => c.Int());
            AddForeignKey("dbo.Wafers", "FoupID", "dbo.Foups", "FoupID");
            CreateIndex("dbo.Wafers", "FoupID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Wafers", new[] { "FoupID" });
            DropForeignKey("dbo.Wafers", "FoupID", "dbo.Foups");
            DropColumn("dbo.Wafers", "FoupID");
        }
    }
}
