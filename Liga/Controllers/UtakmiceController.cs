using Liga.Data;
using Liga.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Liga.Controllers
{
    public class UtakmiceController : Controller
    {
        private readonly LIGAContext _context;

        public UtakmiceController(LIGAContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var rezultatiList = _context.Rezultats.Select(x => new Rezultat
            {
                IdUtakmica = x.IdUtakmica,
                IdKlub1 = x.IdKlub1,
                IdKlub2 = x.IdKlub2,
                Rezultat1 = x.Rezultat1,
                Klub1 = x.IdKlub1Navigation.Naziv,
                Klub2 = x.IdKlub2Navigation.Naziv,
                Kolo = x.IdUtakmicaNavigation.IdKoloNavigation.RedniBroj.ToString(),
                Datum = x.IdUtakmicaNavigation.Vrijeme.Value,
                Mjesto = x.IdUtakmicaNavigation.IdMjestoNavigation.NazivMjesta
            }).ToList();
            return View(rezultatiList);
        }
    }
}
