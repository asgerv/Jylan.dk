using System.Data.Entity.Migrations;

namespace Jylan.Migrations
{
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