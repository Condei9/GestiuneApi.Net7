namespace GestiuneSaliNET7.Models
{
    public class Grupa
    {
        public string Id { get; set; } = "0";
        public List<Subgrupa> Subgrupe { get; set; }

        public Grupa()
        {
            Subgrupe = new List<Subgrupa>()
            {
                new Subgrupa()
            };
        }
    }
}
