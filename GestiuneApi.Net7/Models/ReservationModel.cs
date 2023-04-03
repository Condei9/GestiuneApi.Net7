using GestiuneSaliNET7.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Models
{
    public class ReservationModel : Entity
    {
        [Required]
        public string? Groups { get; set; }
        [Required]
        public string? TeacherName { get; set; }
        [Required]
        public int DayNumber { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int StartTimeSlot { get; set; }
        [Required]
        public int TimeSlotsUsed { get; set; }
        [Required]
        public string? Group { get; set; }
        [Required]
        public bool IsActive { get; set; } = false;

        public ReservationModel()
        {

            Groups = "Alo";
            TeacherName = "Alo";
            DayNumber = 0;
            RoomId = 0;
            Group = "Alo";
            IsActive = false;

        }

    }
}
