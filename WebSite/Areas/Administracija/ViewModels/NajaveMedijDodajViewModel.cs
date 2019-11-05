using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class NajaveMedijDodajViewModel
    {
        [Required(ErrorMessage ="Obavezan unos")]
        [StringLength(40,ErrorMessage ="Naslov mora imati izmedju 10 i 40 karaktera",MinimumLength =10)]
        public string Naslov { get; set; }
        [Required(ErrorMessage ="Obavezan unos")]
        [DataType(DataType.Date)]
        public DateTime DatumObjave { get; set; }
        [Required(ErrorMessage ="Obavezan unos")]
        public string Sadrzaj { get; set; }
    }
}
