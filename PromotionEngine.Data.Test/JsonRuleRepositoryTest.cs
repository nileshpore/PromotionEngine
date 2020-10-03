using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PromotionEngine.Data.Test
{
    [TestClass]
    public class JsonRuleRepositoryTest
    {
        
        [TestMethod]
        public void GetRules_JsonFileAvailable_ShouldReturnRules()
        {
            //Arrange
           
            
            //Act
           

            //Assert
            Assert.AreEqual(true, false);
        }


        [TestMethod]
        public void GetRule_JsonFileAvailable_VerifyRuleData()
        {
            //Arrange


            //Act



            //Assert
            Assert.AreEqual(true, false);

        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetRules_JsonFileNotAvailable_ShouldThrowException()
        {
            //Arrange
            


            //Act
            

        }
    }
}
