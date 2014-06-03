namespace BootstrapExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gun",
                c => new
                    {
                        GunID = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        Caliber = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.GunID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Gun");
        }
    }
}
