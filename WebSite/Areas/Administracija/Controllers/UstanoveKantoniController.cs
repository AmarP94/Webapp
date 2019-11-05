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
    [Area("Administracija")]
    [Authorize]
    public class UstanoveKantoniController : Controller
    {
        private ApplicationDbContext _db;
        public UstanoveKantoniController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int Id,string pretraga)
        {

            UstanoveKantoniIndexViewModel ustanove = new UstanoveKantoniIndexViewModel();
            ustanove.Rows = _db.Ustanove.Where(x => x.KantonId == Id)
                .Where(x=>x.NazivUstanove.Contains(pretraga)|| pretraga==null)
                .Select(x => new UstanoveKantoniIndexViewModel.Row
            {
                Id=x.Id,
                NazivUstanove=x.NazivUstanove,
                Adresa=x.Adresa,
                KontaktTelefon=x.KontaktTelefon,
                Email=x.Email,
                Link=x.Link,
               
            }).ToList();
           
            ustanove.Id = Id;
            ustanove.Kantoni = _db.Kantoni.Select(x => new SelectListItem
            {
                Text=x.NazivKantona,
                Value=x.Id.ToString()
            }).ToList();
           
            return View(ustanove);
        }
        public IActionResult Dodaj(int Id)
        {
            UstanoveKantoniDodajViewModel dodaj = new UstanoveKantoniDodajViewModel();
            dodaj.KantonId = Id;
            dodaj.Kantoni = _db.Kantoni.Select(x => new SelectListItem
            {
                Text = x.NazivKantona,
                Value = x.Id.ToString()
            }).ToList();
            return View(dodaj);
        }
        public IActionResult Snimi(UstanoveKantoniDodajViewModel vm)
        {
            db.EntityModels.UstanoveKantoni ustanova;
            if (vm.Id == 0)
            {
                ustanova = new db.EntityModels.UstanoveKantoni();
                _db.Ustanove.Add(ustanova);
            }
            else
            {
                ustanova = _db.Ustanove.Find(vm.Id);
            }
            ustanova.KantonId = vm.KantonId;
            ustanova.NazivUstanove = vm.NazivUstanove;
            ustanova.Adresa = vm.Adresa;
            ustanova.KontaktTelefon = vm.KontaktTelefon;
            ustanova.Link = vm.Link;
            ustanova.Email = vm.Email;
            _db.SaveChanges();
            return Redirect("/Administracija/UstanoveKantoni/Index/" + ustanova.KantonId);
        }
        public IActionResult Uredi(int Id)
        {
            db.EntityModels.UstanoveKantoni ustanova = _db.Ustanove.Find(Id);
            UstanoveKantoniDodajViewModel uredi = new UstanoveKantoniDodajViewModel
            {
                Id = ustanova.Id,
                Adresa = ustanova.Adresa,
                Email = ustanova.Email,
                KontaktTelefon = ustanova.KontaktTelefon,
                Link = ustanova.Link,
                NazivUstanove = ustanova.NazivUstanove,
                KantonId = ustanova.KantonId,
                Kantoni = _db.Kantoni.Select(x => new SelectListItem
                {
                    Text = x.NazivKantona,
                    Value = x.Id.ToString()
                }).ToList()
            };
            return View(uredi);
        }
        public IActionResult Obrisi(int Id)
        {
            db.EntityModels.UstanoveKantoni ustanova = _db.Ustanove.Find(Id);
            _db.Ustanove.Remove(ustanova);
            _db.SaveChanges();
            return Redirect("/Administracija/UstanoveKantoni/Index/" + ustanova.KantonId);
        }
      
    }
}