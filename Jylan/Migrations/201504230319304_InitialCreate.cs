using System.Data.Entity.Migrations;

namespace Jylan.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Signups",
                c => new
                {
                    SignupId = c.Int(false, true),
                    EmailAddress = c.String(false),
                    FirstName = c.String(false),
                    LastName = c.String(false),
                    PhoneNumber = c.String(false),
                    HasPayed = c.Boolean(false)
                })
                .PrimaryKey(t => t.SignupId);
        }

        public override void Down()
        {
            DropTable("dbo.Signups");
        }
    }
}