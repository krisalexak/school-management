namespace School.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SchoolDbv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentAssignments", "FinalMark", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.StudentAssignments", "OralMark");
            DropColumn("dbo.StudentAssignments", "TotalMark");
        }

        public override void Down()
        {
            AddColumn("dbo.StudentAssignments", "TotalMark", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.StudentAssignments", "OralMark", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.StudentAssignments", "FinalMark");
        }
    }
}