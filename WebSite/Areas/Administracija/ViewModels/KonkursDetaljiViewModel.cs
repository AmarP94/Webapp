using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class KonkursDetaljiViewModel
    {
        public int Id { get; set; }
        public string NazivKonkursa { get; set; }
        public string TipKonkursa { get; set; }
        public DateTime DatumDodavanja { get; set; }
        public DateTime? DatumIzmjene { get; set; }
        public string Sadrzaj { get; set; }
    }
}
