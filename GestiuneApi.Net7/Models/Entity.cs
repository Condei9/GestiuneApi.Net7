using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Models
{
    public class Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }

      
        public string Name { get; set; }
    }
}
