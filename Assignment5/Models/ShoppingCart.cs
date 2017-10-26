using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment5.Models
{
    public class ShoppingCart
    {
        List<StockItem> Cart;
        public ShoppingCart()
        {
            Cart = new List<StockItem>();
        }

        public IEnumerable<StockItem> GetAllItemsInCart() {
            return Cart.ToList();
        }



        public void AddToCart(StockItem item){
            if (Cart.FirstOrDefault(_item => _item.ArticleNumber == item.ArticleNumber) == null)
            {
                Cart.Add(new StockItem {
                    ArticleNumber = item.ArticleNumber,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = 1,
                    Description = item.Description,
                    ShelfPosition = item.ShelfPosition}
                    );
            }
            else 
            {
                Cart.FirstOrDefault(_item => _item.ArticleNumber == item.ArticleNumber).Quantity += 1;
            }
        }

    }
}