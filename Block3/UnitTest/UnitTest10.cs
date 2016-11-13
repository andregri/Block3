using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Exercise10;

namespace UnitTest
{
    [TestClass]
    public class UnitTest10
    {
        [TestMethod]
        public void ShortLenghtString()
        {
            string text = "apple banana apple";
            SortedDictionary<string, int> textDict = Program.CountingWords(text);

            Assert.AreEqual(2, textDict["apple"]);
            Assert.AreEqual(1, textDict["banana"]);
        }

        [TestMethod]
        public void DifferentBetweenSingularAndPlural()
        {
            string text = "apple banana strawberry apples banana strawberry bananas apple strawberry";
            SortedDictionary<string, int> textDict = Program.CountingWords(text);

            Assert.AreEqual(2, textDict["apple"]);
            Assert.AreEqual(1, textDict["apples"]);
            Assert.AreEqual(2, textDict["banana"]);
            Assert.AreEqual(1, textDict["bananas"]);
            Assert.AreEqual(3, textDict["strawberry"]);
        }
    }
}
