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
            bool result = Program.GreaterThanNeighbours(new int[] { 1, 3, 2 }, 1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThanNeighbours_ArrayOneElement()
        {
            bool result = Program.GreaterThanNeighbours(new int[] { 1 }, 0);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThanNeighbours_FirstElement()
        {
            bool result = Program.GreaterThanNeighbours(new int[] { 3, 2 }, 0);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThanNeighbours_LastElement()
        {
            bool result = Program.GreaterThanNeighbours(new int[] { 3, 5 }, 1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThanNeighbours_SameElements()
        {
            bool result = Program.GreaterThanNeighbours(new int[] { 5, 5, 5 }, 1);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FirstElementGreaterThanNeighbours()
        {
            int result = Program.FirstElementGreaterThanNeighbours(new int[] { 1, 3, 5, 7, 6 });
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void FirstElementGreaterThanNeighbours_IncreasingSequence()
        {
            int result = Program.FirstElementGreaterThanNeighbours(new int[] { 1, 3, 5, 7, 9 });
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void FirstElementGreaterThanNeighbours_DecreasingSequence()
        {
            int result = Program.FirstElementGreaterThanNeighbours(new int[] { 4, 3, 2, 1, 0 });
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void FirstElementGreaterThanNeighbours_NoOccurrence()
        {
            int result = Program.FirstElementGreaterThanNeighbours(new int[] { 2, 3, 4, 4, 4 });
            Assert.AreEqual(-1, result);
        }
    }
}
