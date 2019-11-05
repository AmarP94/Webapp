using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class KantoniDodajViewModel
    {
        [Required(ErrorMessage ="Obavezan unos")]
        public string Naziv { get; set; }
        [Required(ErrorMessage ="Obavezan unos")]
        public string Oznaka { get; set; }
    }
}
