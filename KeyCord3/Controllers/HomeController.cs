using KeyCord3.Data;
using KeyCord3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KeyCord3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewModelHome viewModelHome = new ViewModelHome { Categorias = _context.Categoria.ToList(), Plataformas=_context.Plataformas.ToList(), Produtoras=_context.Produtoras.ToList(), Jogos=_context.Jogos.ToList()};
            return View(viewModelHome);
        }

        [Authorize(Roles = "Cliente")]
        public IActionResult Fav()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Deals()
        {
            ViewModelHome viewModelHome = new ViewModelHome { Jogos = _context.Jogos.Where(x => x.Desconto > 0).OrderByDescending(x => x.Desconto).ToList() };
            return View(viewModelHome);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class ViewModelHome
    {
        public List<Categorium> Categorias { get; set; }
        public List<Plataforma> Plataformas { get; set; }
        public List<Produtora> Produtoras { get; set; }
        public List<Jogo> Jogos { get; set; }
    }
}