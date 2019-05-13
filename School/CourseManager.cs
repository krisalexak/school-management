using School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace School
{
    public static class CourseManager
    {
        public static void createCourse(Course course)
        {
            using (var context = new SchoolContext())
            {
                context.Courses.Add(course);
                context.SaveChanges();
            }
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

        public static void updateCourse(Course course)
        {
            Console.WriteLine("Update course title:");
            string title = Console.ReadLine();
            Console.WriteLine("Update course stream:");
            string stream = Console.ReadLine();
            Console.WriteLine("Update course type:");
            string type = Console.ReadLine();
            DateTime startDate;
            do
            {
                Console.WriteLine("Update start date:");
            } while (!DateTime.TryParse(Console.ReadLine(), out startDate));

            DateTime endDate;
            do
            {
                Console.WriteLine("Update end date:");
            } while (!DateTime.TryParse(Console.ReadLine(), out endDate));

            Console.WriteLine("Update schedule:");
            var schedule = Console.ReadLine();

            using (var context = new SchoolContext())
            {
                course = context.Courses.SingleOrDefault(c => c.Id == course.Id);
                course.Title = title;
                course.Stream = stream;
                course.Type = type;
                course.StartDate = startDate;
                course.EndDate = endDate;
                course.Schedule = schedule;
                context.SaveChanges();
            }
        }

        public static void deleteCourse(Course course)
        {
            using (var context = new SchoolContext())
            {
                context.Entry(course).State = EntityState.Unchanged;
                context.Courses.Remove(course);
                context.SaveChanges();
            }
        }

        public static void updateSchedule(Course course)
        {
            Console.WriteLine("Write a new schedule for the selected course:");
            var schedule = Console.ReadLine();
            using (var context = new SchoolContext())
            {
                course = context.Courses.SingleOrDefault(c => c.Id == course.Id);
                course.Schedule = schedule;
                context.SaveChanges();
            }
        }
    }
}