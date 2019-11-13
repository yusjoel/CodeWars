using CodeWars.Kyu6;
using NUnit.Framework;

namespace CodeWarsTests.Kyu6
{
    [TestFixture()]
    public class Kata002Tests
    {
        [Test]
        public void Tests()
        {
            Assert.AreEqual(5, Kata002.find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
        }
    }
}
