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

            Assert.AreNotEqual(firstPhrase, secondPhrase);
        }

        private bool Contain(string str, string[] array)
        {
            bool flag = false;
            foreach (string s in Program.laudatoryPhrases)
            {
                flag = str.Contains(s);
                if (flag == true)
                    break;
            }

            return flag;
        }

        [TestMethod]
        public void IsComplete()
        {
            string sentence = Program.GenerateRandomAdvertisingMessage();

            Assert.IsTrue(Contain(sentence, Program.laudatoryPhrases));
            Assert.IsTrue(Contain(sentence, Program.laudatoryStories));
            Assert.IsTrue(Contain(sentence, Program.authorsNames));
            Assert.IsTrue(Contain(sentence, Program.authorsLastNames));
            Assert.IsTrue(Contain(sentence, Program.cities));
        }
    }
}
