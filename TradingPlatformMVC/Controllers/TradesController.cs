using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingPlatformMVC.Models;

namespace TradingPlatformMVC.Controllers
{
    public class TradesController : Controller
    {
        // GET: Trades
        TradingPlaformDb db = new TradingPlaformDb();

        public ActionResult Index(string sortBy)
        {

            List<trade> allTrades = null;

            ViewBag.SortingShareIdPar = sortBy == "ShareId" ? "ShareId_desc" : "ShareId";
            ViewBag.SortingBrokerIdPar = sortBy == "BrokerId" ? "BrokerId_desc" : "BrokerId";
            ViewBag.SortingStockExIdPar = sortBy == "StockExId" ? "StockExId_desc" : "StockExId";
            ViewBag.SortingTransactionTimePar = sortBy == "TransactionTime" ? "TransactionTime_desc" : "TransactionTime";
            ViewBag.SortingShareAmountPar = sortBy == "ShareAmount" ? "ShareAmount_desc" : "ShareAmount";
            ViewBag.SortingPriceTotalPar = sortBy == "PriceTotal" ? "PriceTotal_desc" : "PriceTotal";

            switch (sortBy)
            {
                case "ShareId":
                    allTrades = db.trades.OrderBy(t => t.share_id).ToList();
                    break;
                case "ShareId_desc":
                    allTrades = db.trades.OrderByDescending(t => t.share_id).ToList();
                    break;
                case "BrokerId":
                    allTrades = db.trades.OrderBy(t => t.broker_id).ToList();
                    break;
                case "BrokerId_desc":
                    allTrades = db.trades.OrderByDescending(t => t.broker_id).ToList();
                    break;
                case "StockExId":
                    allTrades = db.trades.OrderBy(t => t.stock_ex_id).ToList();
                    break;
                case "StockExId_desc":
                    allTrades = db.trades.OrderByDescending(t => t.stock_ex_id).ToList();
                    break;
                case "TransactionTime":
                    allTrades = db.trades.OrderBy(t => t.transaction_time).ToList();
                    break;
                case "TransactionTime_desc":
                    allTrades = db.trades.OrderByDescending(t => t.transaction_time).ToList();
                    break;
                case "ShareAmount":
                    allTrades = db.trades.OrderBy(t => t.share_amount).ToList();
                    break;
                case "ShareAmount_desc":
                    allTrades = db.trades.OrderByDescending(t => t.share_amount).ToList();
                    break;
                case "PriceTotal":
                    allTrades = db.trades.OrderBy(t => t.price_total).ToList();
                    break;
                case "PriceTotal_desc":
                    allTrades = db.trades.OrderByDescending(t => t.price_total).ToList();
                    break;
                default:
                    allTrades = db.trades.OrderByDescending(t => t.price_total).ToList();
                    break;
            }

           
            return View(allTrades);

        }

        // GET: Trades/Details/5
        public ActionResult Details(int id)
        {
            trade tradeIs;
            tradeIs = db.trades.Find(id);
            return View(tradeIs);
        }

        // GET: Trades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trades/Create
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

        // GET: Trades/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trades/Edit/5
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

        // GET: Trades/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trades/Delete/5
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
