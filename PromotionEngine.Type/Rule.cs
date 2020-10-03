using System.Collections.Generic;

namespace PromotionEngine.Type
{
    public class Rule
    {
        public int RuleId { get; set; }
        public string RuleCode { get; set; }
        public string Description { get; set; }

        public RuleCondition RuleCondition { get; set; }

        public decimal FinalDiscount { get; set; }
    }
}
