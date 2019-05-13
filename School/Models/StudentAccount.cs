using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class StudentAccount
    {
        [Key, ForeignKey("Student")]
        public int StudentAccountID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Student Student { get; set; }
    }
}