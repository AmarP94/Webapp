using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class FAQIndexViewModel
    {
        public List<Row> Rows { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Pitanje { get; set; }
            public bool AktivanOdgovor { get; set; }
        }
    }
}
