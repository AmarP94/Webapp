using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class LinkoviDodajViewModel
    {
        public string Naziv { get; set; }
        public string URL { get; set; }
        [Required(ErrorMessage = "Morate odabrati kategoriju")]
        public int KategorijeLinkovaId { get; set; }
        public List<SelectListItem> Kategorija { get; set; }
    }
}
