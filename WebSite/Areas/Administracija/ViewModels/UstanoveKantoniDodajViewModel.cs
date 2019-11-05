using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebSite.db.EntityModels;

namespace WebSite.Areas.Administracija.ViewModels
{
    public class UstanoveKantoniDodajViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Obavezan unos")]
        [StringLength(50,ErrorMessage ="Trebate unijeti od 10 do 50 karaktera",MinimumLength =10)]
        public string NazivUstanove { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        [StringLength(100, ErrorMessage = "Trebate unijeti od 10 do 50 karaktera", MinimumLength = 10)]
        public string Adresa { get; set; }
        [Required(ErrorMessage ="Obavezan unos")]
        [RegularExpression("[0-9]{3}\\/[0-9]{3}-[0-9]{3}",ErrorMessage ="Broj biti u formatu : 036/321-123")]
        public string KontaktTelefon { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        [EmailAddress(ErrorMessage ="Unesite ispravan format emaila")]
        public string Email { get; set; }
        [DataType(DataType.Url)]
        public string Link { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        public int KantonId { get; set; }
        public List<SelectListItem> Kantoni { get; set; }
       
    }
}
