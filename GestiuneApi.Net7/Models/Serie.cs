using GestiuneSaliNET7.Models;

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

        public Serie(string idSerie)
        {
            var x = 0;
            int.TryParse(idSerie.First().ToString(), out x);
            Id = x;
            Name = idSerie.Substring(1);

            Grupe = new List<Grupa>()
            {
                new Grupa
                {
                    Id = "0",
                    Name = "3" + Id + "1" + Name
                },
                new Grupa
                {
                    Id = "0",
                    Name = "3" + Id + "2" + Name
                },
                new Grupa
                {
                    Id = "0",
                    Name = "3" + Id + "3" + Name
                },
                new Grupa
                {
                    Id = "0",
                    Name = "3" + Id + "4" + Name
                }
            };
        }
    }
}
