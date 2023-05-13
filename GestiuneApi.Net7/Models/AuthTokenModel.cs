using GestiuneSaliNET7.Models;

namespace GestiuneApi.Net7.Models
{
    public class AuthTokenModel : Entity
    {
        public string token { get; set; }

        public string email { get; set; }
    }

}
