namespace CleanRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WaferLots",
                c => new
                    {
                        WaferLotID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Foundry = c.String(),
                        Project = c.String(),
                        MCN = c.String(),
                        FabLot = c.String(),
                        Description = c.String(),
                        SpeedSplits = c.String(),
                        Note = c.String(),
                        HomeBoatID = c.Int(nullable: false),
                        LotStatusID = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                        Foundry_FoundryID = c.Int(),
                    })
                .PrimaryKey(t => t.WaferLotID)
                .ForeignKey("dbo.HomeBoats", t => t.HomeBoatID, cascadeDelete: true)
                .ForeignKey("dbo.LotStatus", t => t.LotStatusID, cascadeDelete: true)
                .ForeignKey("dbo.Foundries", t => t.Foundry_FoundryID)
                .Index(t => t.HomeBoatID)
                .Index(t => t.LotStatusID)
                .Index(t => t.Foundry_FoundryID);
            
            CreateTable(
                "dbo.HomeBoats",
                c => new
                    {
                        HomeBoatID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MRBWafer = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Cabinet = c.Int(nullable: false),
                        Shelf = c.Int(nullable: false),
                        Spot = c.Int(nullable: false),
                        LocCode = c.Int(nullable: false),
                        Note = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HomeBoatID);
            
            CreateTable(
                "dbo.LotStatus",
                c => new
                    {
                        LotStatusID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LotStatusID);
            
            CreateTable(
                "dbo.Wafers",
                c => new
                    {
                        WaferID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HomeBoatSlot = c.Int(nullable: false),
                        Status = c.String(),
                        Note = c.String(),
                        WaferLotID = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WaferID)
                .ForeignKey("dbo.WaferLots", t => t.WaferLotID, cascadeDelete: true)
                .Index(t => t.WaferLotID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        Slot = c.Int(nullable: false),
                        Note = c.String(),
                        TransactionTypeID = c.Int(nullable: false),
                        FoupID = c.Int(nullable: false),
                        WaferID = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.TransactionTypes", t => t.TransactionTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Foups", t => t.FoupID, cascadeDelete: true)
                .ForeignKey("dbo.Wafers", t => t.WaferID, cascadeDelete: true)
                .Index(t => t.TransactionTypeID)
                .Index(t => t.FoupID)
                .Index(t => t.WaferID);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        TransactionTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionTypeID);
            
            CreateTable(
                "dbo.Foups",
                c => new
                    {
                        FoupID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                        LocationID = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FoupID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.WaferStatus",
                c => new
                    {
                        WaferStatusID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Note = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WaferStatusID);
            
            CreateTable(
                "dbo.WaferFailCodes",
                c => new
                    {
                        WaferFailCodeID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Reason = c.String(),
                        Note = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WaferFailCodeID);
            
            CreateTable(
                "dbo.Foundries",
                c => new
                    {
                        FoundryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FoundryID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Foups", new[] { "LocationID" });
            DropIndex("dbo.Transactions", new[] { "WaferID" });
            DropIndex("dbo.Transactions", new[] { "FoupID" });
            DropIndex("dbo.Transactions", new[] { "TransactionTypeID" });
            DropIndex("dbo.Wafers", new[] { "WaferLotID" });
            DropIndex("dbo.WaferLots", new[] { "Foundry_FoundryID" });
            DropIndex("dbo.WaferLots", new[] { "LotStatusID" });
            DropIndex("dbo.WaferLots", new[] { "HomeBoatID" });
            DropForeignKey("dbo.Foups", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Transactions", "WaferID", "dbo.Wafers");
            DropForeignKey("dbo.Transactions", "FoupID", "dbo.Foups");
            DropForeignKey("dbo.Transactions", "TransactionTypeID", "dbo.TransactionTypes");
            DropForeignKey("dbo.Wafers", "WaferLotID", "dbo.WaferLots");
            DropForeignKey("dbo.WaferLots", "Foundry_FoundryID", "dbo.Foundries");
            DropForeignKey("dbo.WaferLots", "LotStatusID", "dbo.LotStatus");
            DropForeignKey("dbo.WaferLots", "HomeBoatID", "dbo.HomeBoats");
            DropTable("dbo.Foundries");
            DropTable("dbo.WaferFailCodes");
            DropTable("dbo.WaferStatus");
            DropTable("dbo.Locations");
            DropTable("dbo.Foups");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Transactions");
            DropTable("dbo.Wafers");
            DropTable("dbo.LotStatus");
            DropTable("dbo.HomeBoats");
            DropTable("dbo.WaferLots");
        }
    }
}
