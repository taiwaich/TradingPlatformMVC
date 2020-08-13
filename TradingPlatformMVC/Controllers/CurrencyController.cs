using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingPlatformMVC.Models;

namespace TradingPlatformMVC.Controllers
{
    public class CurrencyController : Controller
    {
        TradingPlaformDb db = new TradingPlaformDb();
        // GET: Currency
        public ActionResult Index(string sortBy)
        {
            List<currency> allCurrencies = null;
            allCurrencies = db.currencies.ToList();
            ViewBag.SortingCurrencyPar = sortBy == "Currency" ? "Currency_desc" : "Currency";

            switch (sortBy)
            {
                case "Currency":
                    allCurrencies = db.currencies.OrderBy(t => t.name).ToList();
                    break;
                case "Currency_desc":
                    allCurrencies = db.currencies.OrderByDescending(t => t.name).ToList();
                    break;
                default:
                    break;
            }

            return View(allCurrencies);
        }

        // GET: Currency/Details/5
        public ActionResult Details(int id)
        {
            currency currencyIs;
            currencyIs = db.currencies.Find(id);

            return View(currencyIs);
        }

        // GET: Currency/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: Currency/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            try
            {
                // TODO: Add insert logic here
                currency currencyIs = new currency();
                currencyIs.name = form["name"];
                currencyIs.symbol = form["symbol"];
                // TODO: Add insert logic here
                db.currencies.Add(currencyIs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Currency/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Currency/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Currency/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Currency/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
