namespace School
{
    using School.Models;
    using System.Data.Entity;

    public class SchoolContext : DbContext
    {
        // Your context has been configured to use a 'SchoolContext' connection string from your application's
        // configuration file (App.config or Web.config). By default, this connection string targets the
        // 'PrivateSchool.SchoolContext' database on your LocalDb instance.
        //
        // If you wish to target a different database and/or database provider, modify the 'SchoolContext'
        // connection string in the application configuration file.
        public SchoolContext()
            : base("name=SchoolContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<StudentAssignment> StudentAssignments { get; set; }
        public virtual DbSet<StudentAccount> StudentAccounts { get; set; }
        public virtual DbSet<TrainerAccount> TrainerAccounts { get; set; }
        public virtual DbSet<HeadMasterAccount> HeadMasterAccounts { get; set; }
    }
}