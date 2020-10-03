using PromotionEngine.Core.Pipeline;
using PromotionEngine.Core.Rules.Contract;
using PromotionEngine.Type;
using Tamarack.Pipeline;

namespace PromotionEngine.Core
{
    public class ProcessPromotion
    {
        private readonly IRuleBuilder ruleBuilder;
        public ProcessPromotion()
        {
            ruleBuilder = new RuleBuilder();
        }

        /// <summary>
        /// Entry poing for promotion rule execution.
        /// </summary>
        /// <param name="shoppingCart"></param>
        /// <returns></returns>
        public decimal Process(ShoppingCart shoppingCart)
        {
            Pipeline<ShoppingCart, decimal> pipeline = BuildPipeline();
            return pipeline.Execute(shoppingCart);           
        }

        /// <summary>
        /// Build Pipeline method creates pipleline for all available promotions.
        /// This method takes promotion max descount in decending order.
        /// Pipleline has 3 Important steps:
        ///     1. Initialize Price
        ///     2. Apply Promotion
        ///     3. Set default price.
        /// In future we can add further rules/custome promotion, email notification in pipeline stage at required position.
        /// </summary>        
        /// <returns></returns>
        private Pipeline<ShoppingCart, decimal> BuildPipeline()
        {
            var pomotionRules = this.ruleBuilder.GetRules();
            var pipeline = new Pipeline<ShoppingCart, decimal>();
            pipeline.Add(new SetInitialPricing());            
            if (pomotionRules != null && pomotionRules.Count > 0)
            {
                pomotionRules.ForEach(r =>
                {
                    pipeline.Add(new Pipeline.ConfiguredRuleExecutor(r));
                });
            }
            pipeline.Add(new Pipeline.DefaultRuleExecutor());
            return pipeline;
        }
    }
}
