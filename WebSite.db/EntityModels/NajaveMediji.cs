using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.db.EntityModels
{
    public class NajaveMediji
    {
        public int Id { get; set; }
        public string NaslovNajave { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumObjave { get; set; }
        public DateTime DatumIzmjene { get; set; }
    }
}
