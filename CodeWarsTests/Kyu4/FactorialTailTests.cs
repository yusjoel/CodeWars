using CodeWars.Kyu4;
using NUnit.Framework;

namespace CodeWarsTests.Kyu4
{
    [TestFixture()]
    public class FactorialTailTests
    {
        [Test]
        public void Can_Be_Solved_With_Basic_Computations()
        {
            Assert.AreEqual(2, FactorialTail.zeroes(10, 10));
            Assert.AreEqual(3, FactorialTail.zeroes(16, 16));
        }
    }
}
