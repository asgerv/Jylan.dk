using System.Data.Entity.Migrations;

namespace Jylan.Migrations
{
    public partial class eventsmodelupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Name", c => c.String(false, unicode: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Events", "Name", c => c.String(unicode: false));
        }
    }
}