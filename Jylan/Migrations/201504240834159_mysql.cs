namespace Jylan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mysql : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Signups", "EmailAddress", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Signups", "Nick", c => c.String(unicode: false));
            AlterColumn("dbo.Signups", "FirstName", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Signups", "LastName", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Signups", "PhoneNumber", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Signups", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Signups", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Signups", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Signups", "Nick", c => c.String());
            AlterColumn("dbo.Signups", "EmailAddress", c => c.String(nullable: false));
        }
    }
}
