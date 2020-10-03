using Newtonsoft.Json;
using PromotionEngine.Common;
using PromotionEngine.Data.Contract;
using PromotionEngine.Type;
using System.Collections.Generic;
using System.IO;

namespace PromotionEngine.Data.Implementation
{
    public class JsonSKURepository : ISKURepository
    {
        public List<SKU> GetAvailableSKU()
        {
            var appDirectotry = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(appDirectotry, Constant.AvailableSKUFilePath);
            return JsonConvert.DeserializeObject<List<SKU>>(File.ReadAllText(filePath));
        }
    }
}
