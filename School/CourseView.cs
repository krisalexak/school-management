using School.Models;
using System;
using System.Collections.Generic;

namespace School
{
    public class CourseView
    {
        public static Course createCourse()
        {
            Course course;
            Console.WriteLine("Give a course title:");
            string title = Console.ReadLine();
            Console.WriteLine("Give a course stream:");
            string stream = Console.ReadLine();
            Console.WriteLine("Give a course type:");
            string type = Console.ReadLine();
            DateTime startDate;
            do
            {
                Console.WriteLine("Enter start date:");
            } while (!DateTime.TryParse(Console.ReadLine(), out startDate));

            DateTime endDate;
            do
            {
                Console.WriteLine("Enter end date:");
            } while (!DateTime.TryParse(Console.ReadLine(), out endDate));

            Console.WriteLine("Enter schedule:");
            var schedule = Console.ReadLine();
            return course = new Course() { Title = title, Stream = stream, Type = type, StartDate = startDate, EndDate = endDate, Schedule = schedule };
        }

        public static void showCourses(List<Course> courses)
        {
            using (var context = new SchoolContext())
            {
                foreach (var c in courses)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static int courseMenu(List<Course> courses)
        {
            int userInput;
            do
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"Press {i} to select course: {courses[i].ToString()}");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }
    }
}