using PromotionEngine.Data.Contract;
using PromotionEngine.Data.Implementation;
using PromotionEngine.Type;
using System;
using System.Linq;
using Tamarack.Pipeline;

namespace PromotionEngine.Core.Pipeline
{
    public class SetInitialPricing : IFilter<ShoppingCart, decimal>
    {
        private readonly ISKURepository sKURepository;
        public SetInitialPricing()
        {
            sKURepository = new JsonSKURepository();

        }
        public decimal Execute(ShoppingCart context, Func<ShoppingCart, decimal> executeNext)
        {
            var skuItems = sKURepository.GetAvailableSKU();
            var priceCollection = (from r in context.ShoppingCartItem
                                   join sku in skuItems on r.SKU.Name equals sku.Name
                                   select new { sku.Price, sku.Name }).Distinct().ToList();
            context.ShoppingCartItem.ForEach(t =>
            {
                t.SKU.Price = priceCollection.Single(p => p.Name.Equals(t.SKU.Name)).Price;
            });

            return executeNext(context);
        }
    }
}
