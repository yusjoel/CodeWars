using CodeWars;
using NUnit.Framework;

namespace CodeWarsTests
{
    [TestFixture()]
    public class SumTests
    {
        Sum s = new Sum();

        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, s.GetSum(0, 1));
            Assert.AreEqual(-1, s.GetSum(0, -1));
        }
    }
}
