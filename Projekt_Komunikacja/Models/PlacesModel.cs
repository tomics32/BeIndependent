using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projekt_Komunikacja.Models
{
    public class PlacesModel
    {
        [Key]
        public int PlaceID { get; set; }
        public string Nazwa { get; set; }
        public bool JestPrzystosowane { get; set; }

        [DisplayName("Photo")]
        [StringLength(1024)]
        public string Photo { get; set; }

        [Required]
        public virtual AdresModel Adres_ID { get; set; }
        [Required]
        public virtual KontaktModel Kontakt_ID { get; set; }
    }
}