using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Areas.Administracija.ViewModels;
using WebSite.db;
using WebSite.db.EntityModels;

namespace WebSite.Areas.Administracija.Controllers
{
    [Authorize]
    [Area("Administracija")]
    public class KategorijeLinkovaController : Controller
    {
        private ApplicationDbContext _db;
        public KategorijeLinkovaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            KategorijeLinkovaIndexViewModel kategorije = new KategorijeLinkovaIndexViewModel();
            kategorije.Rows = _db.KategorijeLinkova.Select(x => new KategorijeLinkovaIndexViewModel.Row
            {
                Id=x.Id,
                Naziv=x.NazivKategorije,
                Opis=x.Opis
            }).ToList();
            return View(kategorije);
        }
        public IActionResult Dodaj()
        {
            KategorijeLinkovaDodajViewModel dodaj = new KategorijeLinkovaDodajViewModel();
            

            return View(dodaj);
        }
        public IActionResult Snimi(KategorijeLinkovaDodajViewModel vm)
        {
            db.EntityModels.KategorijeLinkova kategorija = new db.EntityModels.KategorijeLinkova();
            kategorija.NazivKategorije = vm.NazivKategorje;
            kategorija.Opis = vm.Opis;
            _db.KategorijeLinkova.Add(kategorija);
            _db.SaveChanges();
            return Redirect("/Administracija/KategorijeLinkova/Index/");
        }
        public IActionResult Obrisi(int Id)
        {
            db.EntityModels.KategorijeLinkova kat = _db.KategorijeLinkova.Find(Id);
            db.EntityModels.Linkovi link = _db.Linkovi.Where(x => x.KategorijeLinkovaId == Id).FirstOrDefault();
            _db.Linkovi.Remove(link);
            _db.KategorijeLinkova.Remove(kat);
            _db.SaveChanges();
            return Redirect("/Administracija/KategorijeLinkova/Index/");
        }
        public IActionResult Uredi(int Id)
        {
            KategorijeLinkovaUrediViewModel uredi = new KategorijeLinkovaUrediViewModel();
            db.EntityModels.KategorijeLinkova kategorija = _db.KategorijeLinkova.Where(x => x.Id == Id).FirstOrDefault();
            uredi.Naziv = kategorija.NazivKategorije;
            return View(uredi);
        }
        public IActionResult SnimiUredi(KategorijeLinkovaUrediViewModel vm)
        {
            db.EntityModels.KategorijeLinkova kategorija = _db.KategorijeLinkova.Where(x => x.Id == vm.Id).FirstOrDefault();
            kategorija.Opis = vm.Opis;
            _db.SaveChanges();
            return Redirect("/Administracija/KategorijeLinkova/Index/");
        }
    }
}