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
    public class AtenderDadivasController : Controller
    {
        private readonly Context _context;

        public AtenderDadivasController(Context context)
        {
            _context = context;
        }

        // GET: AtenderDadivas
        public async Task<IActionResult> Index()
        {
            var context = _context.AtenderDadiva.Include(a => a.SolicitarDadiva);
            return View(await context.ToListAsync());
        }

        // GET: AtenderDadivas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atenderDadiva = await _context.AtenderDadiva
                .Include(a => a.SolicitarDadiva)
                .FirstOrDefaultAsync(m => m.IdAtender == id);
            if (atenderDadiva == null)
            {
                return NotFound();
            }

            return View(atenderDadiva);
        }

        // GET: AtenderDadivas/Create
        public IActionResult Create()
        {
            ViewData["IdDadiva"] = new SelectList(_context.SolicitarDadiva, "IdDadiva","Dádiva");
            return View();
        }

        // POST: AtenderDadivas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAtender,Seu_Nome,Telefone,Email,CPF,IdDadiva")] AtenderDadiva atenderDadiva)
        {
           
                _context.Add(atenderDadiva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["IdDadiva"] = new SelectList(_context.SolicitarDadiva, "IdDadiva", "Dádiva", atenderDadiva.IdDadiva);
            
        }

        // GET: AtenderDadivas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atenderDadiva = await _context.AtenderDadiva.FindAsync(id);
            if (atenderDadiva == null)
            {
                return NotFound();
            }
            ViewData["IdDadiva"] = new SelectList(_context.SolicitarDadiva, "IdDadiva", "Dádiva", atenderDadiva.IdDadiva);
            return View(atenderDadiva);
        }

        // POST: AtenderDadivas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAtender,Seu_Nome,Telefone,Email,CPF,IdDadiva")] AtenderDadiva atenderDadiva)
        {
            if (id != atenderDadiva.IdAtender)
            {
                return NotFound();
            }

           
                    _context.Update(atenderDadiva);
                    await _context.SaveChangesAsync();
                
            
            ViewData["IdDadiva"] = new SelectList(_context.SolicitarDadiva, "IdDadiva", "Dádiva", atenderDadiva.IdDadiva);
            return RedirectToAction(nameof(Index));
        }

        // GET: AtenderDadivas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atenderDadiva = await _context.AtenderDadiva
                .Include(a => a.SolicitarDadiva)
                .FirstOrDefaultAsync(m => m.IdAtender == id);
            if (atenderDadiva == null)
            {
                return NotFound();
            }

            return View(atenderDadiva);
        }

        // POST: AtenderDadivas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atenderDadiva = await _context.AtenderDadiva.FindAsync(id);
            _context.AtenderDadiva.Remove(atenderDadiva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtenderDadivaExists(int id)
        {
            return _context.AtenderDadiva.Any(e => e.IdAtender == id);
        }
    }
}
