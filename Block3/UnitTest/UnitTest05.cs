using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise05;

namespace UnitTest
{
    [TestClass]
    public class UnitTest05
    {
        [TestMethod]
        public void AreDifferent()
        {
            string firstPhrase = Program.GenerateRandomAdvertisingMessage();
            string secondPhrase = Program.GenerateRandomAdvertisingMessage();

            Assert.AreNotEqual(false, firstPhrase, secondPhrase);
        }

    }
}
