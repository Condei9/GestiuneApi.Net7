namespace GestiuneSaliNET7.Models
{
    public class Subgrupa
    {
        public int Id { get; set; } = 0;
        public string? Name { get; set; }
        public List<Day> Week { get; set; }

        public Subgrupa() 
        {
            Week = new List<Day>()
            {
                new Day
                {
                    Id = 0,
                    Name = "Luni"
                },
                new Day
                {
                    Id = 1,
                    Name = "Marti"
                },
                new Day
                {
                    Id = 2,
                    Name = "Miercuri"
                },
                new Day
                {
                    Id = 3,
                    Name = "Joi"
                },
                new Day
                {
                    Id = 4,
                    Name = "Vineri"
                },
            };
        }
    }
}
