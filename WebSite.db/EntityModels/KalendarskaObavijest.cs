using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.db.EntityModels
{
    public class KalendarskaObavijest
    {
        public int Id { get; set; }
        public string NazivKO { get; set; }
        public DateTime DatumDodavanjaKO { get; set; }
        public DateTime? DatumIzmjeneKO { get; set; }
        public DateTime VrijemeNajaveKO { get; set; }
        public string TextKO { get; set; }
    }
}
