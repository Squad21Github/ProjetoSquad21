#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Refugiados1.Models;

namespace Refugiados1.Controllers
{
    public class EscolherDadivasController : Controller
    {
        private readonly Context _context;

        public EscolherDadivasController(Context context)
        {
            _context = context;
        }

        // GET: EscolherDadivas
        public async Task<IActionResult> Index()
        {
            var context = _context.EscolherDadiva.Include(e => e.CriarDadiva);
            return View(await context.ToListAsync());
        }

        // GET: EscolherDadivas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolherDadiva = await _context.EscolherDadiva
                .Include(e => e.CriarDadiva)
                .FirstOrDefaultAsync(m => m.IdEscolherDadiva == id);
            if (escolherDadiva == null)
            {
                return NotFound();
            }

            return View(escolherDadiva);
        }

        // GET: EscolherDadivas/Create
        public IActionResult Create()
        {
            ViewData["IdCriarDadiva"] = new SelectList(_context.CriarDadiva, "IdCriarDadiva", "Dadiva");
            return View();
        }

        // POST: EscolherDadivas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEscolherDadiva,Ong,Endereço,Telefone,Email,IdCriarDadiva")] EscolherDadiva escolherDadiva)
        {
            
                _context.Add(escolherDadiva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["IdCriarDadiva"] = new SelectList(_context.CriarDadiva, "IdCriarDadiva", "Dadiva", escolherDadiva.IdCriarDadiva);
            return View(escolherDadiva);
        }

        // GET: EscolherDadivas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolherDadiva = await _context.EscolherDadiva.FindAsync(id);
            if (escolherDadiva == null)
            {
                return NotFound();
            }
            ViewData["IdCriarDadiva"] = new SelectList(_context.CriarDadiva, "IdCriarDadiva", "Dadiva", escolherDadiva.IdCriarDadiva);
            return View(escolherDadiva);
        }

        // POST: EscolherDadivas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEscolherDadiva,Ong,Endereço,Telefone,Email,IdCriarDadiva")] EscolherDadiva escolherDadiva)
        {
            if (id != escolherDadiva.IdEscolherDadiva)
            {
                return NotFound();
            }

                    _context.Update(escolherDadiva);
                    await _context.SaveChangesAsync();
              
                return RedirectToAction(nameof(Index));
            
            ViewData["IdCriarDadiva"] = new SelectList(_context.CriarDadiva, "IdCriarDadiva", "Dadiva", escolherDadiva.IdCriarDadiva);
           
        }

        // GET: EscolherDadivas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolherDadiva = await _context.EscolherDadiva
                .Include(e => e.CriarDadiva)
                .FirstOrDefaultAsync(m => m.IdEscolherDadiva == id);
            if (escolherDadiva == null)
            {
                return NotFound();
            }

            return View(escolherDadiva);
        }

        // POST: EscolherDadivas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escolherDadiva = await _context.EscolherDadiva.FindAsync(id);
            _context.EscolherDadiva.Remove(escolherDadiva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolherDadivaExists(int id)
        {
            return _context.EscolherDadiva.Any(e => e.IdEscolherDadiva == id);
        }
    }
}
