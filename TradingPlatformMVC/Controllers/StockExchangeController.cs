using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingPlatformMVC.Models;

namespace TradingPlatformMVC.Controllers
{
    public class StockExchangeController : Controller
    {
        // GET: StockExchange
        TradingPlaformDb db = new TradingPlaformDb();
        public ActionResult Index()
        {
            List<stock_exchanges> allStockExchanges = null;
            allStockExchanges = db.stock_exchanges.ToList();

            return View(allStockExchanges);
        }

        // GET: StockExchange/Details/5
        public ActionResult Details(int id)
        {
            stock_exchanges stockExchangeIs;
            stockExchangeIs = db.stock_exchanges.Find(id);
            return View(stockExchangeIs);
        }

        // GET: StockExchange/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockExchange/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            try
            {
                // TODO: Add insert logic here

                stock_exchanges stockExchangeIs = new stock_exchanges();
                stockExchangeIs.name= form["name"];
                stockExchangeIs.symbol = form["symbol"];
                stockExchangeIs.place_id = Convert.ToInt32(form["place_id"]);
                // TODO: Add insert logic here
                db.stock_exchanges.Add(stockExchangeIs);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StockExchange/Edit/5
        public ActionResult Edit(int id)
        {
            stock_exchanges stockExchangeIs;
            stockExchangeIs = db.stock_exchanges.Find(id);
            return View(stockExchangeIs);

        }

        // POST: StockExchange/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            try
            {
                // TODO: Add update logic here
                stock_exchanges stockExchangeIs = db.stock_exchanges.Find(id);
                stockExchangeIs.name = form["name"];
                stockExchangeIs.symbol = form["symbol"];
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StockExchange/Delete/5
        public ActionResult Delete(int id)
        {
            stock_exchanges stockExchangeIs;
            stockExchangeIs = db.stock_exchanges.Find(id);
            return View(stockExchangeIs);
        }

        // POST: StockExchange/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                stock_exchanges stockExchangeInContext = db.stock_exchanges.Find(id);

                db.stock_exchanges.Remove(stockExchangeInContext);
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
