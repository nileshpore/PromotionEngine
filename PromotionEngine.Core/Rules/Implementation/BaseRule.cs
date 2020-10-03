using PromotionEngine.Data.Contract;
using PromotionEngine.Data.Implementation;
using PromotionEngine.Type;
using System.Collections.Generic;

namespace PromotionEngine.Core.Rules
{
    public abstract class BaseRule
    {
        private readonly ISKURepository sKURepository;
        protected string RuleCode { get; set; }
        public static List<SKU> AvailableSKU { get; set; }
        public BaseRule()
        {
            sKURepository = new JsonSKURepository();
            if (AvailableSKU == null || AvailableSKU.Count == 0)
            {
                AvailableSKU = sKURepository.GetAvailableSKU();
            }
        }
    }
}
