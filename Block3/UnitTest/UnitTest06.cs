using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise06;

namespace UnitTest
{
    [TestClass]
    public class UnitTest06
    {
        static string path = @"..\..\..\Exercise06\";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileParseExceptionTestFilename()
        {
            new FileParseException(null, 14);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilePerseExceptionTestLine()
        {
            new FileParseException("file", -2);
        }

        [TestMethod]
        [ExpectedException(typeof(FileParseException))]
        public void ParseFileTestException()
        {
            string file = path + "wrong.txt";
            Program.ParseFile(file);
        }

        [TestMethod]
        public void ParseFileTest()
        {
            string file = path + "correct.txt";
            int[] numbers = Program.ParseFile(file);
            int[] expected = { 1, 4, 7, 8 };

            CollectionAssert.AreEqual(expected, numbers);
        }
    }
}
