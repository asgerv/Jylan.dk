namespace Jylan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Signups",
                c => new
                    {
                        SignupId = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        HasPayed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SignupId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Signups");
        }
    }
}
