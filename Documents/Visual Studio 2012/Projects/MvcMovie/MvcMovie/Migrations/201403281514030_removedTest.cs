namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedTest : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "test", c => c.String());
        }
    }
}
