using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Configuration;

namespace Projekt_Komunikacja.Models
{
    public class PlacesEntities : DbContext
    {
        public DbSet<PlacesModel> Places { get; set; }
        public DbSet<AdresModel> Adres { get; set; }
        public DbSet<KontaktModel> Kontakt { get; set; }
    }
}