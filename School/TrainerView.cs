using School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace School
{
    public static class TrainerView
    {
        public static int menu()
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("                                          MENU");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("Press 0 to exit application");
                Console.WriteLine("Press 1 to view all your courses");
                Console.WriteLine("Press 2 to view all the students per course");
                Console.WriteLine("Press 3 to view all the assignments per student per course");
                Console.WriteLine("Press 4 to mark all the assignments per student per course");
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static void showCourses(List<Course> currentCourses)
        {
            foreach (var course in currentCourses)
            {
                Console.WriteLine(course.ToString());
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        public static void showCoursesFail()
        {
            Console.WriteLine();
            Console.WriteLine("You are not enrolled to any courses");
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        public static void showStudents(List<Course> courses)
        {
            using (var context = new SchoolContext())
            {
                foreach (var c in courses)
                {
                    context.Entry(c).State = EntityState.Unchanged;
                    Console.WriteLine(c.ToString());
                    Console.WriteLine();
                    foreach (var s in c.Students)
                    {
                        Console.WriteLine("    " + s.ToString());
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        public static void showStudentsFail()
        {
            Console.WriteLine();
            Console.WriteLine("There are no students");
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        public static void showAssignments(List<Course> courses)
        {
            using (var context = new SchoolContext())
            {
                foreach (var c in courses)
                {
                    context.Entry(c).State = EntityState.Unchanged;
                    Console.WriteLine(c.ToString());
                    Console.WriteLine();
                    foreach (var s in c.Students)
                    {
                        Console.WriteLine("   " + s.ToString());

                        foreach (var sa in s.StudentAssignments)
                        {
                            Console.WriteLine("      " + sa.Assignment.ToString());
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        public static int selectCourse(List<Course> courses)
        {
            int userInput;
            do
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"Press {i} to select the course: {courses[i].ToString()}");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        internal static int selectStudent(List<Student> markStudents)
        {
            int userInput;
            do
            {
                for (int i = 0; i < markStudents.Count; i++)
                {
                    Console.WriteLine($"Press {i} to mark the student: {markStudents[i].ToString()}");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static decimal markAssignment()
        {
            decimal userInput;
            do
            {
                Console.WriteLine("Insert the final mark");
            } while (!decimal.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static int selectAssignment(List<Assignment> assignments)
        {
            int userInput;
            do
            {
                for (int i = 0; i < assignments.Count; i++)
                {
                    Console.WriteLine($"Press {i} to select the assignment: {assignments[i].ToString()}");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static Trainer createTrainer()
        {
            Console.WriteLine("Enter first name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Enter subject");
            var subject = Console.ReadLine();
            Trainer trnr = new Trainer { FirstName = firstName, LastName = lastName, Subject = subject };

            return trnr;
        }

        public static Trainer createTrainer(Course course)
        {
            Console.WriteLine("Enter first name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Enter subject");
            var subject = Console.ReadLine();
            Trainer trnr = new Trainer { FirstName = firstName, LastName = lastName, Subject = subject, Courses = new List<Course> { course } };

            return trnr;
        }

        internal static void showTrainers(List<Trainer> trainers)
        {
            using (var context = new SchoolContext())
            {
                foreach (var t in trainers)
                {
                    Console.WriteLine(t.ToString());
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        internal static int trainerMenu(List<Trainer> trainers)
        {
            int userInput;
            do
            {
                for (int i = 0; i < trainers.Count; i++)
                {
                    Console.WriteLine($"Press {i} to update/delete course: {trainers[i].ToString()}");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }
    }
}