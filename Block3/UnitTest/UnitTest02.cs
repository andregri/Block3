﻿using System;
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
    }
}
