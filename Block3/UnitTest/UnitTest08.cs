using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise08;

namespace UnitTest
{
    [TestClass]
    public class UnitTest08
    {
        [TestMethod]
        public void TestEncryptText()
        {
            string text = "Test";
            string chiper = "ab";

            ushort[] expected = {0x35, 0x7, 0x12, 0x16 };
            ushort[] encrypted = Program.EncryptText(text, chiper);

            CollectionAssert.AreEqual(expected, encrypted);
        }
    }
}
