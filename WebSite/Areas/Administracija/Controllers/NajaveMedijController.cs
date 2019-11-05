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
    public class NajaveMedijController : Controller
    {
        private ApplicationDbContext _db;
        public NajaveMedijController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string pretraga)
        {
            NajaveMedijIndexViewModel najave = new NajaveMedijIndexViewModel();
            najave.Rows = _db.NajaveMediji.Where(x=>pretraga==null || x.NaslovNajave.Contains(pretraga)).Select(x => new NajaveMedijIndexViewModel.Row
            {
                Id=x.Id,
                DatumObjave=x.DatumObjave,
                Naslov=x.NaslovNajave
            }).ToList();
            return View(najave);
        }
        public IActionResult Dodaj()
        {
            NajaveMedijDodajViewModel dodaj = new NajaveMedijDodajViewModel();
            dodaj.DatumObjave = DateTime.Now;

            return View(dodaj);
        }
        public IActionResult Snimi(NajaveMedijDodajViewModel vm)
        {
            db.EntityModels.NajaveMediji najava = new db.EntityModels.NajaveMediji();
            najava.NaslovNajave = vm.Naslov;
            najava.DatumObjave = vm.DatumObjave;
            najava.Sadrzaj = vm.Sadrzaj;
            _db.NajaveMediji.Add(najava);
            _db.SaveChanges();
            return Redirect("/Administracija/NajaveMedij/Index/");
        }
        public IActionResult Uredi(int Id)
        {
            NajaveMedijUrediViewModel uredi = new NajaveMedijUrediViewModel();
            db.EntityModels.NajaveMediji najava = _db.NajaveMediji.Where(x => x.Id == Id).FirstOrDefault();
            uredi.DatumIzmjene = DateTime.Now;
            uredi.DatumObjave = najava.DatumObjave;
            uredi.Naslov = najava.NaslovNajave;
            return View(uredi);
        }
        public IActionResult SnimiUredi(NajaveMedijUrediViewModel vm)
        {
            db.EntityModels.NajaveMediji najava = _db.NajaveMediji.Where(x => x.Id == vm.Id).FirstOrDefault();
            najava.Sadrzaj = vm.Sadrzaj;
            najava.DatumIzmjene = vm.DatumIzmjene;
            _db.SaveChanges();
            return Redirect("/Administracija/NajaveMedij/Index/");
        }
        public IActionResult Obrisi(int Id)
        {
            db.EntityModels.NajaveMediji najava = _db.NajaveMediji.Where(x => x.Id == Id).FirstOrDefault();
            _db.NajaveMediji.Remove(najava);
            _db.SaveChanges();
            return Redirect("/Administracija/NajaveMedij/Index/");
        }
        public IActionResult Detalji(int Id)
        {
            db.EntityModels.NajaveMediji najava = _db.NajaveMediji.Where(x => x.Id == Id).FirstOrDefault();
            NajaveMedijDetaljiViewModel detalji = new NajaveMedijDetaljiViewModel();
            detalji.Id = najava.Id;
            detalji.Naslov = najava.NaslovNajave;
            detalji.Sadrzaj = najava.Sadrzaj;
            detalji.DatumObjave = najava.DatumObjave;
            detalji.DatumIzmjene = najava.DatumIzmjene;
            
            return View(detalji);
        }
    }
}