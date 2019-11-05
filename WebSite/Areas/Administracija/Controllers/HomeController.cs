using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSite.Areas.Administracija.ViewModels;
using WebSite.db;
using WebSite.db.BLL;
using WebSite.db.EntityModels;

namespace WebSite.Areas.Administracija.Controllers
{
    [Area("Administracija")]
    [Authorize]
    public class HomeController : Controller
    {
        private DBBL _DBBL ;

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _DBBL = new DBBL(applicationDbContext);
        }
        public IActionResult Index()
        {
            List<KalendarskaObavijest> ko = _DBBL.GetAllKalendarskeObavijesti();
            return View(ko);
        }
        public IActionResult Add()
        {
            //Date = {1/1/0001 12:00:00 AM}
            
            return View();
        }
        [HttpPost]
        public IActionResult Add(KalendarskaObavijestAddViewModel request)
        {
            if (request != null)
            {
                KalendarskaObavijest ko = new KalendarskaObavijest() {
                    NazivKO = request.Naziv,
                    TextKO = request.Text,
                    VrijemeNajaveKO = request.VrijemeNajave,
                    DatumDodavanjaKO = DateTime.Now,
                    DatumIzmjeneKO = DateTime.Now
                };
                if (_DBBL.AddKalendarskuObavijest(ko))
                {
                    Response.Redirect("Index");
                }
            }
            return PartialView("_Error");
        }

        public IActionResult Remove(int id)
        {
            if (_DBBL.ObrisiKO(id))
            {
                Response.Redirect("Index");
            }
            return PartialView("_Error");
        }
    }
}