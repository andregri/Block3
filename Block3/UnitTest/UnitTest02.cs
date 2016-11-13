using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise02;

namespace UnitTest
{
    [TestClass]
    public class UnitTest02
    {
        [TestMethod]
        public void ExtendTestGreater()
        {
            string num = "465465";
            long size = 10;

            string newNum = LargeNumber.Extend(num, size);
            string expected = "4654650000";

            Assert.AreEqual(expected, newNum);
        }

        [TestMethod]
        public void ExtendTestSmaller()
        {
            string num = "76434";
            long size = 3;

            string newNum = LargeNumber.Extend(num, size);

            Assert.AreEqual(num, newNum);
        }
    }
}
