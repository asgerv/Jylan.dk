namespace Jylan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nickname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signups", "Nick", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Signups", "Nick");
        }
    }
}
