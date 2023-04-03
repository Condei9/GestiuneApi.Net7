using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Models
{
    public class Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
