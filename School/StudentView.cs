using School.Models;
using System;
using System.Collections.Generic;

namespace School
{
    internal class StudentView
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
                Console.WriteLine("Press 1 to enroll to a course");
                Console.WriteLine("Press 2 to submit an assignment");
                Console.WriteLine("Press 3 to see the daily schedule per course");
                Console.WriteLine("Press 4 to see the dates of submission of the Assignments per course");
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static int enrollMenu(List<Course> courses)
        {
            int userInput;
            do
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"Press {i}. to enroll to the course: {courses[i].ToString()}");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static int submitAssignment(List<Assignment> currentAssignments)
        {
            int userInput;
            do
            {
                for (int i = 0; i < currentAssignments.Count; i++)
                {
                    Console.WriteLine($"Press {i} to submit the assignment: {currentAssignments[i].ToString()}");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public static void enrollFail()
        {
            Console.WriteLine();
            Console.WriteLine("There are no available courses for you");
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        public static void showSchedule(List<Course> currentCourses)
        {
            foreach (var course in currentCourses)
            {
                Console.WriteLine($"The Schedule for the course: {course.Title}, {course.Stream}, {course.Type} is : {course.Schedule}");
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        public static void showSubmissionDates(List<Assignment> currentAssignments)
        {
            foreach (var ass in currentAssignments)
            {
                Console.WriteLine($"The submission dates for the assignment: {ass.Title} with ID: {ass.Id} is : {ass.Submission}");
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        internal static Student createStudent()
        {
            Console.WriteLine("Enter first name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            var lastName = Console.ReadLine();
            DateTime birthDate;
            do
            {
                Console.WriteLine("Enter birthdate:");
            } while (!DateTime.TryParse(Console.ReadLine(), out birthDate));
            Console.WriteLine("Enter tuition fees:");
            decimal tuitionFees;
            do
            {
                Console.WriteLine("Enter tuition fees:");
            } while (!Decimal.TryParse(Console.ReadLine(), out tuitionFees));
            Student studnt = new Student { FirstName = firstName, LastName = lastName, BirthDate = birthDate, TuitionFees = tuitionFees };

            return studnt;
        }

        internal static Student createStudent(Course course)
        {
            Console.WriteLine("Enter first name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            var lastName = Console.ReadLine();
            DateTime birthDate;
            do
            {
                Console.WriteLine("Enter birthdate:");
            } while (!DateTime.TryParse(Console.ReadLine(), out birthDate));
            Console.WriteLine("Enter tuition fees:");
            decimal tuitionFees;
            do
            {
                Console.WriteLine("Enter tuition fees:");
            } while (!Decimal.TryParse(Console.ReadLine(), out tuitionFees));
            Student studnt = new Student { FirstName = firstName, LastName = lastName, BirthDate = birthDate, TuitionFees = tuitionFees, Courses = new List<Course> { course } };

            return studnt;
        }

        internal static void showStudents(List<Student> students)
        {
            using (var context = new SchoolContext())
            {
                foreach (var s in students)
                {
                    Console.WriteLine(s.ToString());
                }
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        internal static int studentMenu(List<Student> students)
        {
            int userInput;
            do
            {
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"Press {i} to update/delete student: {students[i].ToString()}");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }
    }
}