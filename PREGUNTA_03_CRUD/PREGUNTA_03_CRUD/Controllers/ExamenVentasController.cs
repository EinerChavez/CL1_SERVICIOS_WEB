using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PREGUNTA_03_CRUD.Data;
using PREGUNTA_03_CRUD.Models;

namespace PREGUNTA_03_CRUD.Controllers
{
    public class ExamenVentasController : Controller
    {
        private readonly PREGUNTA_03_CRUDContext _context;

        public ExamenVentasController(PREGUNTA_03_CRUDContext context)
        {
            _context = context;
        }

        // GET: ExamenVentas
        public async Task<IActionResult> Index(string search)
        {
            var ventas = from v in _context.Ventas
                         select v;

            // Filtrar por descripción si se proporciona un valor de búsqueda
            if (!string.IsNullOrEmpty(search))
            {
                ventas = ventas.Where(v => v.Descripcion.Contains(search));
            }

            ViewData["Search"] = search;
            return View(await ventas.ToListAsync());
        }

        // GET: ExamenVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: ExamenVentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExamenVentas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Cantidad,PrecioUnitario")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }

        // GET: ExamenVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            return View(venta);
        }

        // POST: ExamenVentas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Cantidad,PrecioUnitario")] Venta venta)
        {
            if (id != venta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.Id))
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
            return View(venta);
        }

        // GET: ExamenVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: ExamenVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }
    }
}
