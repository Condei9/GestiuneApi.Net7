using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Models
{
    public class UserModel : Entity
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Role { get; set; }
    }
}
