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
    public class FAQController : Controller
    {
        private ApplicationDbContext _db;
        public FAQController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string pretraga)
        {
            FAQIndexViewModel pitanja = new FAQIndexViewModel();
            pitanja.Rows = _db.FAQs.Where(x=>pretraga==null || x.Pitanje.Contains(pretraga)).Select(x => new FAQIndexViewModel.Row
            {
                Id=x.Id,
                Pitanje=x.Pitanje,
                AktivanOdgovor=x.AktivanOdgovor
            }).ToList();
            return View(pitanja);
        }
        public IActionResult Dodaj()
        {
            FAQDodajViewModel dodaj = new FAQDodajViewModel();
            
            return View(dodaj);
        }
        public IActionResult Snimi(FAQDodajViewModel vm)
        {
            db.EntityModels.FAQ pitanje = new db.EntityModels.FAQ();
            pitanje.Pitanje = vm.Pitanje;
            pitanje.Odgovor = vm.Odgovor;
            _db.FAQs.Add(pitanje);
            _db.SaveChanges();
            return Redirect("/Administracija/FAQ/Index/");
        }
        public IActionResult Promijeni(int Id)
        {
            db.EntityModels.FAQ status = _db.FAQs.Where(x => x.Id == Id).FirstOrDefault();
            if (status.AktivanOdgovor == true)
            {
                status.AktivanOdgovor = false;
            }
            else
            {
                status.AktivanOdgovor = true;
            }
            _db.SaveChanges();
            return Redirect("/Administracija/FAQ/Index/");
        }
        public IActionResult Detalji(int Id)
        {
            FAQDetaljiViewModel detalji = new FAQDetaljiViewModel();
            db.EntityModels.FAQ faq = _db.FAQs.Where(x => x.Id == Id).FirstOrDefault();
            detalji.Pitanje = faq.Pitanje;
            detalji.Odgovor = faq.Odgovor;
            detalji.AktivanOdgovor = faq.AktivanOdgovor;
            detalji.DatumIzmjene = faq.DatumIzmjeneOdgovora;

            return View(detalji);
        }
        public IActionResult Uredi(int Id)
        {
            db.EntityModels.FAQ faq = _db.FAQs.Where(x => x.Id == Id).FirstOrDefault();
            FAQUrediViewModel uredi = new FAQUrediViewModel();
            uredi.Id = Id;
            uredi.Odgovor = "";
            uredi.Pitanje = _db.FAQs.Where(x => x.Id == Id).FirstOrDefault().Pitanje;
            uredi.DatumIzmjene = DateTime.Now;
            return View(uredi);
        }
        public IActionResult SnimiUredi(FAQUrediViewModel vm)
        {
            db.EntityModels.FAQ faq = _db.FAQs.Where(x => x.Id == vm.Id).FirstOrDefault();
            
            faq.Odgovor = vm.Odgovor;
            faq.DatumIzmjeneOdgovora = vm.DatumIzmjene;
            _db.SaveChanges();
            return Redirect("/Administracija/FAQ/Index/");
        }
        public IActionResult Obrisi(int Id)
        {
            db.EntityModels.FAQ faq = _db.FAQs.Where(x => x.Id == Id).FirstOrDefault();
            _db.FAQs.Remove(faq);
            _db.SaveChanges();
            return Redirect("/Administracija/FAQ/Index/");
        }
    }
}