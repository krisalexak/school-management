using System;
using System.Collections.Generic;

namespace School.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Submission { get; set; }
        public decimal OralMark { get; set; }
        public decimal TotalMark { get; set; }

        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, Description: {Description}, Submission: {Submission}, OralMark: {OralMark}, TotalMark: {TotalMark}";
        }
    }
}