using PromotionEngine.Common;
using System.Collections.Generic;

namespace PromotionEngine.Type
{
    public class RuleCondition
    {
        public List<string> Name { get; set; }
        public PromotionType PromotionType { get; set; }
        public decimal Discount { get; set; }
    }
}
