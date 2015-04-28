using System.Data.Entity.Migrations;

namespace Jylan.Migrations
{
    public partial class events : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                {
                    EventId = c.Int(false, true),
                    Name = c.String(unicode: false),
                    StartDateTime = c.DateTime(false, 0),
                    EndDateTime = c.DateTime(false, 0),
                    Price = c.Int(false),
                    MaxSignups = c.Int(false)
                })
                .PrimaryKey(t => t.EventId);
        }

        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}