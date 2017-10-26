using Assignment5.DataAccess;
using Assignment5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment5.Repositories
{
    public class StoreRepository
    {

        private StoreContext context;

        public StoreRepository()
        {
            context = new StoreContext();
        }

        public IEnumerable<StockItem> GetAllStockItems() {
            return context.Items.ToList();
        }

        public StockItem GetStockItemByArticleNumber(int? an)
        {
            if (an == null) {
                return null;
            }
            return context.Items.FirstOrDefault(item => item.ArticleNumber == an);
        }

        public IEnumerable<StockItem> GetStockItemByTitle(string name)
        {
            return context.Items.Where(item => item.Name.ToLower().Contains(name.ToLower()));
        }

        public IEnumerable<StockItem> GetStockItemByTitle(double price)
        {
            return context.Items.Where(item => item.Price == price);
        }

        public void CreateStockItem(StockItem item) {
            context.Items.Add(item);
            context.SaveChanges();
        }

        public void DeleteStockItem(StockItem item) {
            if (item != null) { 
                context.Items.Remove(item);
                context.SaveChanges();
            }
        }

        public void EditStockItem(StockItem item){
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
        }
    

    }
}