using School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace School
{
    public static class StudentManager
    {
        public static List<Course> getNewCourses(Student student)//get courses where student isnt enrolled
        {
            List<Course> newCourses;
            using (var context = new SchoolContext())
            {
                newCourses = context.Courses.Where(c => c.Students.All(s => s.Id != student.Id)).ToList();
            }
            return newCourses;
        }

        public static List<Course> getCurrentCourses(Student student) //get courses where student is enrolled
        {
            List<Course> currentCourses;
            using (var context = new SchoolContext())
            {
                currentCourses = context.Courses.Where(c => c.Students.Any(s => s.Id.Equals(student.Id))).ToList();
            }
            return currentCourses;
        }

        public static List<Assignment> getCurrentAssignments(Student student) //get assignments of courses where student is enrolled
        {
            List<Assignment> currentAssignments;
            using (var context = new SchoolContext())
            {
                currentAssignments = context.Assignments.Where(a => a.Courses.Any(c => c.Students.Any(s => s.Id.Equals(student.Id)))).ToList();
            }
            return currentAssignments;
        }

        public static void enrollStudent(Student student, int newCourseID)
        {
            using (var context = new SchoolContext())
            {
                context.Entry(student).State = EntityState.Unchanged;
                context.Courses.SingleOrDefault(c => c.Id.Equals(newCourseID)).Students.Add(student);
                context.SaveChanges();
            }
        }

        public static List<Assignment> submitAssignment(Student student)
        {
            List<Assignment> pendingAssignments;

            using (var context = new SchoolContext())//get not submitted assignments of courses in which the student is enrolled
            {
                pendingAssignments = context.Assignments.Where(a => a.StudentAssignments.All(sa => sa.StudentID != student.Id) && a.Courses.Any(c => c.Students.Any(s => s.Id.Equals(student.Id)))).ToList();
                return pendingAssignments;
            }
        }

        public static string getUserName()
        {
            StudentAccount studentAccount;
            string userName;
            do
            {
                Console.WriteLine("Please insert username");
                userName = Program.GetStringSha256Hash(Console.ReadLine());
                using (var context = new SchoolContext())
                {
                    studentAccount = context.StudentAccounts.SingleOrDefault(s => s.Username.Equals(userName));
                }
            } while (studentAccount == null);
            return userName;
        }

        public static Student getPassword(string userName)
        {
            string password;
            Student student;
            do
            {
                Console.WriteLine("Please insert password");
                password = Program.GetStringSha256Hash(Console.ReadLine());

                using (var context = new SchoolContext())
                {
                    student = context.Students.SingleOrDefault(s => s.StudentAccount.Password.Equals(password) && s.StudentAccount.Username.Equals(userName));
                }
            } while (student == null);
            return student;
        }

        public static void createStudent(Student studnt)
        {
            using (var context = new SchoolContext())
            {
                context.Students.Add(studnt);
                context.SaveChanges();
            }
        }

        internal static List<Student> getStudents()
        {
            List<Student> students;
            using (var context = new SchoolContext())
            {
                students = context.Students.ToList();
            }
            return students;
        }

        internal static List<Student> getStudents(Course course)
        {
            List<Student> students;
            using (var context = new SchoolContext())
            {
                students = context.Students.Where(s => s.Courses.Any(c => c.Id.Equals(course.Id))).ToList();
            }
            return students;
        }

        internal static void updateStudent(Student student)
        {
            Console.WriteLine("Update first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Update last name:");
            string lastName = Console.ReadLine();

            DateTime birthDate;
            do
            {
                Console.WriteLine("Update birth date:");
            } while (!DateTime.TryParse(Console.ReadLine(), out birthDate));

            decimal tuitionFees;
            do
            {
                Console.WriteLine("Update tuition fees");
            } while (!Decimal.TryParse(Console.ReadLine(), out tuitionFees));

            using (var context = new SchoolContext())
            {
                student = context.Students.SingleOrDefault(c => c.Id == student.Id);
                student.FirstName = firstName;
                student.LastName = lastName;
                student.BirthDate = birthDate;
                student.TuitionFees = tuitionFees;
                context.SaveChanges();
            }
        }

        internal static void deleteStudent(Student student)
        {
            using (var context = new SchoolContext())
            {
                context.Entry(student).State = EntityState.Unchanged;
                context.StudentAccounts.Remove(context.StudentAccounts.SingleOrDefault(sa => sa.StudentAccountID == student.Id));
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}