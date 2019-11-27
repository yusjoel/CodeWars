using CodeWars.Kyu5;
using NUnit.Framework;

namespace CodeWarsTests.Kyu5
{
    [TestFixture]
    public class CaesarCipherTests
    {
        [Test]
        [Description("test")]
        // ReSharper disable once InconsistentNaming
        public void testTest()
        {
            Assert.AreEqual("grfg", CaesarCipher.Rot13("test"),
                string.Format("Input: test, Expected Output: grfg, Actual Output: {0}", CaesarCipher.Rot13("test")));
        }

        [Test]
        [Description("Test")]
        public void TestTest()
        {
            Assert.AreEqual("Grfg", CaesarCipher.Rot13("Test"),
                string.Format("Input: Test, Expected Output: Grfg, Actual Output: {0}", CaesarCipher.Rot13("Test")));
        }
    }
}
