namespace Jylan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signups", "Event_EventId", c => c.Int());
            CreateIndex("dbo.Signups", "Event_EventId");
            AddForeignKey("dbo.Signups", "Event_EventId", "dbo.Events", "EventId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Signups", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Signups", new[] { "Event_EventId" });
            DropColumn("dbo.Signups", "Event_EventId");
        }
    }
}
