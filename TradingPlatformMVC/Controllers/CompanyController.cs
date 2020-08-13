using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingPlatformMVC.Models;

namespace TradingPlatformMVC.Controllers
{
    public class CompanyController : Controller
    {

        TradingPlaformDb db = new TradingPlaformDb();

        // GET: Company
        public ActionResult Index(string sortBy)
        {
            List<company> allCompanies = null;
            allCompanies = db.companies.ToList();

            ViewBag.SortingCompanyNamePar = sortBy == "CompanyName" ? "CompanyName_desc" : "CompanyName";
            ViewBag.SortingPlaceIdPar = sortBy == "PlaceId" ? "PlaceId_desc" : "PlaceId";

            switch (sortBy)
            {
                case "CompanyName":
                    allCompanies = db.companies.OrderBy(t => t.name).ToList();
                    break;
                case "CompanyName_desc":
                    allCompanies = db.companies.OrderByDescending(t => t.name).ToList();
                    break;
                case "PlaceId":
                    allCompanies = db.companies.OrderBy(t => t.place_id).ToList();
                    break;
                case "PlaceId_desc":
                    allCompanies = db.companies.OrderByDescending(t => t.place_id).ToList();
                    break;
                default:
                    allCompanies = db.companies.OrderBy(t => t.name).ToList();
                    break;
            }

            return View(allCompanies);

        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            company companyIs;
            companyIs = db.companies.Find(id);
            return View(companyIs);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Company/Edit/5
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

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Company/Delete/5
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
