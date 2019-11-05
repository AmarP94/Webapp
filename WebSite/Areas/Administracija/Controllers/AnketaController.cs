using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebSite.Areas.Administracija.ViewModels;
using WebSite.db;

namespace WebSite.Areas.Administracija.Controllers
{
    [Area("Administracija")]
    [Authorize]
    public class AnketaController : Controller
    {
        private ApplicationDbContext _db;
        public AnketaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string pretraga)
        {
            AnketaIndexViewModel ankete = new AnketaIndexViewModel();
            ankete.Rows = _db.Ankete.Where(x=>pretraga==null || x.NazivAnkete.Contains(pretraga))
                .Select(x => new AnketaIndexViewModel.Row
            {
                Id=x.Id,
                DatumAnkete=x.DatumAnkete,
                NazivAnkete=x.NazivAnkete,
                AktivnaAnketa=x.AktivnaAnketa
            }).ToList();
            return View(ankete);
        }
        public IActionResult Dodaj()
        {
            AnketaDodajViewModel dodaj = new AnketaDodajViewModel();
            dodaj.DatumAnkete = DateTime.Now;
            dodaj.AktivnaAnketa = true;
            return View(dodaj);
        }
        public IActionResult Snimi(AnketaDodajViewModel vm)
        {
            db.EntityModels.Anketa anketa = new db.EntityModels.Anketa();
            anketa.NazivAnkete = vm.Naziv;
            anketa.DatumAnkete = vm.DatumAnkete;
            anketa.AktivnaAnketa = vm.AktivnaAnketa;
            _db.Ankete.Add(anketa);

            db.EntityModels.OdgovoriAnkete odgovor = new db.EntityModels.OdgovoriAnkete();
            odgovor.AnketaId = anketa.Id;
            _db.OdgovoriAnkete.Add(odgovor);


            _db.SaveChanges();
            return Redirect("/Administracija/Anketa/Index/");
        }
        public IActionResult Promijeni(int Id)
        {
            db.EntityModels.Anketa anketa = _db.Ankete.Where(x => x.Id == Id).FirstOrDefault();
            if (anketa.AktivnaAnketa == true)
            {
                anketa.AktivnaAnketa = false;
            }
            else
            {
                anketa.AktivnaAnketa = true;
            }
            _db.SaveChanges();
            return Redirect("/Administracija/Anketa/Index/");
        }
        public IActionResult Obrisi(int Id)
        {
            db.EntityModels.Anketa anketa = _db.Ankete.Where(x => x.Id == Id).FirstOrDefault();
            db.EntityModels.OdgovoriAnkete odgovor = _db.OdgovoriAnkete.Where(x => x.AnketaId == Id).FirstOrDefault();
            _db.Ankete.Remove(anketa);
            _db.OdgovoriAnkete.Remove(odgovor);
            _db.SaveChanges();
            return Redirect("/Administracija/Anketa/Index/");
        }
    }
}