using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class KalendarskaObavijestAddViewModel
    {
        public string Naziv { get; set; }
        public DateTime VrijemeNajave { get; set; }
        public string Text { get; set; }
    }
}
