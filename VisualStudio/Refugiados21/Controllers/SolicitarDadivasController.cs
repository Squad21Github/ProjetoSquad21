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
    public class SolicitarDadivasController : Controller
    {
        private readonly Context _context;

        public SolicitarDadivasController(Context context)
        {
            _context = context;
        }

        // GET: SolicitarDadivas
        public async Task<IActionResult> Index()
        {
            return View(await _context.SolicitarDadiva.ToListAsync());
        }

        // GET: SolicitarDadivas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitarDadiva = await _context.SolicitarDadiva
                .FirstOrDefaultAsync(m => m.IdDadiva == id);
            if (solicitarDadiva == null)
            {
                return NotFound();
            }

            return View(solicitarDadiva);
        }

        // GET: SolicitarDadivas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SolicitarDadivas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDadiva,Ong,Endereço,Telefone,Email,Dádiva")] SolicitarDadiva solicitarDadiva)
        {
           
                _context.Add(solicitarDadiva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: SolicitarDadivas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitarDadiva = await _context.SolicitarDadiva.FindAsync(id);
            if (solicitarDadiva == null)
            {
                return NotFound();
            }
            return View(solicitarDadiva);
        }

        // POST: SolicitarDadivas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDadiva,Ong,Endereço,Telefone,Email,Dádiva")] SolicitarDadiva solicitarDadiva)
        {
            if (id != solicitarDadiva.IdDadiva)
            {
                return NotFound();
            }

         
                    _context.Update(solicitarDadiva);
                    await _context.SaveChangesAsync();
               
                
                return RedirectToAction(nameof(Index));
            
        }

        // GET: SolicitarDadivas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitarDadiva = await _context.SolicitarDadiva
                .FirstOrDefaultAsync(m => m.IdDadiva == id);
            if (solicitarDadiva == null)
            {
                return NotFound();
            }

            return View(solicitarDadiva);
        }

        // POST: SolicitarDadivas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitarDadiva = await _context.SolicitarDadiva.FindAsync(id);
            _context.SolicitarDadiva.Remove(solicitarDadiva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitarDadivaExists(int id)
        {
            return _context.SolicitarDadiva.Any(e => e.IdDadiva == id);
        }
    }
}
