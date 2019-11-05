using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSite.Areas.Administracija.ViewModels;
using WebSite.db;
using WebSite.db.EntityModels;

namespace WebSite.Areas.Administracija.Controllers
{
    [Area("Administracija")]
    [Authorize]
    public class KonkursController : Controller
    {
        private ApplicationDbContext _db;
        public KonkursController(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }
        public IActionResult Index(string pretraga)
        {
            KonkursIndexViewModel konkursi = new KonkursIndexViewModel();
            konkursi.Rows = _db.Konkursi.Where(x=>pretraga==null || x.NazivKonkursa.Contains(pretraga))
                .Select(x=>new KonkursIndexViewModel.Row
            {
                Id=x.Id,
                NazivKonkursa=x.NazivKonkursa,
                TipKonkursa=x.TipKonkursa.Naziv,
                DatumDodavanja=x.DatumDodavanja
            }).ToList();

            return View(konkursi);
        }
        public IActionResult Add()
        {
            KonkursAddViewModel dodaj = new KonkursAddViewModel();
            dodaj.DatumDodavanja = DateTime.Now;
            dodaj.TipKonkursa = _db.TipKonkursa.Select(x => new SelectListItem
            {
                Text=x.Naziv,
                Value=x.Id.ToString()
            }).ToList();
            
            return View(dodaj);
        }
        public IActionResult Snimi(KonkursAddViewModel vm)
        {
            db.EntityModels.Konkurs novi = new db.EntityModels.Konkurs();
            novi.DatumDodavanja = vm.DatumDodavanja;
            novi.NazivKonkursa = vm.NazivKonkursa;
            novi.TipKonkursaId = vm.TipKonkursaId;
            novi.Sadrzaj = vm.Sadrzaj;
            _db.Konkursi.Add(novi);

            _db.SaveChanges();
            return Redirect("/Administracija/Konkurs/Index/");
        }
        public IActionResult Obrisi(int Id)
        {
            db.EntityModels.Konkurs konkurs = _db.Konkursi.Where(x => x.Id == Id).FirstOrDefault();
            _db.Remove(konkurs);
            _db.SaveChanges();
            return Redirect("/Administracija/Konkurs/Index/");
        }
        public IActionResult Detalji(int Id)
        {
            KonkursDetaljiViewModel detalji = new KonkursDetaljiViewModel();
            db.EntityModels.Konkurs konkurs = _db.Konkursi.Where(x => x.Id == Id).FirstOrDefault();
            detalji.Id = konkurs.Id;
            detalji.NazivKonkursa = konkurs.NazivKonkursa;
            
            detalji.DatumDodavanja = konkurs.DatumDodavanja;
            detalji.DatumIzmjene = konkurs.DatumIzmjene;
            detalji.Sadrzaj = konkurs.Sadrzaj;
            return View(detalji);
        }
        public IActionResult Uredi(int Id)
        {
            db.EntityModels.Konkurs konkurs = _db.Konkursi.Where(x => x.Id == Id).FirstOrDefault();
            KonkursUrediViewModel uredi = new KonkursUrediViewModel();
            uredi.DatumDodavanja = konkurs.DatumDodavanja;
            uredi.NazivKonkursa = konkurs.NazivKonkursa;
            uredi.DatumIzmjene = DateTime.Now;
            uredi.Id = konkurs.Id;
            uredi.Sadrzaj = konkurs.Sadrzaj;
            return View(uredi);
        }
        public IActionResult SnimiUredi(KonkursUrediViewModel vm)
        {
            db.EntityModels.Konkurs urediKonkurs= _db.Konkursi.Where(x => x.Id == vm.Id).FirstOrDefault();
            urediKonkurs.Sadrzaj = vm.Sadrzaj;
            urediKonkurs.DatumIzmjene = vm.DatumIzmjene;
            _db.SaveChanges();
            return Redirect("/Administracija/Konkurs/Index/");
        }
    }
}