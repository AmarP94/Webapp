using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSite.db;
using WebSite.db.BLL;
using WebSite.db.EntityModels;

namespace WebSite.Areas.Administracija.Controllers
{
    [Area("Administracija")]
    [Authorize]
    public class UserController : Controller
    {
        private DBBL _DBBL;
        public UserController(ApplicationDbContext applicationDbContext)
        {
            _DBBL = new DBBL(applicationDbContext);
        }
        public IActionResult PregledKorisnika()
        {
            return View();
        }

        public IActionResult GetData(int pageNumber, int pageSize)
        {
            pageNumber--;
            var users = _DBBL.GetAllUsers();
            if (users.Count >= pageSize)
            {
                users = users.GetRange(pageNumber * pageSize, pageSize);
            }
            var data = new
            {
                items = users.Select(item => new {
                    item.Id,
                    Ime = item.FirstName,
                    Prezime = item.LastName,
                    item.Email,
                    Telefon = item.PhoneNumber
                }),
                Total = _DBBL.GetAllUsers().Count
            };
            return Json(data);
        }

        public string Delete(string id)
        {
            var u = _DBBL.SelectUserById(id);
            if (u == null)
            {
                return "Korisnik nije pronadjen";
            }
            _DBBL.DeleteUser(u);
            return "Korisnik obrisan";
        }
        public IActionResult Edit(string id)
        {
            return Redirect("~/Identity/Account/Manage");
        }
    }
}