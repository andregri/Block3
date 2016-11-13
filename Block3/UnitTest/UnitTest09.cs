using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise09;

namespace UnitTest
{
    [TestClass]
    public class UnitTest09
    {
        static string path = @"..\..\..\Exercise09\TestPurpose";

        [TestMethod]
        public void CheckingEmailFromInputText()
        {
            Program.ExtractEmails(path + @"\Input.txt", path + @"\Output.txt");
            string[] expected = { "example@gmail.com", "test.user@yahoo.co.uk" };
            string[] output = System.IO.File.ReadAllLines(path + @"\Output.txt");

            CollectionAssert.AreEqual(expected, output);
        }
    }
}
