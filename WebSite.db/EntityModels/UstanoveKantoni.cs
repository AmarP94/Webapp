using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.db.EntityModels
{
    public class UstanoveKantoni
    {
        public int Id { get; set; }
        public string NazivUstanove { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }
        public string Email { get; set; }
        public string Link { get; set; }
        public int KantonId { get; set; }
        public Kanton Kanton { get; set; }
    }
}
