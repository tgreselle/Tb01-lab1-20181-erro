using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppTb01Lab1_Greselle.Models;

namespace WebAppTb01Lab1_Greselle.Controllers
{
    public class AutomovelController : Controller
    {
        private readonly AutomovelContext _context;

        public AutomovelController(AutomovelContext context)
        {
            _context = context;
        }

        // GET: Automovel
        [Route("inicio")]
        [Route("automovel/admin/inicio")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Automovel.ToListAsync());
        }

        // GET: Automovel/Details/5
        [Route("automovel/admin/visualizar/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automovel = await _context.Automovel
                .SingleOrDefaultAsync(m => m.AutomovelID == id);
            if (automovel == null)
            {
                return NotFound();
            }

            return View(automovel);
        }

        // GET: Automovel/Create
        [Route("automovel/admin/cadastrar")]
        public IActionResult Create()


        {
            return View();
        }

        // POST: Automovel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutomovelID,Tipo,Descricao,Marca,Disponivel,Datacadastro")] Automovel automovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(automovel);
        }

        // GET: Automovel/Edit/5
        [Route("automovel/admin/editar/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automovel = await _context.Automovel.SingleOrDefaultAsync(m => m.AutomovelID == id);
            if (automovel == null)
            {
                return NotFound();
            }
            return View(automovel);
        }

        // POST: Automovel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutomovelID,Tipo,Descricao,Marca,Disponivel,Datacadastro")] Automovel automovel)
        {
            if (id != automovel.AutomovelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomovelExists(automovel.AutomovelID))
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
            return View(automovel);
        }

        // GET: Automovel/Delete/5
        [Route("automovel/admin/deletar/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automovel = await _context.Automovel
                .SingleOrDefaultAsync(m => m.AutomovelID == id);
            if (automovel == null)
            {
                return NotFound();
            }

            return View(automovel);
        }

        // POST: Automovel/Delete/5
        [Route("automovel/admin/deletar/{id:int}")]
        [Route("Deletar")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var automovel = await _context.Automovel.SingleOrDefaultAsync(m => m.AutomovelID == id);
            _context.Automovel.Remove(automovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomovelExists(int id)
        {
            return _context.Automovel.Any(e => e.AutomovelID == id);
        }
    }
}
