using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Models
{
    public class RequestModel : Entity
    {
        public string User { get; set; }

        public string Cerere { get; set; }
    }
}
