using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KeyCord3.Data;
using KeyCord3.Models;
using Microsoft.AspNetCore.Authorization;

namespace KeyCord3.Controllers
{
    [Authorize(Roles = "Funcionario,Admin")]
    public class ProdutorasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutorasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produtoras
        public async Task<IActionResult> Index()
        {
              return View(await _context.Produtoras.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("NomeProd,DescProd")] Produtora produtora)
        {
            if (ModelState.IsValid)
            {
                if (_context.Produtoras.SingleOrDefault(x => x.NomeProd == produtora.NomeProd) == null)
                {
                    _context.Produtoras.Add(produtora);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ListProdutoras", "Manutencao");
                }
                else
                {
                    ModelState.AddModelError("produtora", "Esta produtora já existe");
                    return View(produtora);
                }

            }
            else
            {
                return View(produtora);
            }
        }

        // GET: Produtoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtoras == null)
            {
                return NotFound();
            }

            var produtora = await _context.Produtoras.FindAsync(id);
            if (produtora == null)
            {
                return NotFound();
            }
            return View(produtora);
        }

        // POST: Produtoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProd,NomeProd,DescProd")] Produtora produtora)
        {
            if (id != produtora.IdProd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoraExists(produtora.IdProd))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ListProdutoras", "Manutencao");
            }
            return View(produtora);
        }

        private bool ProdutoraExists(int id)
        {
          return _context.Produtoras.Any(e => e.IdProd == id);
        }
    }
}
