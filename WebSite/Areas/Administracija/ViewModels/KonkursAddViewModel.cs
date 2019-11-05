using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class KonkursAddViewModel
    {
        [Required(ErrorMessage ="Obavezan unos")]
        [StringLength(30,ErrorMessage ="Naziv mora imati izmedju 5 i 30 karaktera",MinimumLength =5)]
        public string NazivKonkursa { get; set; }
        
        public List<SelectListItem> TipKonkursa { get; set; }
        [Required(ErrorMessage ="Morate odabrati tip")]
        public int TipKonkursaId { get; set; }
        [Required(ErrorMessage ="Obavezan unos")]
        [StringLength(200,ErrorMessage ="Sadrzaj mora imati izmedju 10 i 200 karaktera",MinimumLength =10)]
        public string Sadrzaj { get; set; }
        [Required(ErrorMessage ="Morate odabrati datum")]
        [DataType(DataType.Date)]
        public DateTime DatumDodavanja { get; set; }
        
    }
}
