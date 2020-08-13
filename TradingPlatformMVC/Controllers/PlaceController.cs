using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingPlatformMVC.Models;

namespace TradingPlatformMVC.Controllers
{
    public class PlaceController : Controller
    {
        // GET: Places
        TradingPlaformDb db = new TradingPlaformDb();
       public ActionResult Index()
        {
            List<place> allPlaces = null;
            allPlaces = db.places.ToList();

            return View(allPlaces);

        }

        // GET: Places/Details/5
        public ActionResult Details(int id)
        {
            place placeIs;
            placeIs = db.places.Find(id);
            return View(placeIs);
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            try
            {
                // TODO: Add insert logic here
             //   int selectedBroker = Convert.ToInt32(form["PlaceDDL"]);

                place placeIs = new place();
                placeIs.city = form["city"];
                placeIs.country = form["country"];
                // TODO: Add insert logic here
                db.places.Add(placeIs);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Places/Edit/5
        public ActionResult Edit(int id)
        {
            place placeIs;
            placeIs = db.places.Find(id);
            return View(placeIs);
        }

        // POST: Places/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            try
            {
                // TODO: Add update logic here
                place placeIs = db.places.Find(id);
                placeIs.city = form["city"];
                placeIs.country = form["country"];
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Places/Delete/5
        public ActionResult Delete(int id)
        {
            place placeIs;
            placeIs = db.places.Find(id);
            return View(placeIs);
        }

        // POST: Places/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                place placeInContext = db.places.Find(id);

                db.places.Remove(placeInContext);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
