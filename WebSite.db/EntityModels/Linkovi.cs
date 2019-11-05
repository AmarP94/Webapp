using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.db.EntityModels
{
    public class Linkovi
    {
        public int Id { get; set; }
        public string NazivLinka { get; set; }
        public string URL { get; set; }
        public int KategorijeLinkovaId { get; set; }
        public KategorijeLinkova KategorijeLinkova { get; set; }
    }
}
