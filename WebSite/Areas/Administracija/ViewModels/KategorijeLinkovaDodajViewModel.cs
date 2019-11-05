using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class KategorijeLinkovaDodajViewModel
    {
        [Required(ErrorMessage ="Obavezan unos")]
        public string NazivKategorje { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        public string Opis { get; set; }
    }
}
