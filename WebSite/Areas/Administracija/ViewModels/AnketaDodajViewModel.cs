using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class AnketaDodajViewModel
    {
        [Required(ErrorMessage ="Obavezan unos")]
        [StringLength(20,ErrorMessage ="Naziv ankete moze imati izmedjdu 10 i 20 karaktera",MinimumLength =10)]
        public string Naziv { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumAnkete { get; set; }
        public bool AktivnaAnketa { get; set; }
    }
}
