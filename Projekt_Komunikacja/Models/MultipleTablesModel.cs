using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt_Komunikacja.Models
{
    public class MultipleTablesModel
    {
        public PlacesModel PlacesList { get; set; }
        public AdresModel AdresList { get; set; }
        public KontaktModel KontaktList { get; set; }
    }
}