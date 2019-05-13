using System.Collections.Generic;

namespace School.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual TrainerAccount TrainerAccount { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Subject: {Subject}";
        }
    }
}