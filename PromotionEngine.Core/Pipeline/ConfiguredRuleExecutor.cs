using PromotionEngine.Core.Rules;
using PromotionEngine.Type;
using System;
using Tamarack.Pipeline;

namespace PromotionEngine.Core.Pipeline
{
    public class ConfiguredRuleExecutor : IFilter<ShoppingCart, decimal>
    {
        private readonly IRule rule;
        public ConfiguredRuleExecutor(IRule rule)
        {
            this.rule = rule;
        }
        public decimal Execute(ShoppingCart context, Func<ShoppingCart, decimal> executeNext)
        {
            if (rule.Validate(context))
            {
                rule.ApplyPromotion(context);
            }
            return executeNext(context);
        }
    }
}
