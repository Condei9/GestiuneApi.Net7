using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Models
{
    public class RoomModel : Entity
    {
        [Required]
        int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int Capacity { get; set; }
    }
}
