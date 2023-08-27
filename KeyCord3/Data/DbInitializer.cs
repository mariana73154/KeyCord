using KeyCord3.Models;

namespace KeyCord3.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            LoadCategoria();
            LoadProdutora();
            LoadPlataforma();

            _context.SaveChanges();
        }

        public void LoadCategoria()
        {
            if (_context.Categoria.Any())
            {
                return;
            }

            var categories = new Categorium[]
            {
                new Categorium{NomeCat="Action", DescCat="Games where the player is in control of and at the center of the action"},
                new Categorium{NomeCat="Adventure", DescCat="Players usually interact with their environment and other characters to solve puzzles with clues to progress the story or gameplay"},
                new Categorium{NomeCat="Simulation", DescCat="Designed to emulate real or fictional reality, to simulate a real situation or event."},
                new Categorium{NomeCat="Strategy", DescCat="Is based on traditional strategy board games"},
            };

            foreach(var c in categories)
            {
                _context.Categoria.Add(c);
            };
           
        }

        public void LoadProdutora()
        {
            if (_context.Produtoras.Any())
            {
                return;
            }

            var produtoras = new Produtora[]
            {
                new Produtora{NomeProd="EA", DescProd="Since 1982"},
                new Produtora{NomeProd="Epic Games", DescProd="Since 1991"},
                new Produtora{NomeProd="Take-Two Interactive", DescProd="Since 1993"},

            };

            foreach (var p in produtoras)
            {
                _context.Produtoras.Add(p);
            };
        }

        public void LoadPlataforma()
        {
            if (_context.Plataformas.Any())
            {
                return;
            }

            var plataformas = new Plataforma[]
            {
                new Plataforma {NomePlat="Pc", DescPlat="Personal Computer"},
                new Plataforma {NomePlat="PS5", DescPlat="Play Station 5"},
                new Plataforma {NomePlat="Xbox", DescPlat="Xbox"}

            };

            foreach (var p in plataformas)
            {
                _context.Plataformas.Add(p);
            };
        }


        //public void LoadJogo()
        //{
        //    if (_context.Jogos.Any())
        //    {
        //        return;
        //    }

        //    var jogos = new Jogo[]
        //    {
        //        new Jogo {NomeJogo="FIFA 23", PrecoJogo=70, Desconto=0, DescJogo="Sente na pele o entusiasmo do maior torneio do futebol com o EA SPORTS™ FIFA 23 e a atualização do FIFA World Cup™ masculino, disponível no dia 9 de novembro sem qualquer custo adicional!",
        //                    AnoPublic=2022, IdCat=_context.Categoria.Last().IdCat}
        //    };

        //    foreach (var j in jogos)
        //    {
        //        _context.Jogos.Add(j);
        //    };
        //}
    }
}
