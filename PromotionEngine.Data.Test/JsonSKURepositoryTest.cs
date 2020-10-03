using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace PromotionEngine.Data.Test
{
    [TestClass]
    public class JsonSKURepositoryTest
    {

        [TestMethod]
        public void GetAvailableSKU_JsonFileAvailable_ShouldReturnRules()
        {
            //Arrange

            //Act

            //Assert
            Assert.AreEqual(true, false);

        }


        [TestMethod]
        public void GetAvailableSKU_JsonFileAvailable_VerifyRuleData()
        {
            //Arrange

            //Act


            //Assert
            Assert.AreEqual(true, false);


        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetAvailableSKU_JsonFileNotAvailable_ShouldThrowException()
        {
            //Arrange
            

            //Act
            

        }
    }
}
