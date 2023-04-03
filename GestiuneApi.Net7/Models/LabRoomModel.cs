using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Models
{
    public class LabRoomModel : Entity
    {
        [Required]
        public int Capacity { get; set; }
        [Required]
        public bool HasComputers { get; set; }
    }
}
