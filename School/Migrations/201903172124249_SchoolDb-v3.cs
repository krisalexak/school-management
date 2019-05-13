namespace School.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SchoolDbv3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeadMasterAccounts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Username = c.String(),
                    Password = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.HeadMasterAccounts");
        }
    }
}