using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise02;

namespace UnitTest
{
    [TestClass]
    public class UnitTest02
    {
        [TestMethod]
        public void InitLargeNumber_DifferentFromZero()
        {
            long length = 12546;
            int[] largeNumber = Program.InitLargeNumber(length);

            int digitSum = 0;

            for (int i = 0; i < length; i++)
            {
                digitSum += largeNumber[i];
            }

            bool result = (digitSum > 0);

            Assert.IsTrue(result);
        }
    }
}
