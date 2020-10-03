using System.Collections.Generic;

namespace PromotionEngine.Type
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartItem = new List<ShoppingCartItem>();
        }
        public decimal Total { get; set; }
        public List<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}
