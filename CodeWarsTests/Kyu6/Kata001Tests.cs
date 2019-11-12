using CodeWars.Kyu6;
using NUnit.Framework;

namespace CodeWarsTests.Kyu6
{
    [TestFixture]
    public class Kata001001Tests
    {
        [Test]
        public void SplitAndAdd()
        {
            int[] expected = { 5, 10 };
            var input = Kata001.SplitAndAdd(new[] { 1, 2, 3, 4, 5 }, 2);

            Assert.AreEqual(expected, input);

            expected = new[] { 15 };
            input = Kata001.SplitAndAdd(new[] { 1, 2, 3, 4, 5 }, 3);

            Assert.AreEqual(expected, input);

            expected = new[] { 15 };
            input = Kata001.SplitAndAdd(new[] { 15 }, 3);

            Assert.AreEqual(expected, input);

            expected = new[] { 183, 125 };
            input = Kata001.SplitAndAdd(new[] { 32, 45, 43, 23, 54, 23, 54, 34 }, 2);

            Assert.AreEqual(expected, input);

            expected = new[] { 32, 45, 43, 23, 54, 23, 54, 34 };
            input = Kata001.SplitAndAdd(new[] { 32, 45, 43, 23, 54, 23, 54, 34 }, 0);

            Assert.AreEqual(expected, input);

            expected = new[] { 305, 1195 };
            input = Kata001.SplitAndAdd(new[] { 3, 234, 25, 345, 45, 34, 234, 235, 345 }, 3);

            Assert.AreEqual(expected, input);

            expected = new[] { 1040, 7712 };
            input = Kata001.SplitAndAdd(
                new[] { 3, 234, 25, 345, 45, 34, 234, 235, 345, 34, 534, 45, 645, 645, 645, 4656, 45, 3 }, 4);

            Assert.AreEqual(expected, input);

            expected = new[] { 79327 };
            input = Kata001.SplitAndAdd(new[] { 23, 345, 345, 345, 34536, 567, 568, 6, 34536, 54, 7546, 456 }, 20);

            Assert.AreEqual(expected, input);
        }
    }
}
