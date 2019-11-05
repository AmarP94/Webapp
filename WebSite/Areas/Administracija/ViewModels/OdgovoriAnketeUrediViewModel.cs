using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebSite.db.EntityModels;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class OdgovoriAnketeUrediViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Obavezan unos")]
        public string Odgovor { get; set; }
        public int AnketaId { get; set; }
    }
}
