using CodeWars;
using NUnit.Framework;

namespace CodeWarsTests
{
    [TestFixture]
    public class JadenCaseTests
    {
        [Test]
        public void ToJadenCaseTest()
        {
            Assert.AreEqual("How Can Mirrors Be Real If Our Eyes Aren't Real",
                "How can mirrors be real if our eyes aren't real".ToJadenCase(),
                "Strings didn't match.");
        }
    }
}
