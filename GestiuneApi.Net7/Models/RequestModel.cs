using System.ComponentModel.DataAnnotations;

namespace GestiuneSaliNET7.Models
{
    public class RequestModel : Entity
    {
       

        public string Cerere { get; set; }
        public int RequestState { get; set; }

    }
}
