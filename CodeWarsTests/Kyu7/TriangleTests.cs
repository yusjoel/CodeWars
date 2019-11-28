using CodeWars.Kyu7;
using NUnit.Framework;

namespace CodeWarsTests
{
    [TestFixture]
    public class TriangleTests
    {
        [TestCase(int.MaxValue - 2, 2, int.MaxValue - 1, ExpectedResult = true)]
        [TestCase(int.MaxValue / 2 + 1, int.MaxValue / 2 + 1, int.MaxValue / 2 + 1, ExpectedResult = true)]
        public bool OverflowTest(int a, int b, int c)
        {
            return Triangle.IsTriangle(a, b, c);
        }

        [Test]
        public void IsTriangle_ValidPositiveNumbers_ReturnsTrue()
        {
            Assert.IsTrue(Triangle.IsTriangle(5, 7, 10));
        }
    }
}
