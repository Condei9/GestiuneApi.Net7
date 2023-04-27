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
                new Day()
            };
        }
    }
}
