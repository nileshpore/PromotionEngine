using PromotionEngine.Type;
using System.Collections.Generic;

namespace PromotionEngine.Data.Contract
{
    public interface IRuleRepository
    {
        List<Rule> GetRules();
    }
}
