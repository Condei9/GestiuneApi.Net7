using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestiuneSaliNET7.Data;
using GestiuneSaliNET7.Models;
using GestiuneSaliNET7.Interfaces;

namespace GestiuneSaliNET7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationModelController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ReservationModelController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: ReservationModel
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.Reservations != null ?
                        Ok(await _context.Reservations.ToListAsync()) :
                        Problem("Entity set 'ApplicationDBContext.Reservations'  is null.");
        }

        // GET: ReservationModel/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservationModel = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationModel == null)
            {
                return NotFound();
            }

            return Ok(reservationModel);
        }

        // POST: ReservationModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
       
        public async Task<IActionResult> Create([Bind("Groups,TeacherName,DayNumber,RoomId,Time,Duration,Group,Subgroup,Serie,Name")] ReservationModel reservationModel)
        {
            if (ModelState.IsValid)
            {

                var reservation = new ReservationModel();
                var resList = new List<ReservationModel>();

                if (!reservationModel.IsLab && reservationModel.Groups)
                {
                    var grupa = 0;
                    var subgrupa = 0;
                    
                    for (int i = 0; i < 8; i++)
                    {
                        subgrupa = i % 2 == 0 ? 1 : 2;
                        grupa = i % 2 == 0 ? grupa + 1 : grupa;
                        reservation = new ReservationModel
                        {
                            Id = reservationModel.Id,
                            Name = reservationModel.Name,
                            Groups = reservationModel.Groups,
                            TeacherName = reservationModel.TeacherName,
                            DayNumber = reservationModel.DayNumber,
                            RoomName = reservationModel.RoomName,
                            StartTimeSlot = reservationModel.StartTimeSlot,
                            TimeSlotsUsed = reservationModel.TimeSlotsUsed,
                            Group = reservationModel.Group,
                            Subgroup = reservationModel.Subgroup,
                            Serie = reservationModel.Serie,
                            IsOnParity= reservationModel.IsOnParity,
                            SubjectName = reservationModel.SubjectName,
                            IsLab = reservationModel.IsLab
                        };
                        reservation.Group = "3" + reservation.Serie.Substring(0, 1) + grupa + reservation.Serie[1..];
                        reservation.Subgroup = subgrupa;
                        resList.Add(reservation);
                    }
                    _context.Reservations.AddRange(resList);

                }
                else if(reservationModel.IsLab && reservationModel.Groups)
                {

                 
                    var subgrupa = 1;
                    for (int i = 0; i < 2; i++)
                    {
             
                        subgrupa++;
                        reservation = new ReservationModel
                        {
                            Id = reservationModel.Id,
                            Name = reservationModel.Name,
                            Groups = reservationModel.Groups,
                            TeacherName = reservationModel.TeacherName,
                            DayNumber = reservationModel.DayNumber,
                            RoomName = reservationModel.RoomName,
                            StartTimeSlot = reservationModel.StartTimeSlot,
                            TimeSlotsUsed = reservationModel.TimeSlotsUsed,
                            Group = reservationModel.Group,
                            Subgroup = reservationModel.Subgroup,
                            Serie = reservationModel.Serie,
                            IsOnParity = reservationModel.IsOnParity,
                            SubjectName = reservationModel.SubjectName,
                            IsLab = reservationModel.IsLab
                        }; ;
                        reservation.Group = "3" + reservation.Serie.Substring(0, 1) + reservationModel.Group + reservation.Serie[1..];
                        reservation.Subgroup = subgrupa;
                    }
                    _context.Reservations.AddRange(resList);
                }
                else
                {
                        reservation = reservationModel;
                        reservation.Group = "3" + reservation.Serie.Substring(0, 1) + reservationModel.Group + reservation.Serie[1..];
                        _context.Add(reservation);
                }
                  await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return Ok(reservationModel);
        }

        // POST: ReservationModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}")]
       
        public async Task<IActionResult> Edit(int id, [Bind("Groups,TeacherName,DayNumber,RoomId,Time,Duration,Group,Subgroup,Serie,Name")] ReservationModel reservationModel)
        {
            if (id != reservationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationModelExists(reservationModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return Ok(reservationModel);
        }

        // GET: ReservationModel/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservationModel = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationModel == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservationModel);

            await _context.SaveChangesAsync();

            return Ok(reservationModel);
        }

        /*
        // POST: ReservationModel/Delete/5
        [HttpPost("{Id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Reservations'  is null.");
            }
            var reservationModel = await _context.Reservations.FindAsync(id);
            if (reservationModel != null)
            {
                _context.Reservations.Remove(reservationModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */
        private bool ReservationModelExists(int id)
        {
          return (_context.Reservations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
