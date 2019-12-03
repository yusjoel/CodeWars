using CodeWars.Kyu4;
using NUnit.Framework;

namespace CodeWarsTests.Kyu4
{
    [TestFixture]
    public class BagelSolverTests
    {
        [Test]
        public void TestBagel()
        {
            var bagel = BagelSolver.Bagel;
            Assert.AreEqual(4, bagel.Value);
        }
    }
}
