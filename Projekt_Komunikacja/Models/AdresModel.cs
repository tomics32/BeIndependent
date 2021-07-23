using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projekt_Komunikacja.Models
{
    public class AdresModel
    {
        [Key]
        public int Adres_ID { get; set; }
        public string KodPocztowy { get; set; }
        public string Ulica { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}