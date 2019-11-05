using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSite.Areas.Administracija.ViewModels;
using WebSite.db;

namespace WebSite.Areas.Administracija.Controllers
{
    [Authorize]
    [Area("Administracija")]
    public class LinkoviController : Controller
    {
        private ApplicationDbContext  _db;
        public LinkoviController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            LinkoviIndexViewModel linkovi = new LinkoviIndexViewModel();
            linkovi.Rows = _db.Linkovi.Select(x => new LinkoviIndexViewModel.Row
            {
                Id=x.Id,
                Naziv=x.NazivLinka,
                URL=x.URL,
                NazivKategorije=x.KategorijeLinkova.NazivKategorije
            }).ToList();
            
            return View(linkovi);
        }
        public IActionResult Dodaj()
        {
            LinkoviDodajViewModel dodaj = new LinkoviDodajViewModel();
            dodaj.Kategorija = _db.KategorijeLinkova.Select(x => new SelectListItem
            {
                Text=x.NazivKategorije,
                Value=x.Id.ToString()
            }).ToList();
            return View(dodaj);
        }
        public IActionResult Snimi(LinkoviDodajViewModel vm)
        {
            db.EntityModels.Linkovi link = new db.EntityModels.Linkovi();
            link.KategorijeLinkovaId = vm.KategorijeLinkovaId;
            link.NazivLinka = vm.Naziv;
            link.URL = vm.URL;
            _db.Linkovi.Add(link);
            _db.SaveChanges();
            return Redirect("/Administracija/Linkovi/Index/"+link.KategorijeLinkovaId);
        }
        
        public IActionResult Obrisi(int Id)
        {
            db.EntityModels.Linkovi link = _db.Linkovi.Where(x => x.Id == Id).FirstOrDefault();
            _db.Linkovi.Remove(link);
            _db.SaveChanges();
            return Redirect("/Administracija/Linkovi/Index/"+link.KategorijeLinkovaId);
        }
        public IActionResult Uredi(int Id)
        {
            LinkoviUrediViewModel uredi = new LinkoviUrediViewModel();
            db.EntityModels.Linkovi link = _db.Linkovi.Where(x => x.Id == Id).FirstOrDefault();
            uredi.Id = link.Id;
            uredi.Naziv = link.NazivLinka;
            return View(uredi);
        }
        public IActionResult SnimiUredi(LinkoviUrediViewModel vm)
        {
            db.EntityModels.Linkovi link = _db.Linkovi.Where(x => x.Id == vm.Id).FirstOrDefault();
            link.URL = vm.URL;
            _db.SaveChanges();
            return Redirect("/Administracija/Linkovi/Index/"+link.KategorijeLinkovaId);
        }
    }
}