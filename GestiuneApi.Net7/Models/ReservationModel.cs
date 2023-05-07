using GestiuneSaliNET7.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Models
{
    public class ReservationModel : Entity
    {
        [Required]
        public bool Groups { get; set; }
        [Required]
        public string? TeacherName { get; set; }
        [Required]
        public int DayNumber { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Required]
        public int StartTimeSlot { get; set; }
        [Required]
        public int TimeSlotsUsed { get; set; }
        [Required]
        public string? Group { get; set; }
        [Required]
        public int Subgroup { get; set; }
        [Required]
        public string? Serie { get; set; }
        [Required]
        public int IsOnParity { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public bool IsLab { get; set; }

        public ReservationModel()
        {

            Groups = false;
            TeacherName = "Alo";
            DayNumber = 0;
            RoomName = "0";
            Group = "Alo";
            IsOnParity = 2;
            SubjectName= "0";
            IsLab = false;

        }

    }
}
