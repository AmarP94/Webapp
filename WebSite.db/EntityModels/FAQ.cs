using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.db.EntityModels
{
    public class FAQ
    {
        public int Id { get; set; }
        public string Pitanje { get; set; }
        public string Odgovor { get; set; }
        public bool AktivanOdgovor { get; set; }
        public DateTime DatumIzmjeneOdgovora { get; set; }
    }
}
