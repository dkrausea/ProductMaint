namespace Guestbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnknown : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GuestbookEntries", "Name", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.GuestbookEntries", "Message", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GuestbookEntries", "Message", c => c.String(maxLength: 4000));
            AlterColumn("dbo.GuestbookEntries", "Name", c => c.String(maxLength: 4000));
        }
    }
}
