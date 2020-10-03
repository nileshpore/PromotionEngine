using PromotionEngine.Common;

namespace PromotionEngine.Core.DiscountCalculator
{
    public static class DiscountCalculatorFactory
    {
        public static decimal CalculateDiscount(PromotionType promotionType, decimal totalSKUAmount, decimal ruleAmount)
        {
            decimal percentageDiscount = 0;
            switch (promotionType)
            {
                case PromotionType.FixedRateDiscount:
                    percentageDiscount = totalSKUAmount == 0 ? 0 : 100.00M - ((ruleAmount / totalSKUAmount) * 100);
                    break;
                case PromotionType.PercentageDiscount:
                    percentageDiscount = ruleAmount;
                    break;
                default:
                    percentageDiscount = 0;
                    break;
            }
            return percentageDiscount;
        }
    }
}
