using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekt_Komunikacja.Models;


namespace Projekt_Komunikacja.Controllers
{
    public class PlacesController : Controller
    {
        private PlacesEntities db = new PlacesEntities();
        // GET: Places
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Nazwa_desc" : "";
            ViewBag.DisabledSortParm = sortOrder == "JestPrzystosowane" ? "JestPrzystosowane_desc" : "JestPrzystosowane";

            PlacesEntities Places = new PlacesEntities();
            List<PlacesModel> PlacesLista = Places.Places.ToList();
            List<AdresModel> AdresLista = Places.Adres.ToList();
            List<KontaktModel> KontaktLista = Places.Kontakt.ToList();

            var multipleTables = from c in PlacesLista
                                     join adr in AdresLista on c.PlaceID equals adr.Adres_ID into table1
                                     from adr in table1.DefaultIfEmpty()
                                     join kt in KontaktLista on adr.Adres_ID equals kt.Kontakt_ID into table2
                                     from kt in table2.DefaultIfEmpty()
                                     select new MultipleTablesModel { PlacesList = c, AdresList = adr, KontaktList = kt };

            switch (sortOrder)
            {
                case "Nazwa_desc":
                    multipleTables = multipleTables.OrderByDescending(c => c.PlacesList.Nazwa);
                    break;
                case "JestPrzystosowane":
                    multipleTables = multipleTables.OrderBy(c => c.PlacesList.JestPrzystosowane);
                    break;
                case "JestPrzystosowane_desc":
                    multipleTables = multipleTables.OrderByDescending(c => c.PlacesList.JestPrzystosowane);
                    break;
                default:
                    multipleTables = multipleTables.OrderBy(c => c.PlacesList.Nazwa);
                    break;
            }

            ViewData["jointables"] = multipleTables;

            return View(ViewData["jointables"]);
        }

        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MultipleTablesModel place)
        {

            PlacesEntities db = new PlacesEntities();

            KontaktModel newKontakt = new KontaktModel();
            newKontakt.Email = place.KontaktList.Email;
            newKontakt.NrTelefonu = place.KontaktList.NrTelefonu;

            db.Kontakt.Add(newKontakt);
            db.SaveChanges();

            AdresModel newAdres = new AdresModel();
            newAdres.KodPocztowy = place.AdresList.KodPocztowy;
            newAdres.Ulica = place.AdresList.Ulica;
            newAdres.Lat = place.AdresList.Lat;
            newAdres.Long = place.AdresList.Long;
            

            db.Adres.Add(newAdres);
            db.SaveChanges();

            PlacesModel newPlace = new PlacesModel();
            newPlace.Nazwa = place.PlacesList.Nazwa;
            newPlace.JestPrzystosowane = place.PlacesList.JestPrzystosowane;
            newPlace.Photo = place.PlacesList.Photo;
            newPlace.Adres_ID = newAdres;
            newPlace.Kontakt_ID = newKontakt;

            db.Places.Add(newPlace);
            db.SaveChanges();



            return View(place);
        }

        public ActionResult Delete(int id)
        {
            using (PlacesEntities db = new PlacesEntities())
            {
                PlacesModel details = db.Places.Where(x => x.PlaceID == id).FirstOrDefault();
                return View(details);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (PlacesEntities db = new PlacesEntities())
                {
                    PlacesModel klient = db.Places.Where(x => x.PlaceID == id).FirstOrDefault();
                    db.Places.Remove(klient);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}