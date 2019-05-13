using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class TrainerAccount
    {
        [Key, ForeignKey("Trainer")]
        public int TrainerAccountID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}