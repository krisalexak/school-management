using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class StudentAssignment
    {
        [Key, Column(Order = 0)]
        public int StudentID { get; set; }

        [Key, Column(Order = 1)]
        public int AssignmentID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Assignment Assignment { get; set; }

        public decimal FinalMark { get; set; }

        public override string ToString()
        {
            return $"FinalMark: {FinalMark}";
        }
    }
}