using GestiuneSaliNET7.Data;
using GestiuneSaliNET7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace GestiuneSaliNET7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ScheduleController(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            Serie x = new Serie();

            
            string json1 = JsonSerializer.Serialize(x);

            // retrieve all reservations from the database
            var reservations = await _context.Reservations.ToListAsync();

            // create a calendar system for a week with the reservations on a 1h time slot system
            var calendar = new List<List<ReservationModel>>();

            for (int i = 0; i < 4; i++) // loop through each day of the week
            {
                var dayReservations = new List<ReservationModel>();

                for (int j = 0; j < 11; j++) // loop through each hour of the day
                {
                    var reservation = reservations.FirstOrDefault(r => r.DayNumber == i && r.StartTimeSlot == j);

                    if (reservation != null)
                    {
                        for(int k = 1; k <= reservation.TimeSlotsUsed; k++)
                        {
                            dayReservations.Add(reservation);
                            j++;
                        }
                    }
                    else
                    {
                        dayReservations.Add(null);
                    }
                }

                calendar.Add(dayReservations);
            }

            return Ok(reservations);
        }
    }
}
