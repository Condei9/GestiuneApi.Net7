using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Interfaces
{
    public interface IReservation
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
    }
}
