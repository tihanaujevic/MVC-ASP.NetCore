using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liga.Data;
using Liga.Models;
using Microsoft.AspNetCore.Mvc;

namespace Liga.Controllers
{
    public class RezultatController : Controller
    {
        private readonly LIGAContext _context;

        public RezultatController(LIGAContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var rezultatiList = _context.Rezultats.Select(x => new Rezultat
            {
                IdUtakmica=x.IdUtakmica,
                IdKlub1=x.IdKlub1,
                IdKlub2=x.IdKlub2,
                Rezultat1=x.Rezultat1,
                Klub1=x.IdKlub1Navigation.Naziv,
                Klub2=x.IdKlub2Navigation.Naziv,
                Kolo = x.IdUtakmicaNavigation.IdKoloNavigation.RedniBroj.ToString(),
                Datum = x.IdUtakmicaNavigation.Vrijeme.Value,
                Mjesto = x.IdUtakmicaNavigation.IdMjestoNavigation.NazivMjesta
            }).ToList();
            return(View(rezultatiList));
        }

        public IActionResult Details()
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
            }).FirstOrDefault();
            return View(rezultatiList); 
        }
    }
}
