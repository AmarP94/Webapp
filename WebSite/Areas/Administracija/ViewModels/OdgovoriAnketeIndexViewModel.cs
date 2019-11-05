using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class OdgovoriAnketeIndexViewModel
    {
        public int AnketaId { get; set; }
        public List<Row> Rows { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Odgovor { get; set; }
        }

    }
}
