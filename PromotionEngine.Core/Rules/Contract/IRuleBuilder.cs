using System.Collections.Generic;

namespace PromotionEngine.Core.Rules.Contract
{
    public interface IRuleBuilder
    {
        List<IRule> GetRules();
    }
}
