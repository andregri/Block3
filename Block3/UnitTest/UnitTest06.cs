using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise06;

namespace UnitTest
{
    [TestClass]
    public class UnitTest06
    {
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
    }
}
