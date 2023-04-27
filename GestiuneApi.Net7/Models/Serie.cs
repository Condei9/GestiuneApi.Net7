namespace GestiuneSaliNET7.Models
{
    public class Serie
    {
        public int Id { get; set; } = 0;
        public string? Name { get; set; }
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
