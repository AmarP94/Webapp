using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.db.EntityModels
{
    public class OdgovoriAnkete
    {
        public int Id { get; set; }
        public string Odgovor { get; set; }
        public int AnketaId { get; set; }
        public Anketa Anketa { get; set; }
    }
}
