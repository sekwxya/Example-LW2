using System.ComponentModel.DataAnnotations;

namespace _2LR.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
