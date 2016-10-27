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

            Console.WriteLine("largeNum1[index] = " + largeNum1[index]);
            Console.WriteLine("largeNum2[index] = " + largeNum2[index]);
            Console.WriteLine("largeNum1[index-1] = " + largeNum1[index-1]);
            Console.WriteLine("largeNum2[index-1] = " + largeNum2[index-1]);
            Console.WriteLine("carry = " + carry);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtendNumberTest_Larger()
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

        [TestMethod]
        public void ExtendNumberTest_Smaller()
        {
            int oldSize = 35234;
            int newSize = oldSize - 1000;

            int[] largeNum = Program.GetRandomLargeNumber(oldSize);
            int[] extendedNum = Program.ExtendLargeNumber(largeNum, newSize);

            bool flag = true;

            //check if the number isn't modified
            for (int i = 0; i < oldSize; i++)
            {
                flag = (largeNum[i] == extendedNum[i]);
            }

            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void SumLargeNumbersTest_SameSizes()
        {
            int size = 56814;

            int[] largeNum1 = Program.GetRandomLargeNumber(size);
            int[] largeNum2 = Program.GetRandomLargeNumber(size);

            int[] result = Program.SumLargeNumbers(largeNum1, largeNum2);

            int[] expected = new int[size];
            for (int i = 0; i < size; i++)
            {
                expected[i] = Program.SumDigits(largeNum1, largeNum2, i);
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("i = " + i);
                Console.WriteLine("largeNum1[i] = " + largeNum1[i]);
                Console.WriteLine("largeNum2[i] = " + largeNum2[i]);
                if (i != 0)
                {
                    Console.WriteLine("largeNum1[i-1] = " + largeNum1[i - 1]);
                    Console.WriteLine("largeNum2[i-1] = " + largeNum2[i - 1]);
                }
                
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void SumLargeNumbersTest_DifferentSizes()
        {
            int size1 = 21865;
            int[] largeNum1 = Program.GetRandomLargeNumber(size1);

            int size2 = 64873;
            int[] largeNum2 = Program.GetRandomLargeNumber(size2);

            int[] result = Program.SumLargeNumbers(largeNum1, largeNum2);

            int maxSize = Math.Max(size1, size2);
            int[] expected = new int[maxSize];

            largeNum1 = Program.ExtendLargeNumber(largeNum1, maxSize);
            largeNum2 = Program.ExtendLargeNumber(largeNum2, maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                expected[i] = Program.SumDigits(largeNum1, largeNum2, i);
            }

            //check result
            for (int i = 0; i < maxSize; i++)
            {
                Console.WriteLine("i = " + i);
                Console.WriteLine("largeNum1[i] = " + largeNum1[i]);
                Console.WriteLine("largeNum2[i] = " + largeNum2[i]);
                if (i != 0)
                {
                    Console.WriteLine("largeNum1[i-1] = " + largeNum1[i - 1]);
                    Console.WriteLine("largeNum2[i-1] = " + largeNum2[i - 1]);
                }

                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
