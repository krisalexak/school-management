using School.Models;
using System;
using System.Collections.Generic;

namespace School
{
    public class AssignmentView
    {
        public static Assignment createAssignment()
        {
            Console.WriteLine("Enter title:");
            var title = Console.ReadLine();
            Console.WriteLine("Enter description:");
            var desc = Console.ReadLine();
            DateTime submission;
            do
            {
                Console.WriteLine("Enter submission date:");
            } while (!DateTime.TryParse(Console.ReadLine(), out submission));

            decimal oralMark;
            do
            {
                Console.WriteLine("Enter oral mark:");
            } while (!Decimal.TryParse(Console.ReadLine(), out oralMark));
            decimal totalMark;
            do
            {
                Console.WriteLine("Enter total mark:");
            } while (!Decimal.TryParse(Console.ReadLine(), out totalMark));
            Assignment ass = new Assignment { Title = title, Description = desc, Submission = submission, OralMark = oralMark, TotalMark = totalMark };

            return ass;
        }

        public static Assignment createAssignment(Course course)
        {
            Console.WriteLine("Enter title:");
            var title = Console.ReadLine();
            Console.WriteLine("Enter description:");
            var desc = Console.ReadLine();
            DateTime submission;
            do
            {
                Console.WriteLine("Enter submission date:");
            } while (!DateTime.TryParse(Console.ReadLine(), out submission));

            decimal oralMark;
            do
            {
                Console.WriteLine("Enter oral mark:");
            } while (!Decimal.TryParse(Console.ReadLine(), out oralMark));
            decimal totalMark;
            do
            {
                Console.WriteLine("Enter total mark:");
            } while (!Decimal.TryParse(Console.ReadLine(), out totalMark));
            Assignment ass = new Assignment { Title = title, Description = desc, Submission = submission, OralMark = oralMark, TotalMark = totalMark, Courses = new List<Course> { course } };

            return ass;
        }

        public static void showAssignments(List<Assignment> assignments)
        {
            using (var context = new SchoolContext())
            {
                foreach (var a in assignments)
                {
                    Console.WriteLine(a.ToString());
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static int assignmentMenu(List<Assignment> assignments)
        {
            int userInput;
            do
            {
                for (int i = 0; i < assignments.Count; i++)
                {
                    Console.WriteLine($"Press {i} to update/delete course: {assignments[i].ToString()}");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }
    }
}