namespace MvcChipRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Release", "IDF", c => c.String());
            AddColumn("dbo.Release", "EmailSent", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Release", "EmailSent");
            DropColumn("dbo.Release", "IDF");
        }
    }
}
