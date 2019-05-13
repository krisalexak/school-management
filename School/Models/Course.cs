using System;
using System.Collections.Generic;

namespace School.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Schedule { get; set; }

        public virtual ICollection<Trainer> Trainers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, Stream: {Stream}, Type: {Type}, StartDate: {StartDate.ToShortDateString()}, EndDate: {EndDate.ToShortDateString()}, Schedule: {Schedule}";
        }
    }
}