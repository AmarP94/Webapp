using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class FAQDodajViewModel
    {
        [Required(ErrorMessage ="Obavezan unos")]
        public string Pitanje { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        public string Odgovor { get; set; }
    }
}
