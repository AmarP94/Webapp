using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.db.EntityModels
{
    public class Anketa
    {
        public int Id { get; set; }
        public string NazivAnkete { get; set; }
        public bool AktivnaAnketa { get; set; }
        public DateTime DatumAnkete { get; set; }
    }
}
