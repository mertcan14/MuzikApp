using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuzikMvcApp.Models;

namespace MuzikMvcApp.Controllers
{
    public class MuziksController : Controller
    {
        private readonly MuzikDbContext _context;

        public MuziksController(MuzikDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Muzik.ToListAsync());
        }

        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id==0)
            {
                return View(new Muzik());
            }
            else
            {
                var muzik = await _context.Muzik.FindAsync(id);
                if (muzik == null)
                {
                    return NotFound();
                }
                return View(muzik);
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,SarkiIsmi,AlbumIsmi,Artist,CikisYili")] Muzik muzik)
        {
            if (ModelState.IsValid)
            {
                if (id==0)
                {
                    _context.Add(muzik);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(muzik);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MuzikExists(muzik.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html=Helper.RenderRazorViewToString(this, "Index", _context.Muzik.ToList()), name=muzik.SarkiIsmi});
            }
            return Json(new { isValid = false, html= Helper.RenderRazorViewToString(this, "AddOrEdit", muzik), errMsg="Şarkı Eklenemedi!!"});
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muzik = await _context.Muzik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (muzik == null)
            {
                return NotFound();
            }

            return View(muzik);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDeneme(int id) {
            var muzik = await _context.Muzik.FindAsync(id);
            _context.Muzik.Remove(muzik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuzikExists(int id)
        {
            return _context.Muzik.Any(e => e.Id == id);
        }
    }
}
