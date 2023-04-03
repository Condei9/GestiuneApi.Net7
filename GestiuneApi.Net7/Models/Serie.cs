namespace GestiuneSaliNET7.Models
{
    public class Serie
    {
        public int Id { get; set; } = 0;
        public List<Grupa> Grupe { get; set; }

        public Serie()
        {
            Grupe = new List<Grupa>()
            {
                new Grupa()
            };
        }
    }
}
