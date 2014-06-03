namespace CleanRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPTEandMCNs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PTEs",
                c => new
                    {
                        PTEID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        MCNID = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PTEID)
                .ForeignKey("dbo.MCNs", t => t.MCNID, cascadeDelete: true)
                .Index(t => t.MCNID);
            
            CreateTable(
                "dbo.MCNs",
                c => new
                    {
                        MCNID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MCNID);
            
            AddColumn("dbo.WaferLots", "MCN_MCNID", c => c.Int());
            AddColumn("dbo.WaferLots", "PTE_PTEID", c => c.Int());
            AddColumn("dbo.Projects", "PTE_PTEID", c => c.Int());
            AddForeignKey("dbo.WaferLots", "MCN_MCNID", "dbo.MCNs", "MCNID");
            AddForeignKey("dbo.WaferLots", "PTE_PTEID", "dbo.PTEs", "PTEID");
            AddForeignKey("dbo.Projects", "PTE_PTEID", "dbo.PTEs", "PTEID");
            CreateIndex("dbo.WaferLots", "MCN_MCNID");
            CreateIndex("dbo.WaferLots", "PTE_PTEID");
            CreateIndex("dbo.Projects", "PTE_PTEID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PTEs", new[] { "MCNID" });
            DropIndex("dbo.Projects", new[] { "PTE_PTEID" });
            DropIndex("dbo.WaferLots", new[] { "PTE_PTEID" });
            DropIndex("dbo.WaferLots", new[] { "MCN_MCNID" });
            DropForeignKey("dbo.PTEs", "MCNID", "dbo.MCNs");
            DropForeignKey("dbo.Projects", "PTE_PTEID", "dbo.PTEs");
            DropForeignKey("dbo.WaferLots", "PTE_PTEID", "dbo.PTEs");
            DropForeignKey("dbo.WaferLots", "MCN_MCNID", "dbo.MCNs");
            DropColumn("dbo.Projects", "PTE_PTEID");
            DropColumn("dbo.WaferLots", "PTE_PTEID");
            DropColumn("dbo.WaferLots", "MCN_MCNID");
            DropTable("dbo.MCNs");
            DropTable("dbo.PTEs");
        }
    }
}
