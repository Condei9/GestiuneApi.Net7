namespace GestiuneSaliNET7.Models
{
    public class Subgrupa
    {
        public int Id { get; set; } = 0;
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
