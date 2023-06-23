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
using GestiuneSaliNET7.Interfaces;

namespace GestiuneSaliNET7.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class SerieModelsController : Controller
     {
         private readonly ApplicationDBContext _context;
         public SerieModelsController(ApplicationDBContext context)
         {
             _context = context;
         }
         [HttpGet]
         public async Task<IActionResult> Index()
         {
             return _context.Serii != null ?
                         Ok(await _context.Serii.ToListAsync()) :
                         Problem("Entity set 'ApplicationDBContext.Users'  is null.");
         }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details2(int? id)
        {
            if (id == null || _context.Serii == null)
            {
                return NotFound(StatusCode(404));
            }

            var serieModel = await _context.Serii
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serieModel == null)
            {
                return NotFound(StatusCode(404));
            }

            return Ok(serieModel);
        }

        [HttpPost]
         public async Task<IActionResult> Create(SerieModel serieModel)
         {

             if (ModelState.IsValid)
             {
                 var serie = new SerieModel();
                 serie = new SerieModel
                 {
                     Id = serieModel.Id,
                     Name = serieModel.Name,
                     anStudiu = serieModel.anStudiu,
                     nrStudenti = serieModel.nrStudenti
                 };
                 serie.Name = serieModel.anStudiu.ToString() + serieModel.Name;
               
                 _context.Add(serie);
                 await _context.SaveChangesAsync();
                 // return RedirectToAction(nameof(Index));
                 return Ok(StatusCode(200));
             }
             return Ok(StatusCode(200));
         }

         [HttpPost("{id}")]
         public async Task<IActionResult> Edit(int id, SerieModel serieModel)
         {
             if (id != serieModel.Id)
             {
                 return NotFound(StatusCode(404));
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                    var currentSerie = serieModel;
                    var serie = new SerieModel();

                    if (currentSerie.Name.Length == 2)
                    {
                       
                        serie = new SerieModel
                        {
                            Id = serieModel.Id,
                            Name = serieModel.Name,
                            anStudiu = serieModel.anStudiu,
                            nrStudenti = serieModel.nrStudenti
                        };
                        serie.Name = serieModel.anStudiu.ToString() + serieModel.Name;
                    }
                    else
                    {
                        serie = serieModel;
                    }

                     _context.Update(serie);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!SerieModelExists(serieModel.Id))
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
             if (id == null || _context.Serii == null)
             {
                 return NotFound();
             }

             var serieModel = await _context.Serii
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (serieModel == null)
             {
                 return NotFound();
             }

             _context.Serii.Remove(serieModel);

             await _context.SaveChangesAsync();

             return Ok(StatusCode(200));

             // return StatusCode(200);
         }


         private bool SerieModelExists(int id)
         {
             return (_context.Serii?.Any(e => e.Id == id)).GetValueOrDefault();
         } 
} 

}
