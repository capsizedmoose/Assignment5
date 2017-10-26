namespace Assignment5.Migrations
{
    using Assignment5.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment5.DataAccess.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assignment5.DataAccess.StoreContext context)
        {
            context.Items.AddOrUpdate(
              p => p.ArticleNumber,
              new StockItem {
                  ArticleNumber = 1, 
                  Name          = "dyr banan",
                  Price         = 54.50,
                  ShelfPosition = "Frukt",
                  Quantity      = 10,
                  Description   = "En banan som alla andra, men denna är obegripligt dyr av vad som verkas vara ingen anledning alls"
              },
              new StockItem {
                  ArticleNumber = 2, 
                  Name          = "Kex",
                  Price         = 15.90,
                  ShelfPosition = "Bröd och Bakverk",
                  Quantity      = 25,
                  Description   = "30-pack av landets finaste kex gjorda av underbetalda barnarbetare i ohållbara förhållanden"
              },
              new StockItem {
                  ArticleNumber = 3, 
                  Name          = "Kaffe",
                  Price         = 45.00,
                  ShelfPosition = "Dryck",
                  Quantity      = 8,
                  Description   = "Gjord på återanvänd kaffesump"
              },
              new StockItem {
                  ArticleNumber = 4, 
                  Name          = "Äpple",
                  Price         = 3.00,
                  ShelfPosition = "Frukt",
                  Quantity      = 250,
                  Description   = "ba ett äpple liksom"
              },
              new StockItem {
                  ArticleNumber = 5, 
                  Name          = "Toast",
                  Price         = 23.50,
                  ShelfPosition = "Bröd och Bakverk",
                  Quantity      = 8,
                  Description   = "ma   cka ..?"
              }
            );
            
        }
    }
}
