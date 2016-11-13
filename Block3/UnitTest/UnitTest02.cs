using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise02;

namespace UnitTest
{
    [TestClass]
    public class UnitTest02
    {
        private string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        //test extend
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

        //test sum
        [TestMethod]
        public void SumTest1()
        {
            string a = "65468";
            string b = "54687";

            string expected = "120155";
            string result = LargeNumber.Sum(Reverse(a), Reverse(b));

            Assert.AreEqual(expected, Reverse(result));
        }
    }
}
