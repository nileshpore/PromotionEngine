using PromotionEngine.Core.Rules;
using PromotionEngine.Core.Rules.Contract;
using PromotionEngine.Data.Contract;
using PromotionEngine.Data.Implementation;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Core
{
    public class RuleBuilder : IRuleBuilder
    {
        private readonly IRuleRepository ruleRepository;
        public RuleBuilder()
        {
            ruleRepository = new JsonRuleRepository();
        }

        public List<IRule> GetRules()
        {
            List<IRule> rules = new List<IRule>();
            var rueList = ruleRepository.GetRules();
            rueList.ForEach(r =>
            {
                rules.Add(new ConfiguredRule(r));
            });

            return rules.OrderByDescending(t => t.CalculatedDiscount).ToList();
        }
    }
}
