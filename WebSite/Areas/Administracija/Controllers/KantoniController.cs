using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSite.Areas.Administracija.ViewModels;
using WebSite.db;

namespace WebSite.Areas.Administracija.Controllers
{
    [Authorize]
    [Area("Administracija")]
    public class KantoniController : Controller
    {
        private ApplicationDbContext _db;
        public KantoniController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            KantoniIndexViewModel kantoni = new KantoniIndexViewModel();
            kantoni.Rows = _db.Kantoni.Select(x => new KantoniIndexViewModel.Row
            {
                Id=x.Id,
                Naziv=x.NazivKantona,
                Oznaka=x.OznakaKantona
            }).ToList();
            return View(kantoni);
        }
        public IActionResult Dodaj()
        {
            KantoniDodajViewModel dodaj = new KantoniDodajViewModel();

            return View(dodaj);
        }
        public IActionResult Snimi(KantoniDodajViewModel vm)
        {
            db.EntityModels.Kanton kanton = new db.EntityModels.Kanton();
            kanton.NazivKantona = vm.Naziv;
            kanton.OznakaKantona = vm.Oznaka;
            _db.Kantoni.Add(kanton);
            _db.SaveChanges();
            return Redirect("/Administracija/Kantoni/Index/");
        }
        public IActionResult Obrisi(int Id)
        {
            db.EntityModels.Kanton kanton = _db.Kantoni.Where(x => x.Id == Id).FirstOrDefault();
            _db.Kantoni.Remove(kanton);
            _db.SaveChanges();
            return Redirect("/Administracija/Kantoni/Index/");
        }
    }
}