using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projekt_Komunikacja.Models
{
    public class KontaktModel
    {
        [Key]
        public int Kontakt_ID { get; set; }
        public string NrTelefonu { get; set; }
        public string Email { get; set; }
    }
}