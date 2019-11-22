using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectosoft1._4.Models;

namespace proyectosoft1._4.Controllers
{
    public class ComerciosController : Controller
    {
        private readonly proyectosoftwareContext _context;

        public ComerciosController(proyectosoftwareContext context)
        {
            _context = context;
        }

        // GET: Comercios
        public async Task<IActionResult> Index()
        {
            var proyectosoftwareContext = _context.Comercio.Include(c => c.ComPro).Include(c => c.ComUb).Include(c => c.ComUs);
            return View(await proyectosoftwareContext.ToListAsync());
        }

        // GET: Comercios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comercio = await _context.Comercio
                .Include(c => c.ComPro)
                .Include(c => c.ComUb)
                .Include(c => c.ComUs)
                .FirstOrDefaultAsync(m => m.ComId == id);
            if (comercio == null)
            {
                return NotFound();
            }

            return View(comercio);
        }

        // GET: Comercios/Create
        public IActionResult Create()
        {
            ViewData["ComProId"] = new SelectList(_context.Producto, "ProId", "ProId");
            ViewData["ComUbId"] = new SelectList(_context.Ubicacion, "UbId", "UbId");
            ViewData["ComUsId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: Comercios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComId,ComNombre,ComUbicacion,ComDescripcion,ComDireccion,ComUsId,ComUbId,ComProId")] Comercio comercio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comercio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComProId"] = new SelectList(_context.Producto, "ProId", "ProId", comercio.ComProId);
            ViewData["ComUbId"] = new SelectList(_context.Ubicacion, "UbId", "UbId", comercio.ComUbId);
            ViewData["ComUsId"] = new SelectList(_context.AspNetUsers, "Id", "Id", comercio.ComUsId);
            return View(comercio);
        }

        // GET: Comercios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comercio = await _context.Comercio.FindAsync(id);
            if (comercio == null)
            {
                return NotFound();
            }
            ViewData["ComProId"] = new SelectList(_context.Producto, "ProId", "ProId", comercio.ComProId);
            ViewData["ComUbId"] = new SelectList(_context.Ubicacion, "UbId", "UbId", comercio.ComUbId);
            ViewData["ComUsId"] = new SelectList(_context.AspNetUsers, "Id", "Id", comercio.ComUsId);
            return View(comercio);
        }

        // POST: Comercios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ComId,ComNombre,ComUbicacion,ComDescripcion,ComDireccion,ComUsId,ComUbId,ComProId")] Comercio comercio)
        {
            if (id != comercio.ComId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comercio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComercioExists(comercio.ComId))
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
            ViewData["ComProId"] = new SelectList(_context.Producto, "ProId", "ProId", comercio.ComProId);
            ViewData["ComUbId"] = new SelectList(_context.Ubicacion, "UbId", "UbId", comercio.ComUbId);
            ViewData["ComUsId"] = new SelectList(_context.AspNetUsers, "Id", "Id", comercio.ComUsId);
            return View(comercio);
        }

        // GET: Comercios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comercio = await _context.Comercio
                .Include(c => c.ComPro)
                .Include(c => c.ComUb)
                .Include(c => c.ComUs)
                .FirstOrDefaultAsync(m => m.ComId == id);
            if (comercio == null)
            {
                return NotFound();
            }

            return View(comercio);
        }

        // POST: Comercios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var comercio = await _context.Comercio.FindAsync(id);
            _context.Comercio.Remove(comercio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComercioExists(string id)
        {
            return _context.Comercio.Any(e => e.ComId == id);
        }
    }
}
