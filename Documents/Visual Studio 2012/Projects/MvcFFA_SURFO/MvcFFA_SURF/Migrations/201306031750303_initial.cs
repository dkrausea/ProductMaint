namespace MvcFFA_SURF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChipRequest", "ATPID", c => c.Int(nullable: false));
            AddColumn("dbo.ATP", "ReleaseID", c => c.Int(nullable: false));
            AddColumn("dbo.ATP", "ChipRequest_ChipRequestID", c => c.Int());
            AddColumn("dbo.Release", "ModifiedBy", c => c.String(maxLength: 4000));
            AddForeignKey("dbo.ATP", "ChipRequest_ChipRequestID", "dbo.ChipRequest", "ChipRequestID");
            AddForeignKey("dbo.Release", "ATPID", "dbo.ATP", "ATPID", cascadeDelete: true);
            CreateIndex("dbo.ATP", "ChipRequest_ChipRequestID");
            CreateIndex("dbo.Release", "ATPID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Release", new[] { "ATPID" });
            DropIndex("dbo.ATP", new[] { "ChipRequest_ChipRequestID" });
            DropForeignKey("dbo.Release", "ATPID", "dbo.ATP");
            DropForeignKey("dbo.ATP", "ChipRequest_ChipRequestID", "dbo.ChipRequest");
            DropColumn("dbo.Release", "ModifiedBy");
            DropColumn("dbo.ATP", "ChipRequest_ChipRequestID");
            DropColumn("dbo.ATP", "ReleaseID");
            DropColumn("dbo.ChipRequest", "ATPID");
        }
    }
}
