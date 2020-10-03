using PromotionEngine.Core;
using PromotionEngine.Type;
using System;
using System.Linq;

namespace PromotionEngine
{
    internal class Program
    {
        /// <summary>
        /// Expecing input in correct formation
        /// Required input format is 
        /// <SKU Name>-<Quantity>|<SKU Name>-<Quantity>
        /// Example:
        /// 1-A|1-B|1-C
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            args = new string[1];
            args[0] = "1-A";
            if (args != null && args.Length == 1)
            {
                var totalAmount = new ProcessPromotion().Process(GetShoppingCart(args[0]));
                Console.WriteLine("Total Cart Amount To be Paid: {0}$", totalAmount);                
            }
            else
            {
                Console.WriteLine("Incorrect Argument");
            }
            Console.ReadLine();
        }

        private static ShoppingCart GetShoppingCart(string sku)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            sku.Split('|').ToList().ForEach(r =>
            {
                var name = r.Split('-').Last();
                var quantity = int.Parse(r.Split('-').First());
                for (int i = 0; i < quantity; i++)
                {
                    shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem()
                    {
                        PromotioApplied = false,
                        SKU = new SKU()
                        {
                            Name = name
                        }
                    });
                }
            });
            return shoppingCart;
        }
    }
}
