using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise02;
using System.Numerics;

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

        //test random
        [TestMethod]
        public void RandomTest()
        {
            string num1 = LargeNumber.Random(1000);
            string num2 = LargeNumber.Random(1000);

            Assert.IsFalse(num1 == num2);
        }

        //test extend
        [TestMethod]
        public void ExtendTestGreater()
        {
            string num = "465465";
            int size = 10;

            string newNum = LargeNumber.Extend(num, size);
            string expected = "4654650000";

            Assert.AreEqual(expected, newNum);
        }

        [TestMethod]
        public void ExtendTestSmaller()
        {
            string num = "76434";
            int size = 3;

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

        [TestMethod]
        public void SumTestSize10000()
        {
            string num1 = LargeNumber.Random(10000);
            string num2 = LargeNumber.Random(10000);
            string result = LargeNumber.Sum(num1, num2);

            BigInteger bigNum1 = BigInteger.Parse(Reverse(num1));
            BigInteger bigNum2 = BigInteger.Parse(Reverse(num2));
            BigInteger expected = bigNum1 + bigNum2;

            Assert.AreEqual(expected.ToString(), Reverse(result));
        }

        [TestMethod]
        public void SumTestSize1000()
        {
            string num1 = LargeNumber.Random(1000);
            string num2 = LargeNumber.Random(1000);
            string result = LargeNumber.Sum(num1, num2);

            BigInteger bigNum1 = BigInteger.Parse(Reverse(num1));
            BigInteger bigNum2 = BigInteger.Parse(Reverse(num2));
            BigInteger expected = bigNum1 + bigNum2;

            Assert.AreEqual(expected.ToString(), Reverse(result));
        }
    }
}
