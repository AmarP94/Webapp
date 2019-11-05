using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class KonkursIndexViewModel
    {
        public List<Row> Rows { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string NazivKonkursa { get; set; }
            [DataType(DataType.Date)]
            public DateTime DatumDodavanja { get; set; }
            public string TipKonkursa { get; set; }
        }
    }
}
