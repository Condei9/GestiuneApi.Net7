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

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(string? id)
        {
            Serie x = new Serie(id);
            
            string json1 = JsonSerializer.Serialize(x);

            // retrieve all reservations from the database
            var reservations = await _context.Reservations.Where(f => f.Serie == id).ToListAsync();

            // de adaptat algoritmul pt serie
            foreach(var reservation in reservations) 
            {
                var aux = x.Grupe.FirstOrDefault(a => reservation.Group.Contains(a.Name));

                var subgr = aux.Subgrupe.FirstOrDefault(b => b.Id == reservation.Subgroup);

                subgr.Week[reservation.DayNumber].Reservations[reservation.StartTimeSlot] = reservation;

                for(int i = 1; i < reservation.TimeSlotsUsed; i++)
                {
                   
                        subgr.Week[reservation.DayNumber].Reservations.RemoveAt(reservation.StartTimeSlot + 1);
                   
                }
            }
           
            return Ok(x);
        }
    }
}
