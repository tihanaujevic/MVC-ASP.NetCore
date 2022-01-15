using Liga.Data;
using Liga.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Liga.Controllers
{
    public class RezultatController : Controller
    {
        private readonly LIGAContext _context;

        public RezultatController(LIGAContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searching)
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
            if (!String.IsNullOrEmpty(searching))
            {
                searching = searching.ToLower();
                rezultatiList = rezultatiList.Where(s => s.Klub1.ToLower().Contains(searching) ||
                  s.Klub2.ToLower().Contains(searching)).ToList();
            }
            return (View(rezultatiList));
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
            return View("Details", rezultatiList);
        }
    }
}
