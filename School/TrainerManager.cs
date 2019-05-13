using School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace School
{
    public static class TrainerManager
    {
        public static string getUserName()
        {
            TrainerAccount trainerAccount;
            string userName;
            do
            {
                Console.WriteLine("Please insert username");
                userName = Program.GetStringSha256Hash(Console.ReadLine());
                using (var context = new SchoolContext())
                {
                    trainerAccount = context.TrainerAccounts.SingleOrDefault(s => s.Username.Equals(userName));
                }
            } while (trainerAccount == null);
            return userName;
        }

        public static Trainer getPassword(string userName)
        {
            string password;
            Trainer trainer;
            do
            {
                Console.WriteLine("Please insert password");
                password = Program.GetStringSha256Hash(Console.ReadLine());

                using (var context = new SchoolContext())
                {
                    trainer = context.Trainers.SingleOrDefault(t => t.TrainerAccount.Password.Equals(password) && t.TrainerAccount.Username.Equals(userName));
                }
            } while (trainer == null);
            return trainer;
        }

        public static List<Course> getCourses(Trainer trainer)
        {
            List<Course> currentCourses;
            using (var context = new SchoolContext())
            {
                currentCourses = context.Courses.Where(c => c.Trainers.Any(t => t.Id.Equals(trainer.Id))).ToList();
            }
            return currentCourses;
        }

        public static List<Course> getCourses()
        {
            List<Course> courses;
            using (var context = new SchoolContext())
            {
                courses = context.Courses.ToList();
            }
            return courses;
        }

        public static List<Assignment> getAssignments(Course markCourse)
        {
            List<Assignment> assignments;
            using (var context = new SchoolContext())
            {
                assignments = context.Assignments.Where(a => a.Courses.Any(c => c.Id.Equals(markCourse.Id))).ToList();
            }
            return assignments;
        }

        public static void markAssignment(decimal finalMark, Assignment assignment, Student student)
        {
            using (var context = new SchoolContext())
            {
                context.Entry(assignment).State = EntityState.Unchanged;
                context.Entry(student).State = EntityState.Unchanged;
                context.StudentAssignments.AddOrUpdate(s => new { s.AssignmentID, s.StudentID },
                        new StudentAssignment() { StudentID = student.Id, AssignmentID = assignment.Id, FinalMark = finalMark });
                context.SaveChanges();
            }
        }

        internal static List<Student> getStudents(Course markCourse)
        {
            List<Student> students;
            using (var context = new SchoolContext())
            {
                students = context.Students.Where(s => s.Courses.Any(c => c.Id.Equals(markCourse.Id))).ToList();
            }
            return students;
        }

        internal static void createTrainer(Trainer t)
        {
            using (var context = new SchoolContext())
            {
                context.Trainers.Add(t);
                context.SaveChanges();
            }
        }

        internal static List<Trainer> getTrainers()
        {
            List<Trainer> trainers;
            using (var context = new SchoolContext())
            {
                trainers = context.Trainers.ToList();
            }
            return trainers;
        }

        internal static List<Trainer> getTrainers(Course course)
        {
            List<Trainer> trainers;
            using (var context = new SchoolContext())
            {
                trainers = context.Trainers.Where(s => s.Courses.Any(c => c.Id.Equals(course.Id))).ToList();
            }
            return trainers;
        }

        internal static void deleteTrainer(Trainer trainer)
        {
            using (var context = new SchoolContext())
            {
                context.Entry(trainer).State = EntityState.Unchanged;
                context.TrainerAccounts.Remove(context.TrainerAccounts.SingleOrDefault(t => t.TrainerAccountID == trainer.Id));
                context.Trainers.Remove(trainer);
                context.SaveChanges();
            }
        }

        internal static void updateTrainer(Trainer trainer)
        {
            Console.WriteLine("Update first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Update last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Update subject:");
            string subject = Console.ReadLine();

            using (var context = new SchoolContext())
            {
                trainer = context.Trainers.SingleOrDefault(c => c.Id == trainer.Id);
                trainer.FirstName = firstName;
                trainer.LastName = lastName;
                trainer.Subject = subject;
                context.SaveChanges();
            }
        }
    }
}