using PromotionEngine.Type;
using System;
using System.Linq;
using Tamarack.Pipeline;

namespace PromotionEngine.Core.Pipeline
{
    public class DefaultRuleExecutor : IFilter<ShoppingCart, decimal>
    {

        public decimal Execute(ShoppingCart context, Func<ShoppingCart, decimal> executeNext)
        {
            if (context.ShoppingCartItem.Any(t => t.PromotioApplied == false))
            {
                var remainingSKU = (from r in context.ShoppingCartItem
                                    where r.PromotioApplied == false
                                    select r.SKU.Price).Sum();
                context.Total = context.Total + remainingSKU;
            }

            return context.Total;
        }
    }
}
