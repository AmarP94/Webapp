using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class LinkoviIndexViewModel
    {
        public List<Row> Rows { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public string URL { get; set; }
            public string NazivKategorije { get; set; }
        }
    }
}
