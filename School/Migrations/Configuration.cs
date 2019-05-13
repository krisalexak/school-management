namespace School.Migrations
{
    using School.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<School.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(School.SchoolContext context)
        {
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT(Students, reseed, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT(Trainers, reseed, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT(Courses, reseed, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT(Assignments, reseed, 0)");

            context.Students.RemoveRange(context.Students);
            context.Trainers.RemoveRange(context.Trainers);
            context.Courses.RemoveRange(context.Courses);
            context.Assignments.RemoveRange(context.Assignments);
            context.StudentAssignments.RemoveRange(context.StudentAssignments);
            context.StudentAccounts.RemoveRange(context.StudentAccounts);
            context.TrainerAccounts.RemoveRange(context.TrainerAccounts);

            context.SaveChanges();

            context.Courses.AddOrUpdate(c => c.Id,
                new Course() { Id = 1, Title = "Full Stack Programming", Stream = "Java", Type = "Full", StartDate = new DateTime(2019, 2, 4), EndDate = new DateTime(2019, 2, 4), Schedule = "This is a daily schedule for Java-Full blah blah" },
                new Course() { Id = 2, Title = "Full Stack Programming", Stream = "Java", Type = "Part", StartDate = new DateTime(2019, 2, 4), EndDate = new DateTime(2019, 8, 3), Schedule = "This is a daily schedule for Java-Part blah blah" },
                new Course() { Id = 3, Title = "Full Stack Programming", Stream = "C#", Type = "Full", StartDate = new DateTime(2019, 2, 4), EndDate = new DateTime(2019, 5, 3), Schedule = "This is a daily schedule for C#-Full blah blah" },
                new Course() { Id = 4, Title = "Full Stack Programming", Stream = "C#", Type = "Part", StartDate = new DateTime(2019, 2, 4), EndDate = new DateTime(2019, 8, 3), Schedule = "This is a daily schedule for C#-Part blah blah" }
            );
            context.SaveChanges();

            var course1 = context.Courses.SingleOrDefault(c => c.Id.Equals(1));
            var course2 = context.Courses.SingleOrDefault(c => c.Id.Equals(2));
            var course3 = context.Courses.SingleOrDefault(c => c.Id.Equals(3));
            var course4 = context.Courses.SingleOrDefault(c => c.Id.Equals(4));

            context.Students.AddOrUpdate(s => s.LastName,
                new Student() { FirstName = "Christos", LastName = "Prospathopoulos", BirthDate = new DateTime(1991, 2, 25), TuitionFees = 2500, Courses = new List<Course>() { course1, course2, course3 } },
                new Student() { FirstName = "Paulos", LastName = "Brukolakas", BirthDate = new DateTime(1992, 10, 3), TuitionFees = 350, Courses = new List<Course>() { course1 } },
                new Student() { FirstName = "Maria", LastName = "Katsika", BirthDate = new DateTime(1985, 3, 19), TuitionFees = 1000, Courses = new List<Course>() { course2 } },
                new Student() { FirstName = "Sakis", LastName = "Trompetas", BirthDate = new DateTime(1988, 1, 1), TuitionFees = 1350, Courses = new List<Course>() { course2, course4 } },
                new Student() { FirstName = "Eleni", LastName = "Foukara", BirthDate = new DateTime(1995, 9, 24), TuitionFees = 740, Courses = new List<Course>() { course3 } },
                new Student() { FirstName = "Konstantinos", LastName = "Skordalias", BirthDate = new DateTime(1999, 4, 13), TuitionFees = 666, Courses = new List<Course>() { course3 } },
                new Student() { FirstName = "Nikolas", LastName = "Teslas", BirthDate = new DateTime(1992, 10, 3), TuitionFees = 350, Courses = new List<Course>() { course1, course4 } },
                new Student() { FirstName = "Leonardos", LastName = "Ntavinsis", BirthDate = new DateTime(1985, 3, 19), TuitionFees = 1000, Courses = new List<Course>() { course4 } }
            );

            context.Trainers.AddOrUpdate(t => t.LastName,
                new Trainer() { FirstName = "Anna", LastName = "Mpoufe", Subject = "Java Programming", Courses = new List<Course>() { course1 } },
                new Trainer() { FirstName = "Eirini", LastName = "Petrelaiou", Subject = "Javascript", Courses = new List<Course>() { course1 } },
                new Trainer() { FirstName = "Giwrgos", LastName = "Kainourgios", Subject = "Java Programming", Courses = new List<Course>() { course2 } },
                new Trainer() { FirstName = "Giannis", LastName = "Pittas", Subject = "Angular", Courses = new List<Course>() { course2 } },
                new Trainer() { FirstName = "Menios", LastName = "Senios", Subject = "C# Programming", Courses = new List<Course>() { course3 } },
                new Trainer() { FirstName = "Sebasti", LastName = "Feta", Subject = "Javascript", Courses = new List<Course>() { course3 } },
                new Trainer() { FirstName = "Aris", LastName = "Kokkaliaris", Subject = "C# Programming", Courses = new List<Course>() { course4 } },
                new Trainer() { FirstName = "Nikos", LastName = "Sketos", Subject = "React", Courses = new List<Course>() { course4 } }
            );

            context.Assignments.AddOrUpdate(a => a.Title,
                new Assignment() { Title = "Eshop Website", Description = "This is a description for an Eshop assignment blah blah", Submission = new DateTime(2019, 2, 28), OralMark = 20, TotalMark = 10, Courses = new List<Course>() { course1 } },
                new Assignment() { Title = "Company Database", Description = "This is a description for a Database assignment blah blah", Submission = new DateTime(2019, 2, 26), OralMark = 30, TotalMark = 20, Courses = new List<Course>() { course1 } },
                new Assignment() { Title = "Mobile App", Description = "This is a description for a mobile app assignment blah blah", Submission = new DateTime(2019, 2, 25), OralMark = 40, TotalMark = 25, Courses = new List<Course>() { course2 } },
                new Assignment() { Title = "Webpage Design", Description = "This is a description for a Webpage assignment blah blah", Submission = new DateTime(2019, 2, 25), OralMark = 25, TotalMark = 15, Courses = new List<Course>() { course2 } },
                new Assignment() { Title = "Front-endDesign", Description = "This is a description for a Front-end assignment blah blah", Submission = new DateTime(2019, 2, 25), OralMark = 25, TotalMark = 15, Courses = new List<Course>() { course3 } },
                new Assignment() { Title = "Back-end Design", Description = "This is a description for a Back-end assignment blah blah", Submission = new DateTime(2019, 2, 25), OralMark = 25, TotalMark = 20, Courses = new List<Course>() { course3 } },
                new Assignment() { Title = "Javascript", Description = "This is a description for a Javascript assignment blah blah", Submission = new DateTime(2019, 2, 25), OralMark = 25, TotalMark = 15, Courses = new List<Course>() { course4 } },
                new Assignment() { Title = "Console App", Description = "This is a description for a Console App assignment blah blah", Submission = new DateTime(2019, 2, 25), OralMark = 35, TotalMark = 25, Courses = new List<Course>() { course4 } }
            );

            context.StudentAssignments.AddOrUpdate(s => new { s.AssignmentID, s.StudentID },
                new StudentAssignment() { StudentID = 1, AssignmentID = 1, FinalMark = 18 },
                new StudentAssignment() { StudentID = 1, AssignmentID = 2, FinalMark = 18 },
                new StudentAssignment() { StudentID = 1, AssignmentID = 4, FinalMark = 18 },
                new StudentAssignment() { StudentID = 1, AssignmentID = 6, FinalMark = 18 },
                new StudentAssignment() { StudentID = 2, AssignmentID = 1, FinalMark = 18 },
                new StudentAssignment() { StudentID = 2, AssignmentID = 2, FinalMark = 18 },
                new StudentAssignment() { StudentID = 3, AssignmentID = 3, FinalMark = 18 },
                new StudentAssignment() { StudentID = 3, AssignmentID = 4, FinalMark = 18 },
                new StudentAssignment() { StudentID = 4, AssignmentID = 3, FinalMark = 18 },
                new StudentAssignment() { StudentID = 4, AssignmentID = 4, FinalMark = 18 },
                new StudentAssignment() { StudentID = 4, AssignmentID = 8, FinalMark = 18 },
                new StudentAssignment() { StudentID = 5, AssignmentID = 5, FinalMark = 18 },
                new StudentAssignment() { StudentID = 5, AssignmentID = 6, FinalMark = 18 },
                new StudentAssignment() { StudentID = 6, AssignmentID = 6, FinalMark = 18 },
                new StudentAssignment() { StudentID = 7, AssignmentID = 2, FinalMark = 18 }
            );

            context.StudentAccounts.AddOrUpdate(sa => sa.Username,
                new StudentAccount() { StudentAccountID = 1, Username = GetStringSha256Hash("su1"), Password = GetStringSha256Hash("sp1") },
                new StudentAccount() { StudentAccountID = 2, Username = GetStringSha256Hash("su2"), Password = GetStringSha256Hash("sp2") },
                new StudentAccount() { StudentAccountID = 3, Username = GetStringSha256Hash("su3"), Password = GetStringSha256Hash("sp3") },
                new StudentAccount() { StudentAccountID = 4, Username = GetStringSha256Hash("su4"), Password = GetStringSha256Hash("sp4") },
                new StudentAccount() { StudentAccountID = 5, Username = GetStringSha256Hash("su5"), Password = GetStringSha256Hash("sp5") },
                new StudentAccount() { StudentAccountID = 6, Username = GetStringSha256Hash("su6"), Password = GetStringSha256Hash("sp6") },
                new StudentAccount() { StudentAccountID = 7, Username = GetStringSha256Hash("su7"), Password = GetStringSha256Hash("sp7") },
                new StudentAccount() { StudentAccountID = 8, Username = GetStringSha256Hash("su8"), Password = GetStringSha256Hash("sp8") }
                );

            context.TrainerAccounts.AddOrUpdate(sa => sa.Username,
                new TrainerAccount() { TrainerAccountID = 1, Username = GetStringSha256Hash("tu1"), Password = GetStringSha256Hash("tp1") },
                new TrainerAccount() { TrainerAccountID = 2, Username = GetStringSha256Hash("tu2"), Password = GetStringSha256Hash("tp2") },
                new TrainerAccount() { TrainerAccountID = 3, Username = GetStringSha256Hash("tu3"), Password = GetStringSha256Hash("tp3") },
                new TrainerAccount() { TrainerAccountID = 4, Username = GetStringSha256Hash("tu4"), Password = GetStringSha256Hash("tp4") },
                new TrainerAccount() { TrainerAccountID = 5, Username = GetStringSha256Hash("tu5"), Password = GetStringSha256Hash("tp5") },
                new TrainerAccount() { TrainerAccountID = 6, Username = GetStringSha256Hash("tu6"), Password = GetStringSha256Hash("tp6") },
                new TrainerAccount() { TrainerAccountID = 7, Username = GetStringSha256Hash("tu7"), Password = GetStringSha256Hash("tp7") },
                new TrainerAccount() { TrainerAccountID = 8, Username = GetStringSha256Hash("tu8"), Password = GetStringSha256Hash("tp8") }
                );
            context.HeadMasterAccounts.AddOrUpdate(h => h.Username,
                new HeadMasterAccount() { Username = GetStringSha256Hash("hu"), Password = GetStringSha256Hash("hp") }
                );
        }

        public static string GetStringSha256Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
    }
}