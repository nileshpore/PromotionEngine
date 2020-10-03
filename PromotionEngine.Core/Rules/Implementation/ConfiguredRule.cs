using PromotionEngine.Type;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Core.Rules
{
    public class ConfiguredRule : BaseRule, IRule
    {
        private readonly Rule rule;
        public decimal CalculatedDiscount { get; } = 0;

        public ConfiguredRule(Rule rule)
        {
            this.rule = rule;
            this.RuleCode = this.rule.RuleCode;
            CalculatedDiscount = GetDiscount(rule);
        }


        #region Public Method
        public void ApplyPromotion(ShoppingCart shoppingCart)
        {
            do
            {
                var matchedSKU = GetMatchedSKU(shoppingCart);
                matchedSKU.ForEach(t => t.PromotioApplied = true);
                shoppingCart.Total = shoppingCart.Total + GetDiscountedTotal(matchedSKU);
            } while (Validate(shoppingCart));

        }

        public bool Validate(ShoppingCart shoppingCart)
        {
            var matchedSKU = GetMatchedSKU(shoppingCart);
            return matchedSKU.Count() == this.rule.RuleCondition.Name.Count();
        }

        #endregion

        #region "Private Method"
        private List<ShoppingCartItem> GetMatchedSKU(ShoppingCart shoppingCart)
        {
            List<ShoppingCartItem> matechedItems = new List<ShoppingCartItem>();
            var ruleSKU = this.rule.RuleCondition.Name.GroupBy(t => t).Select(t => new { Name = t.Key, Quantity = t.Count() }).ToList();
            ruleSKU.ForEach(sku =>
            {
                matechedItems.AddRange(shoppingCart.ShoppingCartItem.Where(t => t.SKU.Name == sku.Name && t.PromotioApplied == false).Take(sku.Quantity).ToList());
            });
            return matechedItems;
        }

        private decimal GetDiscountedTotal(List<ShoppingCartItem> shoppingCart)
        {
            decimal totalAmountAfterDiscount = 0;
            if (this.rule.RuleCondition.PromotionType == Common.PromotionType.FixedRateDiscount)
            {
                totalAmountAfterDiscount = this.rule.RuleCondition.Discount;
            }
            else if (this.rule.RuleCondition.PromotionType == Common.PromotionType.PercentageDiscount)
            {
                var totalSKUAmount = shoppingCart.Sum(t => t.SKU.Price);
                var discount = (totalSKUAmount / 100) * this.rule.RuleCondition.Discount;
                totalAmountAfterDiscount = totalSKUAmount - discount;
            }
            return totalAmountAfterDiscount;
        }

        private decimal GetDiscount(Rule rule)
        {

            var totalSKUPrice = (from r in rule.RuleCondition.Name
                                 join sku in AvailableSKU on r equals sku.Name
                                 select sku.Price).Sum();

            return DiscountCalculator.DiscountCalculatorFactory.CalculateDiscount(rule.RuleCondition.PromotionType, totalSKUPrice, rule.RuleCondition.Discount);
        }

        #endregion
    }
}
