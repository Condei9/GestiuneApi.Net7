using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Models
{
    public class RoomModel : Entity
    {
       
        [Required]
        public int Capacity { get; set; }
    }
}
