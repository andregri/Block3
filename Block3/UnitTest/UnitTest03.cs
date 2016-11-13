using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise03;

namespace UnitTest
{
    [TestClass]
    public class UnitTest03
    {
        static string path = @"..\..\..\Exercise03\TestPurpose";

        [TestMethod]
        public void GetFilesAndDirectory()
        {
            string[] filesAndFolders = Program.TraverseFolder(path);
            string[] expected = {path + @"\Test1\", path + @"\Test1\TestFile1.txt",
                                path + @"\Test2\", path + @"\Test2\TestFile2.txt" };

            CollectionAssert.AreEqual(expected, filesAndFolders);
        }
    }
}
