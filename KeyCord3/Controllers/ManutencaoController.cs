using KeyCord3.Data;
using KeyCord3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeyCord3.Controllers
{
    public class ManutencaoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ManutencaoController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        [Authorize(Roles = "Funcionario,Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Funcionario,Admin")]
        public async Task<IActionResult> ListJogos()
        {
            var applicationDbContext = _context.Jogos.Include(j => j.IdCatNavigation).Include(j => j.IdFuncNavigation).Include(j => j.IdPlatNavigation).Include(j => j.IdProdNavigation);
            var current_User = await _userManager.GetUserAsync(HttpContext.User);

            Utilizador ut = _context.Utilizadors.First(x => x.IdAspNet == current_User.Id);
            ViewData["userId"] = ut.IdUt;

            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Funcionario,Admin")]

        public async Task<IActionResult> ListCategorias()
        {
            var applicationDbContext = _context.Categoria;

            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Funcionario,Admin")]

        public async Task<IActionResult> ListProdutoras()
        {
            var applicationDbContext = _context.Produtoras;

            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Funcionario,Admin")]

        public async Task<IActionResult> ListPlataformas()
        {
            var applicationDbContext = _context.Plataformas;

            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> ListFuncionarios()
        {
            var applicationDbContext = _context.Funcionarios;

            return View(await applicationDbContext.ToListAsync());
        }

    }
}
