using Assignment5.DataAccess;
using Assignment5.Models;
using Assignment5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Assignment5.Controllers
{
    public class StoreController : Controller
    {

        private StoreRepository repo = new StoreRepository();
        private ShoppingCart cart = new ShoppingCart();

        public ActionResult About() {

            return View();
        }
        
        public ActionResult Index()
        {
            IEnumerable<StockItem> items = repo.GetAllStockItems(); 
            return View(items);
        }

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem item  = repo.GetStockItemByArticleNumber(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem item = repo.GetStockItemByArticleNumber(id);
            
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockItem item = repo.GetStockItemByArticleNumber(id);
            repo.DeleteStockItem(item);
            return RedirectToAction("Index");
        }




        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockItem item) {

            if (ModelState.IsValid)
            {
                repo.CreateStockItem(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem item = repo.GetStockItemByArticleNumber(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StockItem item)
        {
            if (ModelState.IsValid)
            {
                repo.EditStockItem(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public ActionResult AddToCart(int? id) { 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem item  = repo.GetStockItemByArticleNumber(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            cart.AddToCart(item);
            return RedirectToAction("Index");

        }

        public ActionResult ViewCart()
        {
            IEnumerable<StockItem> items = cart.GetAllItemsInCart(); 
            return View(items);
        }


    }
}