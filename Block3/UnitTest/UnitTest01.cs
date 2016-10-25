using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise01;

namespace UnitTest
{
    [TestClass]
    public class UnitTest01
    {
        [TestMethod]
        public void GreaterThanNeighbours()
        {
            bool expected = Program.GreaterThanNeighbours(new int[] { 1, 3, 2 }, 1);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void GreaterThanNeighbours_ArrayOneElement()
        {
            bool expected = Program.GreaterThanNeighbours(new int[] { 1 }, 0);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void GreaterThanNeighbours_FirstElement()
        {
            bool expected = Program.GreaterThanNeighbours(new int[] { 3, 2 }, 0);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void GreaterThanNeighbours_LastElement()
        {
            bool expected = Program.GreaterThanNeighbours(new int[] { 3, 5 }, 1);
            Assert.IsTrue(expected);
        }
    }
}
