namespace MvcFFA_SURF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPersonCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ATP", "ChipRequest_ChipRequestID", "dbo.ChipRequest");
            DropIndex("dbo.ATP", new[] { "ChipRequest_ChipRequestID" });
            CreateTable(
                "dbo.CategoryPerson",
                c => new
                    {
                        Category_CategoryID = c.Int(nullable: false),
                        Person_PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_CategoryID, t.Person_PersonID })
                .ForeignKey("dbo.Category", t => t.Category_CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.Person_PersonID, cascadeDelete: true)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.Person_PersonID);
            
            AddColumn("dbo.ChipRequest", "CompletedOn", c => c.DateTime());
            AddColumn("dbo.ChipRequest", "CompletedBy", c => c.String(maxLength: 4000));
            AddColumn("dbo.Category", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ATP", "ExpectedBy", c => c.DateTime());
            DropColumn("dbo.ChipRequest", "DemandID");
            DropColumn("dbo.ChipRequest", "ATPID");
            DropColumn("dbo.Demand", "ATPID");
            DropColumn("dbo.ATP", "ReleaseID");
            DropColumn("dbo.ATP", "ChipRequest_ChipRequestID");
            DropColumn("dbo.Person", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "Category", c => c.String(maxLength: 4000));
            AddColumn("dbo.ATP", "ChipRequest_ChipRequestID", c => c.Int());
            AddColumn("dbo.ATP", "ReleaseID", c => c.Int(nullable: false));
            AddColumn("dbo.Demand", "ATPID", c => c.Int(nullable: false));
            AddColumn("dbo.ChipRequest", "ATPID", c => c.Int(nullable: false));
            AddColumn("dbo.ChipRequest", "DemandID", c => c.Int(nullable: false));
            DropIndex("dbo.CategoryPerson", new[] { "Person_PersonID" });
            DropIndex("dbo.CategoryPerson", new[] { "Category_CategoryID" });
            DropForeignKey("dbo.CategoryPerson", "Person_PersonID", "dbo.Person");
            DropForeignKey("dbo.CategoryPerson", "Category_CategoryID", "dbo.Category");
            AlterColumn("dbo.ATP", "ExpectedBy", c => c.DateTime(nullable: false));
            DropColumn("dbo.Category", "IsActive");
            DropColumn("dbo.ChipRequest", "CompletedBy");
            DropColumn("dbo.ChipRequest", "CompletedOn");
            DropTable("dbo.CategoryPerson");
            CreateIndex("dbo.ATP", "ChipRequest_ChipRequestID");
            AddForeignKey("dbo.ATP", "ChipRequest_ChipRequestID", "dbo.ChipRequest", "ChipRequestID");
        }
    }
}
