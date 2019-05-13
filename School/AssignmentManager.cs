using School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace School
{
    public static class AssignmentManager
    {
        public static void createAssignment(Assignment ass)
        {
            using (var context = new SchoolContext())
            {
                context.Assignments.Add(ass);
                context.SaveChanges();
            }
        }

        public static List<Assignment> getAssignments()
        {
            List<Assignment> assignments;
            using (var context = new SchoolContext())
            {
                assignments = context.Assignments.ToList();
            }
            return assignments;
        }

        public static List<Assignment> getAssignments(Course course)
        {
            List<Assignment> assignments;
            using (var context = new SchoolContext())
            {
                assignments = context.Assignments.Where(s => s.Courses.Any(c => c.Id.Equals(course.Id))).ToList();
            }
            return assignments;
        }

        internal static void deleteAssignment(Assignment assignment)
        {
            using (var context = new SchoolContext())
            {
                context.Entry(assignment).State = EntityState.Unchanged;
                context.Assignments.Remove(assignment);
                context.SaveChanges();
            }
        }

        internal static void updateAssignment(Assignment ass)
        {
            Console.WriteLine("Update title:");
            string title = Console.ReadLine();
            Console.WriteLine("Update description:");
            string desc = Console.ReadLine();

            DateTime submission;
            do
            {
                Console.WriteLine("Update submission date:");
            } while (!DateTime.TryParse(Console.ReadLine(), out submission));

            decimal oralMark;
            do
            {
                Console.WriteLine("Update oral mark:");
            } while (!Decimal.TryParse(Console.ReadLine(), out oralMark));

            decimal totalMark;
            do
            {
                Console.WriteLine("Update total mark:");
            } while (!Decimal.TryParse(Console.ReadLine(), out totalMark));

            using (var context = new SchoolContext())
            {
                ass = context.Assignments.SingleOrDefault(c => c.Id == ass.Id);
                ass.Title = title;
                ass.Description = desc;
                ass.Submission = submission;
                ass.OralMark = oralMark;
                ass.TotalMark = totalMark;

                context.SaveChanges();
            }
        }
    }
}