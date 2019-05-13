namespace School.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SchoolDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Description = c.String(),
                    Submission = c.DateTime(nullable: false),
                    OralMark = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TotalMark = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Courses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Stream = c.String(),
                    Type = c.String(),
                    StartDate = c.DateTime(nullable: false),
                    EndDate = c.DateTime(nullable: false),
                    Schedule = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Students",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    BirthDate = c.DateTime(nullable: false),
                    TuitionFees = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.StudentAccounts",
                c => new
                {
                    StudentAccountID = c.Int(nullable: false),
                    Username = c.String(),
                    Password = c.String(),
                })
                .PrimaryKey(t => t.StudentAccountID)
                .ForeignKey("dbo.Students", t => t.StudentAccountID)
                .Index(t => t.StudentAccountID);

            CreateTable(
                "dbo.StudentAssignments",
                c => new
                {
                    StudentID = c.Int(nullable: false),
                    AssignmentID = c.Int(nullable: false),
                    OralMark = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TotalMark = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => new { t.StudentID, t.AssignmentID })
                .ForeignKey("dbo.Assignments", t => t.AssignmentID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.AssignmentID);

            CreateTable(
                "dbo.Trainers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Subject = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.TrainerAccounts",
                c => new
                {
                    TrainerAccountID = c.Int(nullable: false),
                    Username = c.String(),
                    Password = c.String(),
                })
                .PrimaryKey(t => t.TrainerAccountID)
                .ForeignKey("dbo.Trainers", t => t.TrainerAccountID)
                .Index(t => t.TrainerAccountID);

            CreateTable(
                "dbo.CourseAssignments",
                c => new
                {
                    Course_Id = c.Int(nullable: false),
                    Assignment_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Course_Id, t.Assignment_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Assignments", t => t.Assignment_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Assignment_Id);

            CreateTable(
                "dbo.StudentCourses",
                c => new
                {
                    Student_Id = c.Int(nullable: false),
                    Course_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);

            CreateTable(
                "dbo.TrainerCourses",
                c => new
                {
                    Trainer_Id = c.Int(nullable: false),
                    Course_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Trainer_Id, t.Course_Id })
                .ForeignKey("dbo.Trainers", t => t.Trainer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Trainer_Id)
                .Index(t => t.Course_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.TrainerAccounts", "TrainerAccountID", "dbo.Trainers");
            DropForeignKey("dbo.TrainerCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.TrainerCourses", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.StudentAssignments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentAssignments", "AssignmentID", "dbo.Assignments");
            DropForeignKey("dbo.StudentAccounts", "StudentAccountID", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.CourseAssignments", "Assignment_Id", "dbo.Assignments");
            DropForeignKey("dbo.CourseAssignments", "Course_Id", "dbo.Courses");
            DropIndex("dbo.TrainerCourses", new[] { "Course_Id" });
            DropIndex("dbo.TrainerCourses", new[] { "Trainer_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Course_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Student_Id" });
            DropIndex("dbo.CourseAssignments", new[] { "Assignment_Id" });
            DropIndex("dbo.CourseAssignments", new[] { "Course_Id" });
            DropIndex("dbo.TrainerAccounts", new[] { "TrainerAccountID" });
            DropIndex("dbo.StudentAssignments", new[] { "AssignmentID" });
            DropIndex("dbo.StudentAssignments", new[] { "StudentID" });
            DropIndex("dbo.StudentAccounts", new[] { "StudentAccountID" });
            DropTable("dbo.TrainerCourses");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.CourseAssignments");
            DropTable("dbo.TrainerAccounts");
            DropTable("dbo.Trainers");
            DropTable("dbo.StudentAssignments");
            DropTable("dbo.StudentAccounts");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}