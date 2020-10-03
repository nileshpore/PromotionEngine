using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Common;
using PromotionEngine.Data.Contract;
using PromotionEngine.Data.Implementation;
using System.IO;
using System.Linq;

namespace PromotionEngine.Data.Test
{
    [TestClass]
    public class JsonSKURepositoryTest
    {
        private readonly ISKURepository sKURepository;
        public JsonSKURepositoryTest()
        {
            sKURepository = new JsonSKURepository();
        }

        [TestMethod]
        public void GetAvailableSKU_JsonFileAvailable_ShouldReturnRules()
        {
            //Arrange
            int expectedSKU = 4;

            //Act
            var skuItem = sKURepository.GetAvailableSKU();

            //Assert
            Assert.AreEqual(expectedSKU, skuItem.Count);
        }


        [TestMethod]
        public void GetAvailableSKU_JsonFileAvailable_VerifyRuleData()
        {
            //Arrange
            int expectedSKU = 4;

            //Act
            var skuItem = sKURepository.GetAvailableSKU();


            //Assert
            Assert.AreEqual(expectedSKU, skuItem.Count);
            Assert.AreEqual("A", skuItem.First().Name);
            Assert.AreEqual(50.0M, skuItem.First().Price);

        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetAvailableSKU_JsonFileNotAvailable_ShouldThrowException()
        {
            //Arrange
            var appDirectotry = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(appDirectotry, Constant.AvailableSKUFilePath);
            File.Delete(filePath);


            //Act
            var rules = sKURepository.GetAvailableSKU();

        }
    }
}
