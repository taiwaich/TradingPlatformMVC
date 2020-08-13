using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingPlatformMVC.Models;

namespace TradingPlatformMVC.Controllers
{
    public class BrokerController : Controller
    {
        // GET: Broker
        TradingPlaformDb db = new TradingPlaformDb();

        public ActionResult Index()
        {
            List<broker> allBrokers = null;
            allBrokers = db.brokers.ToList();

            return View(allBrokers);
        }

        // GET: Broker/Details/5
        public ActionResult Details(int id)
        {
            broker brokerIs;
            brokerIs = db.brokers.Find(id);
            return View(brokerIs);

        }

        // GET: Broker/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Broker/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            try
            {
           //     int selectedBroker = Convert.ToInt32(form["BrokerDDL"]);

                // TODO: Add insert logic here
                broker brokerIs = new broker();
                brokerIs.first_name = form["first_name"];
                brokerIs.last_name = form["last_name"];
                // TODO: Add insert logic here
                db.brokers.Add(brokerIs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Broker/Edit/5
        public ActionResult Edit(int id)
        {
            broker brokerIs;
            brokerIs = db.brokers.Find(id);
            return View(brokerIs);
        }

        // POST: Broker/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            try
            {
                // TODO: Add update logic here
                broker brokerIs = db.brokers.Find(id);
                brokerIs.first_name = form["first_name"];
                brokerIs.last_name = form["last_name"];
                brokerIs.broker_id = id;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Broker/Delete/5
        public ActionResult Delete(int id)
        {
            broker brokerIs;
            brokerIs = db.brokers.Find(id);
            return View(brokerIs);
        }

        // POST: Broker/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                broker brokerInContext = db.brokers.Find(id);

                db.brokers.Remove(brokerInContext);
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
