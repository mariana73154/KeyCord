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
    public class PlataformasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlataformasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("NomePlat,DescPlat")] Plataforma plataforma)
        {
            if (ModelState.IsValid)
            {
                if (_context.Plataformas.SingleOrDefault(x => x.NomePlat == plataforma.NomePlat) == null)
                {
                    _context.Plataformas.Add(plataforma);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ListPlataformas", "Manutencao");
                }
                else
                {
                    ModelState.AddModelError("plataforma", "Esta plataforma já existe");
                    return View(plataforma);
                }

            }
            else
            {
                return View(plataforma);
            }
        }

        // GET: Plataformas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Plataformas.ToListAsync());
        }

 

        // GET: Plataformas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plataformas == null)
            {
                return NotFound();
            }

            var plataforma = await _context.Plataformas.FindAsync(id);
            if (plataforma == null)
            {
                return NotFound();
            }
            return View(plataforma);
        }

        // POST: Plataformas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlat,NomePlat,DescPlat")] Plataforma plataforma)
        {
            if (id != plataforma.IdPlat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plataforma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlataformaExists(plataforma.IdPlat))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ListPlataformas", "Manutencao");
            }
            return View(plataforma);
        }

        
        private bool PlataformaExists(int id)
        {
          return _context.Plataformas.Any(e => e.IdPlat == id);
        }
    }
}
