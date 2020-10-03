using PromotionEngine.Type;

namespace PromotionEngine.Core.Rules
{
    public interface IRule
    {
        void ApplyPromotion(ShoppingCart shoppingCart);
        bool Validate(ShoppingCart shoppingCart);
        decimal CalculatedDiscount { get; }
    }
}