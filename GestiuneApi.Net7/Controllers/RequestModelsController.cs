using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestiuneSaliNET7.Data;
using GestiuneSaliNET7.Models;

namespace GestiuneSaliNET7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestModelsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public RequestModelsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: RequestModels
        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return _context.Requests != null ? 
                          Ok(await _context.Requests.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.Requests'  is null.");
        }

        // GET: RequestModels/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Requests == null)
            {
                return NotFound();
            }

            var requestModel = await _context.Requests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestModel == null)
            {
                return NotFound();
            }

            return Ok(requestModel);
        }

        // POST: RequestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("Cerere,RequestState")] RequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(requestModel);
        }

        // GET: RequestModels/Edit/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Requests == null)
        //    {
        //        return NotFound();
        //    }

        //    var requestModel = await _context.Requests.FindAsync(id);
        //    if (requestModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(requestModel);
        //}

        // POST: RequestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}")]
        
        public async Task<IActionResult> Edit(int id, [Bind("Cerere,RequestState")] RequestModel requestModel)
        {
            if (id != requestModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestModelExists(requestModel.Id))
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
            return Ok(requestModel);
        }

        // GET: RequestModels/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Requests == null)
            {
                return NotFound();
            }

            var requestModel = await _context.Requests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestModel == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(requestModel);

            await _context.SaveChangesAsync();

            return Ok(requestModel);
        }

        /*
        // POST: RequestModels/Delete/5
        [HttpPost("{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Requests == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Requests'  is null.");
            }
            var requestModel = await _context.Requests.FindAsync(id);
            if (requestModel != null)
            {
                _context.Requests.Remove(requestModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */
        private bool RequestModelExists(int id)
        {
          return (_context.Requests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
