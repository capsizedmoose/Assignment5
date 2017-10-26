using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Assignment5.DataAccess
{
    public class StoreContext : DbContext
    {
        public DbSet<Models.StockItem> Items { get; set; }


        public StoreContext() : base("DefaultConnection")
        {

        }
    }
}