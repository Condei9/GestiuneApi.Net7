using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace GestiuneSaliNET7.Models
{
    public class UserModel : Entity
    {
        [Required]
        public string Email { get; set; }
        
        public string Password { get; set; }
        [Required]
        public int Role { get; set; }
        
        public string? Serie { get; set; }
        
        public string? Grupa  { get; set; }

        public string? Materie  { get; set; }


    }
}
