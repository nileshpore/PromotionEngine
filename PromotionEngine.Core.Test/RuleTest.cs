using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Core.Rules;
using PromotionEngine.Data.Implementation;
using PromotionEngine.Type;
using System.Linq;

namespace PromotionEngine.Core.Test
{
    [TestClass]
    public class RuleTest
    {
        [TestMethod]
        public void Rule1_Validate_MathcingItem3A_ShouldReturnTrue()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });

            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule1")).Single();


            //Act
            var result = new ConfiguredRule(rule).Validate(shoppingCart);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Rule1_Validate_NotMathcingItem3A_ShouldReturnFalse()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });


            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule1")).Single();


            //Act
            var result = new ConfiguredRule(rule).Validate(shoppingCart);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Rule1_ApplyPromotion_MathcingItem3A_ShouldApplyPromotion()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });

            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule1")).Single();


            //Act
             new ConfiguredRule(rule).ApplyPromotion(shoppingCart);

            //Assert
            Assert.AreEqual(130.0M, shoppingCart.Total);
        }


        [TestMethod]
        public void Rule1_ApplyPromotion_MultipleMathcingItem3A_ShouldApplyPromotion()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "A", Price = 50 } });

            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule1")).Single();


            //Act
            new ConfiguredRule(rule).ApplyPromotion(shoppingCart);

            //Assert
            Assert.AreEqual(260.0M, shoppingCart.Total);
        }

        [TestMethod]
        public void Rule2_Validate_MathcingItem2B_ShouldReturnTrue()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "B", Price = 30 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "B", Price = 30 } });
            
            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule2")).Single();


            //Act
            var result = new ConfiguredRule(rule).Validate(shoppingCart);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Rule2_Validate_NotMathcingItem2B_ShouldReturnFalse()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "B", Price = 30 } });
            


            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule2")).Single();


            //Act
            var result = new ConfiguredRule(rule).Validate(shoppingCart);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Rule2_ApplyPromotion_MathcingItem2B_ShouldApplyPromotion()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "B", Price = 30 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "B", Price = 30 } });

            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule2")).Single();


            //Act
            new ConfiguredRule(rule).ApplyPromotion(shoppingCart);

            //Assert
            Assert.AreEqual(45.0M, shoppingCart.Total);
        }


        [TestMethod]
        public void Rule2_ApplyPromotion_MultipleMathcingItem2B_ShouldApplyPromotion()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "B", Price = 30 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "B", Price = 30 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "B", Price = 30 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "B", Price = 30 } });

            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule2")).Single();


            //Act
            new ConfiguredRule(rule).ApplyPromotion(shoppingCart);

            //Assert
            Assert.AreEqual(90.0M, shoppingCart.Total);
        }

        [TestMethod]
        public void Rule3_Validate_MathcingItemCAndD_ShouldReturnTrue()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "C", Price = 20 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "D", Price = 15 } });

            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule3")).Single();


            //Act
            var result = new ConfiguredRule(rule).Validate(shoppingCart);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Rule3_Validate_NotMathcingItemCAndD_ShouldReturnFalse()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "C", Price = 20 } });



            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule3")).Single();


            //Act
            var result = new ConfiguredRule(rule).Validate(shoppingCart);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Rule3_ApplyPromotion_MathcingItemCAndD_ShouldApplyPromotion()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "C", Price = 20 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "D", Price = 15 } });

            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule3")).Single();


            //Act
            new ConfiguredRule(rule).ApplyPromotion(shoppingCart);

            //Assert
            Assert.AreEqual(30.0M, shoppingCart.Total);
        }


        [TestMethod]
        public void Rule3_ApplyPromotion_MultipleMathcingItemCAndD_ShouldApplyPromotion()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "C", Price = 20 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "D", Price = 15 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "C", Price = 20 } });
            shoppingCart.ShoppingCartItem.Add(new ShoppingCartItem() { PromotioApplied = false, SKU = new SKU() { Name = "D", Price = 15 } });

            var rules = new JsonRuleRepository().GetRules();
            var rule = rules.Where(t => t.RuleCode.Equals("Rule3")).Single();


            //Act
            new ConfiguredRule(rule).ApplyPromotion(shoppingCart);

            //Assert
            Assert.AreEqual(60.0M, shoppingCart.Total);
        }
    }
}
