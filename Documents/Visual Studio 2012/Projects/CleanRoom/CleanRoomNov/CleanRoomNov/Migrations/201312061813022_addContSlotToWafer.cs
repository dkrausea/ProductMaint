namespace CleanRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContSlotToWafer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wafers", "ContainerSlot", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wafers", "ContainerSlot");
        }
    }
}
