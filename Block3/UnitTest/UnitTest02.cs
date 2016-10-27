using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise02;

namespace UnitTest
{
    [TestClass]
    public class UnitTest02
    {
        [TestMethod]
        public void GetRandomLargeNumberTest_DifferentFromZero()
        {
            long size = 12546;
            int[] largeNumber = Program.GetRandomLargeNumber(size);

            int digitSum = 0;

            for (int i = 0; i < size; i++)
            {
                digitSum += largeNumber[i];
            }

            bool result = (digitSum > 0);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetCarryTest_NoCarry()
        {
            int size = 56814;
            int index = 555;

            int[] largeNum1 = Program.GetRandomLargeNumber(size);
            largeNum1[index] = 4;

            int[] largeNum2 = Program.GetRandomLargeNumber(size);
            largeNum2[index] = 3;

            int carry = Program.GetCarry(largeNum1, largeNum2, index);

            Assert.AreEqual(0, carry);
        }

        [TestMethod]
        public void GetCarryTest_CarryZero()
        {
            int size = 56814;
            int index = 555;

            int[] largeNum1 = Program.GetRandomLargeNumber(size);
            largeNum1[index] = 14;

            int[] largeNum2 = Program.GetRandomLargeNumber(size);
            largeNum2[index] = 9;

            int carry = Program.GetCarry(largeNum1, largeNum2, index);

            Assert.AreEqual(2, carry);
        }

        [TestMethod]
        public void GetCarryTest_FirstDigitsCarryZero()
        {
            int size = 56814;
            int index = 0;

            int[] largeNum1 = Program.GetRandomLargeNumber(size);
            largeNum1[index] = 4;

            int[] largeNum2 = Program.GetRandomLargeNumber(size);
            largeNum2[index] = 3;

            int carry = Program.GetCarry(largeNum1, largeNum2, index);

            Assert.AreEqual(0, carry);
        }

        [TestMethod]
        public void SumDigitsTest_NoCarry()
        {
            int size = 56814;
            int index = 0;

            int[] largeNum1 = Program.GetRandomLargeNumber(size);
            int[] largeNum2 = Program.GetRandomLargeNumber(size);
            
            int result = Program.SumDigits(largeNum1, largeNum2, index);
            int expected = (largeNum1[index] + largeNum2[index]) % 10;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SumDigitsTest_Carry()
        {
            int size = 56814;
            int index = 4587;

            int[] largeNum1 = Program.GetRandomLargeNumber(size);
            int[] largeNum2 = Program.GetRandomLargeNumber(size);

            int result = Program.SumDigits(largeNum1, largeNum2, index);

            int carry = Program.GetCarry(largeNum1, largeNum2, index - 1);
            int expected = ((largeNum1[index] + largeNum2[index]) % 10 + carry) % 10;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtendNumberTest()
        {
            int oldSize = 35234;
            int newSize = oldSize + 1000;

            int[] largeNum = Program.GetRandomLargeNumber(oldSize);
            int[] extendedNum = Program.ExtendLargeNumber(largeNum, newSize);

            bool flag = true;

            for (int i = 0; i < oldSize; i++)
            {
                flag = (largeNum[i] == extendedNum[i]);
            }

            for (int i = oldSize; i < newSize; i++)
            {
                flag = (extendedNum[i] == 0);
            }

            Assert.IsTrue(flag);
        }
    }
}
