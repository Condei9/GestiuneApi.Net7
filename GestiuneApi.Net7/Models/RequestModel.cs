using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Models
{
    public class RequestModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string User { get; set; }

        public string Room { get; set; }

        public string Groups { get; set; }


    }
}
