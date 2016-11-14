using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Exercise07;

namespace UnitTest
{
    [TestClass]
    public class UnitTest07
    {
        public string path = @"..\..\..\Exercise07\TestPurpose\";
        public string webUrl = "http://www.consulenteweb.it/wp-content/uploads/2015/09/c.png";

        // Remember to delete the image in TestPurpose folder in order to correctly 
        // verify that this test works
        [TestMethod]
        public void CheckingDownloadValidity()
        {
            string fileName = "image_test.png";
            Program.DownloadFile(webUrl, path + fileName);

            bool expected = File.Exists(path + fileName);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DownloadFileTestArgumentNull()
        {
            Program.DownloadFile(null, null);
        }
    }
}
