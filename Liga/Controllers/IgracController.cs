using Liga.Data;
using Liga.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Liga.Controllers
{
    public class IgracController : Controller
    {
        private readonly LIGAContext _context;

        public IgracController(LIGAContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var igraci = _context.Igracs.Select(x => new Igrac
            {
                IdIgrac = x.IdIgrac,
                Ime = x.Ime,
                Prezime = x.Prezime,
                BrojDresa = x.BrojDresa,
                IdKlub = x.IdKlub,
                Klub1 = x.IdKlubNavigation.Naziv,
                Pozicija1 = x.IdPozicijaNavigation.NazivPozicije,
                Karton = x.Kartonirani.BrojCrvenihKartona,
                Asistencija = x.Asistenti.BrojAsistencija,
                Golovi = x.Strijelci.BrojGolova
            }).ToList();

            return View(igraci);
        }
        public IActionResult Asistencije()
        {

            var igraci = _context.Igracs.Select(x => new Igrac
            {
                IdIgrac = x.IdIgrac,
                Ime = x.Ime,
                Prezime = x.Prezime,
                BrojDresa = x.BrojDresa,
                IdKlub = x.IdKlub,
                Klub1 = x.IdKlubNavigation.Naziv,
                Pozicija1 = x.IdPozicijaNavigation.NazivPozicije,
                Karton = x.Kartonirani.BrojCrvenihKartona,
                Asistencija = x.Asistenti.BrojAsistencija,
                Golovi = x.Strijelci.BrojGolova
            }).ToList();

            return View(igraci);
        }

        public IActionResult Kartoni()
        {

            var igraci = _context.Igracs.Select(x => new Igrac
            {
                IdIgrac = x.IdIgrac,
                Ime = x.Ime,
                Prezime = x.Prezime,
                BrojDresa = x.BrojDresa,
                IdKlub = x.IdKlub,
                Klub1 = x.IdKlubNavigation.Naziv,
                Pozicija1 = x.IdPozicijaNavigation.NazivPozicije,
                Karton = x.Kartonirani.BrojCrvenihKartona,
                Asistencija = x.Asistenti.BrojAsistencija,
                Golovi = x.Strijelci.BrojGolova
            }).ToList();

            return View(igraci);
        }
    }
}
