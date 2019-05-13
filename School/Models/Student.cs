using System;
using System.Collections.Generic;

namespace School.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal TuitionFees { get; set; }

        public virtual StudentAccount StudentAccount { get; set; }
        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public override string ToString()
        {
            return $"FirstName: {FirstName}, LastName: {LastName}, BirthDate: {BirthDate}, TuitionFees: {TuitionFees} ";
        }
    }
}