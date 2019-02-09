using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evaluacion_Final2.Data;
using Evaluacion_Final2.Models;

namespace Evaluacion_Final2.Controllers
{
    public class UbicacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UbicacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ubicacion
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ubicacion.Include(u => u.Disco).Include(u => u.Informacion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ubicacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacion = await _context.Ubicacion
                .Include(u => u.Disco)
                .Include(u => u.Informacion)
                .FirstOrDefaultAsync(m => m.idUbicacion == id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            return View(ubicacion);
        }

        // GET: Ubicacion/Create
        public IActionResult Create()
        {
            ViewData["idDisco"] = new SelectList(_context.Disco, "idDisco", "Nombre");
            ViewData["idInformacion"] = new SelectList(_context.Informacion, "idInformacion", "Nombre");
            return View();
        }

        // POST: Ubicacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idUbicacion,Detalle,idDisco,idInformacion")] Ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ubicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idDisco"] = new SelectList(_context.Disco, "idDisco", "idDisco", ubicacion.idDisco);
            ViewData["idInformacion"] = new SelectList(_context.Informacion, "idInformacion", "idInformacion", ubicacion.idInformacion);
            return View(ubicacion);
        }

        // GET: Ubicacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacion = await _context.Ubicacion.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }
            ViewData["idDisco"] = new SelectList(_context.Disco, "idDisco", "Nombre", ubicacion.idDisco);
            ViewData["idInformacion"] = new SelectList(_context.Informacion, "idInformacion", "Nombre", ubicacion.idInformacion);
            return View(ubicacion);
        }

        // POST: Ubicacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idUbicacion,Detalle,idDisco,idInformacion")] Ubicacion ubicacion)
        {
            if (id != ubicacion.idUbicacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ubicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UbicacionExists(ubicacion.idUbicacion))
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
            ViewData["idDisco"] = new SelectList(_context.Disco, "idDisco", "idDisco", ubicacion.idDisco);
            ViewData["idInformacion"] = new SelectList(_context.Informacion, "idInformacion", "idInformacion", ubicacion.idInformacion);
            return View(ubicacion);
        }

        // GET: Ubicacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacion = await _context.Ubicacion
                .Include(u => u.Disco)
                .Include(u => u.Informacion)
                .FirstOrDefaultAsync(m => m.idUbicacion == id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            return View(ubicacion);
        }

        // POST: Ubicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ubicacion = await _context.Ubicacion.FindAsync(id);
            _context.Ubicacion.Remove(ubicacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UbicacionExists(int id)
        {
            return _context.Ubicacion.Any(e => e.idUbicacion == id);
        }
    }
}
