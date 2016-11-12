using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise02;

namespace UnitTest
{
    [TestClass]
    public class UnitTest02
    {
        //test random numbers
        [TestMethod]
        public void GetRandomLargeNumberTestDifferentFromZero()
        {
            long size = 12546;
            int[] largeNumber = LargeNumber.GetRandom(size);

            int digitSum = 0;

            for (int i = 0; i < size; i++)
            {
                digitSum += largeNumber[i];
            }

            bool result = (digitSum > 0);

            Assert.IsTrue(result);
        }

        //test carry
        [TestMethod]
        public void GetCarryTestNoCarry()
        {
            int size = 56814;
            int index = 555;

            int[] largeNum1 = LargeNumber.GetRandom(size);
            largeNum1[index] = 4;

            int[] largeNum2 = LargeNumber.GetRandom(size);
            largeNum2[index] = 3;

            int carry = LargeNumber.GetCarry(largeNum1, largeNum2, index);

            Assert.AreEqual(0, carry);
        }

        [TestMethod]
        public void GetCarryTestCarry2()
        {
            int size = 56814;
            int index = 555;

            int[] largeNum1 = LargeNumber.GetRandom(size);
            largeNum1[index] = 14;

            int[] largeNum2 = LargeNumber.GetRandom(size);
            largeNum2[index] = 9;

            int carry = LargeNumber.GetCarry(largeNum1, largeNum2, index);

            Assert.AreEqual(2, carry);
        }

        [TestMethod]
        public void GetCarryTestFirstDigitsCarry0()
        {
            int size = 56814;
            int index = 0;

            int[] largeNum1 = LargeNumber.GetRandom(size);
            largeNum1[index] = 4;

            int[] largeNum2 = LargeNumber.GetRandom(size);
            largeNum2[index] = 3;

            int carry = LargeNumber.GetCarry(largeNum1, largeNum2, index);

            Assert.AreEqual(0, carry);
        }

        //test sum digits
        [TestMethod]
        public void SumDigitsTestFirstDigitsNoCarry()
        {
            int size = 56814;
            int index = 0;

            int[] largeNum1 = LargeNumber.GetRandom(size);
            int[] largeNum2 = LargeNumber.GetRandom(size);

            int result = LargeNumber.SumDigits(largeNum1, largeNum2, index);
            int expected = (largeNum1[index] + largeNum2[index]) % 10;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SumDigitsTestCarry()
        {
            int size = 56814;
            int index = 4587;

            int[] largeNum1 = LargeNumber.GetRandom(size);
            int[] largeNum2 = LargeNumber.GetRandom(size);

            int result = LargeNumber.SumDigits(largeNum1, largeNum2, index);

            int carry = LargeNumber.GetCarry(largeNum1, largeNum2, index - 1);
            int expected = ((largeNum1[index] + largeNum2[index]) % 10 + carry) % 10;

            Console.WriteLine("largeNum1[index] = " + largeNum1[index]);
            Console.WriteLine("largeNum2[index] = " + largeNum2[index]);
            Console.WriteLine("largeNum1[index-1] = " + largeNum1[index-1]);
            Console.WriteLine("largeNum2[index-1] = " + largeNum2[index-1]);
            Console.WriteLine("carry = " + carry);

            Assert.AreEqual(expected, result);
        }

        //test extend
        [TestMethod]
        public void ExtendNumberTestLarger()
        {
            int oldSize = 35234;
            int newSize = oldSize + 1000;

            int[] largeNum = LargeNumber.GetRandom(oldSize);
            int[] extendedNum = LargeNumber.Extend(largeNum, newSize);

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

        [TestMethod]
        public void ExtendNumberTestSmaller()
        {
            int oldSize = 35234;
            int newSize = oldSize - 1000;

            int[] largeNum = LargeNumber.GetRandom(oldSize);
            int[] extendedNum = LargeNumber.Extend(largeNum, newSize);

            //check if the number isn't modified
            CollectionAssert.AreEqual(largeNum, extendedNum);
        }

        //test sum
        [TestMethod]
        public void SumLargeNumbersTestSameSizes()
        {
            int size = 56814;

            int[] largeNum1 = LargeNumber.GetRandom(size);
            int[] largeNum2 = LargeNumber.GetRandom(size);

            int[] result = LargeNumber.Sum(largeNum1, largeNum2);

            int[] expected = new int[size];
            for (int i = 0; i < size; i++)
            {
                expected[i] = LargeNumber.SumDigits(largeNum1, largeNum2, i);
            }

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SumLargeNumbersTestDifferentSizes()
        {
            int size1 = 21865;
            int[] largeNum1 = LargeNumber.GetRandom(size1);

            int size2 = 64873;
            int[] largeNum2 = LargeNumber.GetRandom(size2);

            int[] result = LargeNumber.Sum(largeNum1, largeNum2);

            int maxSize = Math.Max(size1, size2);
            int[] expected = new int[maxSize];

            largeNum1 = LargeNumber.Extend(largeNum1, maxSize);
            largeNum2 = LargeNumber.Extend(largeNum2, maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                expected[i] = LargeNumber.SumDigits(largeNum1, largeNum2, i);
            }

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
