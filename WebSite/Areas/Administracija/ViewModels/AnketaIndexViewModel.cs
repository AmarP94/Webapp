using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class AnketaIndexViewModel
    {
        public List<Row> Rows { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string NazivAnkete { get; set; }
            [DataType(DataType.Date)]
            public DateTime DatumAnkete { get; set; }
            public bool AktivnaAnketa { get; set; }
        }
    }
}
