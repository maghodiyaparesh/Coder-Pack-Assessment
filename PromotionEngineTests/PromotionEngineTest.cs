using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionEngineTests
{
    [TestClass]
    public class PromotionEngineTest
    {
        [TestMethod]
        public void Verify_CalculateCartTotal()
        {
            // Arrange
            PromotionEngineClass pe = new PromotionEngineClass();

            Dictionary<string, int> scenario1 = new Dictionary<string, int>() { { "A", 1 }, { "B", 1 }, { "C", 1 } };
            Dictionary<string, int> scenario2 = new Dictionary<string, int>() { { "A", 5 }, { "B", 5 }, { "C", 1 } };
            Dictionary<string, int> scenario3 = new Dictionary<string, int>() { { "A", 3 }, { "B", 5 }, { "C", 1 }, { "D", 1 } };

            // Act
            var result1 = pe.CalculateCartTotal(scenario1);
            var result2 = pe.CalculateCartTotal(scenario2);
            var result3 = pe.CalculateCartTotal(scenario3);
            var result4 = pe.CalculateCartTotal(null);

            // Assert
            Assert.AreEqual(result1, 100);
            Assert.AreEqual(result2, 370);
            Assert.AreEqual(result3, 280);
            Assert.AreEqual(result4, 0);
        }
    }
}
