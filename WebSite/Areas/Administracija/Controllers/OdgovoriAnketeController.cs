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
    public class OdgovoriAnketeController : Controller
    {
        private ApplicationDbContext _db;
        public OdgovoriAnketeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int Id)
        {
            OdgovoriAnketeIndexViewModel odgovori = new OdgovoriAnketeIndexViewModel();
            odgovori.Rows = _db.OdgovoriAnkete.Where(x => x.AnketaId == Id).Select(x => new OdgovoriAnketeIndexViewModel.Row
            {
                Id = x.Id,
                Odgovor=x.Odgovor
            }).ToList();
            odgovori.AnketaId = Id;
            return View(odgovori);
        }
        public IActionResult Uredi(int Id)
        {
            OdgovoriAnketeUrediViewModel uredi = new OdgovoriAnketeUrediViewModel();
            db.EntityModels.OdgovoriAnkete odgovor = _db.OdgovoriAnkete.Where(x => x.Id == Id).FirstOrDefault();
            uredi.AnketaId = odgovor.AnketaId;
           
            return View(uredi);
        }
        public IActionResult SnimiUredi(OdgovoriAnketeUrediViewModel vm)
        {
            db.EntityModels.OdgovoriAnkete odgovor = _db.OdgovoriAnkete.Where(x => x.Id == vm.Id).FirstOrDefault();
            odgovor.Odgovor = vm.Odgovor;
            _db.SaveChanges();
            return Redirect("/Administracija/OdgovoriAnkete/Index/"+odgovor.AnketaId);
        }
        public IActionResult Dodaj(int Id)
        {
            OdgovoriAnketeUrediViewModel dodaj = new OdgovoriAnketeUrediViewModel();
            dodaj.AnketaId = Id;

            return View(dodaj);
        }
        public IActionResult SnimiDodaj(OdgovoriAnketeUrediViewModel vm)
        {
            db.EntityModels.OdgovoriAnkete odgovor = new db.EntityModels.OdgovoriAnkete();
            odgovor.AnketaId = vm.AnketaId;
            odgovor.Odgovor = vm.Odgovor;
            _db.OdgovoriAnkete.Add(odgovor);
            _db.SaveChanges();
            return Redirect("/Administracija/OdgovoriAnkete/Index/" + odgovor.AnketaId);
        }
        public IActionResult Obrisi(int Id)
        {
            db.EntityModels.OdgovoriAnkete odgovor = _db.OdgovoriAnkete.Where(x => x.Id == Id).FirstOrDefault();
            _db.OdgovoriAnkete.Remove(odgovor);
            _db.SaveChanges();
            return Redirect("/Administracija/OdgovoriAnkete/Index/" + odgovor.AnketaId);
        }
    }
}