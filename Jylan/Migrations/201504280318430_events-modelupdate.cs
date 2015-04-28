namespace Jylan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventsmodelupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Name", c => c.String(unicode: false));
        }
    }
}
