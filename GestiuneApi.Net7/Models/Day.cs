namespace GestiuneSaliNET7.Models
{
    public class Day
    {
        public int Id { get; set; } = 0;
        public string? Name { get; set; }
        public List<ReservationModel> Reservations { get; set; }

        public Day() 
        {
            Reservations = new List<ReservationModel>
            {
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            };
        }
    }
}
