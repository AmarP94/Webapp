using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class KonkursUrediViewModel
    {
        public int Id { get; set; }
        public string Sadrzaj { get; set; }
        public string NazivKonkursa { get; set; }
        public DateTime DatumDodavanja { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumIzmjene { get; set; }
    }
}
