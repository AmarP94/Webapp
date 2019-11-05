using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.db.EntityModels;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class UstanoveKantoniIndexViewModel
    {
        public string Pretraga { get; set; }
        public int Id { get; set; }
        public List<SelectListItem> Kantoni { get; set; }
        public List<Row> Rows { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string NazivUstanove { get; set; }
            public string Adresa { get; set; }
            public string KontaktTelefon { get; set; }
            public string Email { get; set; }
            public string Link { get; set; }
            public int KantonId { get; set; }
            public Kanton Kanton { get; set; }
        }
    }
}
