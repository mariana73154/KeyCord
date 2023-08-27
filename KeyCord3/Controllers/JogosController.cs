using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KeyCord3.Data;
using KeyCord3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace KeyCord3.Controllers
{
    public class JogosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHostEnvironment _he;

        public JogosController(ApplicationDbContext context, UserManager<IdentityUser> user, IHostEnvironment he)
        {
            _context = context;
            _userManager = user;
            _he = he;
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jogos.Include(j => j.IdCatNavigation).Include(j => j.IdFuncNavigation).Include(j => j.IdPlatNavigation).Include(j => j.IdProdNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Cliente")]

        public IActionResult Comprar(int id)
        { 
            Jogo jogo = _context.Jogos.Find(id);
            Compra compra = new Compra();
            compra.DataCompra = DateTime.Now;
            compra.PrecoCompra = jogo.PrecoJogo - (jogo.Desconto*jogo.PrecoJogo);
            compra.IdCli = _context.Utilizadors.FirstOrDefault(x => x.UserUt == User.Identity.Name).IdUt;
            compra.IdJogo= jogo.IdJogo;
            compra.IdCliNavigation = _context.Clientes.Find(compra.IdCli);
            compra.IdJogoNavigation = _context.Jogos.Find(compra.IdJogo);

            if(_context.Compras.FirstOrDefault(x => x.IdCli==compra.IdCli)!=null && _context.Compras.FirstOrDefault(x => x.IdJogo == compra.IdJogo) != null)
            {

                TempData["Erro"] = "Já comprou este jogo!";
                 
                
            }
            else
            {
                _context.Add(compra);
                _context.SaveChanges();

            }
            return RedirectToAction("Details", "Jogo");
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            Jogo j= _context.Jogos.Find(id);
            return View(j);
        
        }


        // GET: Jogos/Create
        [Authorize(Roles = "Funcionario")]
        public IActionResult Create()
        {
            ViewData["NomeCat"] = new SelectList(_context.Categoria, "IdCat", "NomeCat");
            ViewData["NomeProd"] = new SelectList(_context.Produtoras, "IdProd", "NomeProd");
            ViewData["NomePlat"] = new SelectList(_context.Plataformas, "IdPlat", "NomePlat");
            return View();
        }

        [Authorize(Roles = "Funcionario")]
        // POST: Jogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeJogo,PrecoJogo,Desconto,DescJogo,AnoPublic,IdCat,IdProd,IdPlat")] Jogo jogo, IFormFile FotoJogo)
        {

            try
            {


                var destination = Path.Combine(_he.ContentRootPath, "wwwroot/Images", Path.GetFileName(FotoJogo.FileName));
                FileStream fs = new FileStream(destination, FileMode.Create);

                await FotoJogo.CopyToAsync(fs);
                fs.Close();

                jogo.FotoJogo = FotoJogo.FileName;
                jogo.IdCatNavigation = _context.Categoria.Find(jogo.IdCat);
                jogo.IdProdNavigation = _context.Produtoras.Find(jogo.IdProd);
                jogo.IdPlatNavigation = _context.Plataformas.Find(jogo.IdPlat);
                var current_user = await _userManager.GetUserAsync(HttpContext.User);
                Utilizador ut = _context.Utilizadors.First(x => x.IdAspNet == current_user.Id);
                jogo.IdFunc = ut.IdUt;
                jogo.DataEdicao = DateTime.Now;
                _context.Jogos.Add(jogo);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListJogos","Manutencao");
            }
            catch
            {
                ViewData["NomeCat"] = new SelectList(_context.Categoria, "IdCat", "NomeCat");
                ViewData["NomeProd"] = new SelectList(_context.Produtoras, "IdProd", "NomeProd");
                ViewData["NomePlat"] = new SelectList(_context.Plataformas, "IdPlat", "NomePlat");
                return View(jogo);
            }
        }

        // GET: Jogos/Edit/5
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jogos == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
            {
                return NotFound();
            }
            ViewData["IdCat"] = new SelectList(_context.Categoria, "IdCat", "NomeCat", jogo.IdCat);
            ViewData["IdPlat"] = new SelectList(_context.Plataformas, "IdPlat", "NomePlat", jogo.IdPlat);
            ViewData["IdProd"] = new SelectList(_context.Produtoras, "IdProd", "NomeProd", jogo.IdProd);
            return View(jogo);
        }

        [Authorize(Roles = "Funcionario")]
        // POST: Jogos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJogo,NomeJogo,PrecoJogo,Desconto,DescJogo,AnoPublic,FotoJogo,IdCat,IdProd,IdPlat")] Jogo jogo)
        {
            if (id != jogo.IdJogo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    jogo.DataEdicao = DateTime.Now;
                    _context.Update(jogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoExists(jogo.IdJogo))
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
            ViewData["IdCat"] = new SelectList(_context.Categoria, "IdCat", "NomeCat", jogo.IdCat);
            ViewData["IdPlat"] = new SelectList(_context.Plataformas, "IdPlat", "NomePlat", jogo.IdPlat);
            ViewData["IdProd"] = new SelectList(_context.Produtoras, "IdProd", "NomeProd", jogo.IdProd);
            return View(jogo);
        }

        private bool JogoExists(int id)
        {
          return _context.Jogos.Any(e => e.IdJogo == id);
        }
    }
}
