using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Common;
using PromotionEngine.Data.Contract;
using PromotionEngine.Data.Implementation;

namespace PromotionEngine.Data.Test
{
    [TestClass]
    public class JsonRuleRepositoryTest
    {
        private readonly IRuleRepository ruleRepository;
        public JsonRuleRepositoryTest()
        {
            ruleRepository = new JsonRuleRepository();
        }
        [TestMethod]
        public void GetRules_JsonFileAvailable_ShouldReturnRules()
        {
            //Arrange
            int expectedRules = 2;
            
            //Act
            var rules = ruleRepository.GetRules();

            //Assert
            Assert.AreEqual(expectedRules, rules.Count);
        }


        [TestMethod]
        public void GetRule_JsonFileAvailable_VerifyRuleData()
        {
            //Arrange
            int ruleOneConditions = 3;

            //Act
            var rules = ruleRepository.GetRules();


            //Assert
            Assert.AreEqual(ruleOneConditions, rules.First().RuleCondition.Name.Count);
            Assert.AreEqual(1, rules.First().RuleId);
            Assert.AreEqual("Rule1", rules.First().RuleCode);

        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetRules_JsonFileNotAvailable_ShouldThrowException()
        {
            //Arrange
            var appDirectotry = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(appDirectotry,Constant.PromotionRuleFilePath);
            File.Delete(filePath);


            //Act
            var rules = ruleRepository.GetRules();
        }
    }
}
