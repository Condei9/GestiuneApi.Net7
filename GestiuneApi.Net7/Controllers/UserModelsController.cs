using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestiuneSaliNET7.Data;
using GestiuneSaliNET7.Models;
using GestiuneSaliNET7.Utils;
using Microsoft.IdentityModel.Tokens;
using GestiuneSaliNET7.Interfaces;

namespace GestiuneSaliNET7.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UserModelsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public UserModelsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: UserModels
        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return _context.Users != null ? 
                          Ok(await _context.Users.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.Users'  is null.");
        }

        // GET: UserModels/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var userModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel);
        }

        // POST: UserModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("Email,Password,Role,Name")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                userModel.Password = userModel.Password.Hash();
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return Ok(StatusCode(200));
            }
            //  return Ok(userModel);
            return Ok(StatusCode(200));
        }

        // POST: UserModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}")]
        
        public async Task<IActionResult> Edit(int id, [Bind("Email,Password,Role,Name")] UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return NotFound();
            }
            var currentUser = _context.Users.FirstOrDefault(u => u.Id == id);

            if (ModelState.IsValid)
            {
                try
                {
                   
                  
                 if(currentUser != null) {  
                        if (userModel != null && !userModel.Name.IsNullOrEmpty() && userModel.Name != currentUser.Name)
                        {
                            currentUser.Name = userModel.Name;
                        }

                        if (userModel != null && !userModel.Email.IsNullOrEmpty()  && userModel.Email != currentUser.Email)
                        {
                            currentUser.Email = userModel.Email;
                        }

                        if (userModel != null && !userModel.Password.IsNullOrEmpty()   && userModel.Password != currentUser.Password )
                        {
                            currentUser.Password = userModel.Password.Hash();
                        }

                        if (  userModel.Role != currentUser.Role)
                        {
                            currentUser.Role = userModel.Role;
                        }


                        if (userModel.Serie != currentUser.Serie)
                        {
                            currentUser.Serie = userModel.Serie;
                        }

                        if (userModel.Grupa != currentUser.Grupa && !userModel.Serie.IsNullOrEmpty())
                        {
                            currentUser.Grupa = "3" + userModel.Serie.Substring(0, 1) + userModel.Grupa + userModel.Serie[1..] ;
                        }

                        if (userModel.Materie != currentUser.Materie)
                        {
                            currentUser.Materie = userModel.Materie;
                        }




                        _context.Update(currentUser);
                    await _context.SaveChangesAsync();
                    

                    }
                 else { return NotFound(); }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // return RedirectToAction(nameof(Index));
                return Ok(currentUser);
            }
            // return Ok(userModel);
            return Ok(currentUser);
        }

        [HttpGet("search")]
        public async Task<IActionResult> getUsersByMaterie([FromQuery] string? Materie)
        {
            if (Materie == null || _context.Users == null)
            {
                return NotFound(StatusCode(404));
            }

            var userModel = await _context.Users.Where(x => x.Materie == Materie).ToListAsync();
            

            if (userModel == null)
            {
                return NotFound(StatusCode(404));
            }

            return Ok(userModel);
        }

        // GET: UserModels/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound(StatusCode(404));
            }

            var userModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound(StatusCode(404));
            }

            _context.Users.Remove(userModel);

            await _context.SaveChangesAsync();

            // return Ok(userModel);
            return Ok(StatusCode(200));
        }

        /*
        // POST: UserModels/Delete/5
        [HttpPost("{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Users'  is null.");
            }
            var userModel = await _context.Users.FindAsync(id);
            if (userModel != null)
            {
                _context.Users.Remove(userModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */
        private bool UserModelExists(int id)
        {
          return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
