using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class FAQUrediViewModel
    {
        public int Id { get; set; }
        
        public string Pitanje { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        public string Odgovor { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumIzmjene { get; set; }
    }
}
