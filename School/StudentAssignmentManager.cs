using School.Models;
using System.Data.Entity;

namespace School
{
    public static class StudentAssignmentManager
    {
        public static void CreateStudentAssignment(Student student, Assignment assignment)
        {
            StudentAssignment studentAssignment = new StudentAssignment()
            {
                StudentID = student.Id,
                AssignmentID = assignment.Id,
                Student = student,
                Assignment = assignment
            };

            using (var context = new SchoolContext())
            {
                context.Entry(student).State = EntityState.Unchanged;
                context.Entry(assignment).State = EntityState.Unchanged;
                context.StudentAssignments.Add(studentAssignment);
                context.SaveChanges();
            }
        }
    }
}