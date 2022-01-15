using Liga.Data;
using Liga.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Liga.Controllers
{
    public class KlubController : Controller
    {
        private readonly LIGAContext _context;

        public KlubController(LIGAContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kluboviList = _context.Klubs.Select(x => new Klub
            {
                IdKlub = x.IdKlub,
                Naziv = x.Naziv,
                IdMjesto = x.IdMjesto,
                Bodovi = x.Bodovi,
                PostignutiGolovi = x.PostignutiGolovi,
                PrimljeniGolovi = x.PrimljeniGolovi,
                Mjesto1 = x.IdMjestoNavigation.NazivMjesta,

            }).ToList();
            return View("Index", kluboviList);
        }
    }
}
