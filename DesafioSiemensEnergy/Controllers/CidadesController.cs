using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioSiemensEnergy.Models;
using System.Drawing.Printing;
using Microsoft.Build.Framework;
using System.Runtime.CompilerServices;

namespace DesafioSiemensEnergy.Controllers
{
    public class CidadesController : Controller
    {
        private readonly ContextoCidades _context;

        public CidadesController(ContextoCidades context)
        {
            _context = context;
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
            return _context.Cidade != null ?
                        View(await _context.Cidade.ToListAsync()) :
                        Problem("Entity set 'ContextoCidades.Cidade'  is null.");
        }

        // GET: Cidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cidade == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cidade == null)
            {
                return NotFound();
            }
            
            return View(cidade);
        }

        public async Task<IActionResult> BuscaCidade(string? nome)
        {
            if (nome == null || _context.Cidade == null)
            {
                return NotFound();
            }
            
            var cidade = await _context.Cidade.
                FirstOrDefaultAsync(m => m.Nome.Contains(nome));
       
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        public async Task<List<Cidade>> BuscaEstado(string? nome)
        {            
            var cidade = _context.Cidade.Where(c => c.Estado.Contains(nome)).ToList();       

            return cidade;
        }

        private IActionResult JSON(Cidade cidade)
        {
            throw new NotImplementedException();
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Estado")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cidade == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Estado")] Cidade cidade)
        {
            if (id != cidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeExists(cidade.Id))
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
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cidade == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cidade == null)
            {
                return Problem("Entity set 'ContextoCidades.Cidade'  is null.");
            }
            var cidade = await _context.Cidade.FindAsync(id);
            if (cidade != null)
            {
                _context.Cidade.Remove(cidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeExists(int id)
        {
          return (_context.Cidade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
