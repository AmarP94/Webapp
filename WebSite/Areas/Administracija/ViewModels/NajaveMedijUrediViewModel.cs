using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class NajaveMedijUrediViewModel
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumIzmjene { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumObjave { get; set; }
        public string Sadrzaj { get; set; }
    }
}
