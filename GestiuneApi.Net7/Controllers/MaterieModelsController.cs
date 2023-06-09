﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestiuneSaliNET7.Data;
using GestiuneSaliNET7.Models;
using GestiuneSaliNET7.Utils;
using GestiuneApi.Net7.Models;

namespace GestiuneSaliNET7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterieModelsController : Controller
    {
        private readonly ApplicationDBContext _context;
        public MaterieModelsController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.Materii != null ?
                        Ok(await _context.Materii.ToListAsync()) :
                        Problem("Entity set 'ApplicationDBContext.Users'  is null.");
        }

        [HttpGet("search")]
        public async Task<IActionResult> Details([FromQuery]int? anMaterie)
        {
            if (anMaterie == null || _context.Materii == null)
            {
                return NotFound(StatusCode(404));
            }

            var materieModel = await _context.Materii.Where(x=>x.anMaterie==anMaterie).ToListAsync();
               
            if (materieModel == null)
            {
                return NotFound(StatusCode(404));
            }

            return Ok(materieModel);
        }

       
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details2(int? id)
        {
            if (id == null || _context.Materii == null)
            {
                return NotFound(StatusCode(404));
            }

            var materieModel = await _context.Materii
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materieModel == null)
            {
                return NotFound(StatusCode(404));
            }

            return Ok(materieModel);
        }
       
        [HttpPost]
        public async Task<IActionResult> Create( MaterieModel materieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materieModel);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return Ok(StatusCode(200));
            }
            return Ok(StatusCode(200));
               
        }
       
        [HttpPost("{id}")]
        
        public async Task<IActionResult> Edit(int id,  MaterieModel materieModel)
        {
            if (id != materieModel.Id)
            {
                return NotFound(StatusCode(404));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterieModelExists(materieModel.Id))
                    {
                        return NotFound(StatusCode(404));
                    }
                    else
                    {
                        
                        throw;
                       
                    }
                }
                 //return RedirectToAction(nameof(Index));
                return Ok(StatusCode(200));
            }
            //  return Ok(StatusCode(200));
            return Ok(StatusCode(200));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Materii == null)
            {
                return NotFound();
            }

            var materieModel = await _context.Materii
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materieModel == null)
            {
                return NotFound();
            }

            _context.Materii.Remove(materieModel);

            await _context.SaveChangesAsync();

             return Ok(StatusCode(200));
            
           // return StatusCode(200);
        }

        private bool MaterieModelExists(int id)
        {
            return (_context.Materii?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
