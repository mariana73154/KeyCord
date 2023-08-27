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
    [Authorize(Roles ="Funcionario,Admin")]
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("NomeCat,DescCat")] Categorium categorium)
        {
            if(ModelState.IsValid)
            {
                if(_context.Categoria.SingleOrDefault(x=>x.NomeCat==categorium.NomeCat)==null)
                {
                    _context.Categoria.Add(categorium);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ListCategorias","Manutencao");
                }
                else
                {
                    ModelState.AddModelError("categoria", "Esta categoria já existe");
                    return View(categorium);
                }
               
            }
            else
            {
                return View(categorium);
            }
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categoria == null)
            {
                return NotFound();
            }

            var categorium = await _context.Categoria.FindAsync(id);
            if (categorium == null)
            {
                return NotFound();
            }
            return View(categorium);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCat,NomeCat,DescCat")] Categorium categorium)
        {
            if (id != categorium.IdCat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriumExists(categorium.IdCat))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ListCategorias","Manutencao");
            }
            return View(categorium);
        }

        private bool CategoriumExists(int id)
        {
          return _context.Categoria.Any(e => e.IdCat == id);
        }
    }
}
