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
    public class CriarDadivasController : Controller
    {
        private readonly Context _context;

        public CriarDadivasController(Context context)
        {
            _context = context;
        }

        // GET: CriarDadivas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CriarDadiva.ToListAsync());
        }

        // GET: CriarDadivas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criarDadiva = await _context.CriarDadiva
                .FirstOrDefaultAsync(m => m.IdCriarDadiva == id);
            if (criarDadiva == null)
            {
                return NotFound();
            }

            return View(criarDadiva);
        }

        // GET: CriarDadivas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CriarDadivas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCriarDadiva,Nome,Telefone,Email,Dadiva")] CriarDadiva criarDadiva)
        {
            
                _context.Add(criarDadiva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          
        }

        // GET: CriarDadivas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criarDadiva = await _context.CriarDadiva.FindAsync(id);
            if (criarDadiva == null)
            {
                return NotFound();
            }
            return View(criarDadiva);
        }

        // POST: CriarDadivas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCriarDadiva,Nome,Telefone,Email,Dadiva")] CriarDadiva criarDadiva)
        {
            if (id != criarDadiva.IdCriarDadiva)
            {
                return NotFound();
            }

          
                    _context.Update(criarDadiva);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
           
        }

        // GET: CriarDadivas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criarDadiva = await _context.CriarDadiva
                .FirstOrDefaultAsync(m => m.IdCriarDadiva == id);
            if (criarDadiva == null)
            {
                return NotFound();
            }

            return View(criarDadiva);
        }

        // POST: CriarDadivas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var criarDadiva = await _context.CriarDadiva.FindAsync(id);
            _context.CriarDadiva.Remove(criarDadiva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CriarDadivaExists(int id)
        {
            return _context.CriarDadiva.Any(e => e.IdCriarDadiva == id);
        }
    }
}
