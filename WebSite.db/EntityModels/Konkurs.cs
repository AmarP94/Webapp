using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.db.EntityModels
{
    public class Konkurs
    {
        public int Id { get; set; }
        public string NazivKonkursa { get; set; }
        public int TipKonkursaId { get; set; }
        public TipKonkursa TipKonkursa { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumDodavanja { get; set; }
        public DateTime? DatumIzmjene { get; set; }
    }
}
