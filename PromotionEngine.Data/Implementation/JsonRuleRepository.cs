using Newtonsoft.Json;
using PromotionEngine.Common;
using PromotionEngine.Data.Contract;
using PromotionEngine.Type;
using System.Collections.Generic;
using System.IO;

namespace PromotionEngine.Data.Implementation
{
    public class JsonRuleRepository : IRuleRepository
    {
        public List<Rule> GetRules()
        {
            var appDirectotry = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(appDirectotry, Constant.PromotionRuleFilePath);
            return JsonConvert.DeserializeObject<List<Rule>>(File.ReadAllText(filePath));
        }
    }
}
