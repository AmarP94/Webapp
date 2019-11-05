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
    [Area("Administracija")]
    [Authorize]
    public class TipKonkursaController : Controller
    {
        private ApplicationDbContext _db;
        public TipKonkursaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            TipKonkursaIndexVIewModel tipovi = new TipKonkursaIndexVIewModel();
            tipovi.Rows = _db.TipKonkursa.Select(x => new TipKonkursaIndexVIewModel.Row
            {
                Id=x.Id,
                Naziv=x.Naziv
            }).ToList();
            return View(tipovi);
        }
        public IActionResult Dodaj()
        {
            TipKonkursaDodajViewModel dodaj = new TipKonkursaDodajViewModel();

            return View(dodaj);
        }
        public IActionResult Snimi(TipKonkursaDodajViewModel vm)
        {
            db.EntityModels.TipKonkursa tip = new db.EntityModels.TipKonkursa();
            tip.Naziv = vm.Naziv;
            _db.TipKonkursa.Add(tip);
            _db.SaveChanges();
            return Redirect("/Administracija/TipKonkursa/Index/");
        }
        public IActionResult Obrisi(int Id)
        {
            db.EntityModels.TipKonkursa tip = _db.TipKonkursa.Where(x => x.Id == Id).FirstOrDefault();
            _db.TipKonkursa.Remove(tip);
            _db.SaveChanges();
            return Redirect("/Administracija/TipKonkursa/Index/");
        }
    }
}