using CodeWars;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodeWarsTests
{
    [TestFixture()]
    public class KataTests
    {
        [Test]
        [TestCase(155, ExpectedResult = -1)]
        [TestCase(121, ExpectedResult = 144)]
        [TestCase(625, ExpectedResult = 676)]
        [TestCase(319225, ExpectedResult = 320356)]
        [TestCase(15241383936, ExpectedResult = 15241630849)]
        public static long FixedTest(long num)
        {
            return Kata.FindNextSquare(num);
        }

        [Test]
        public void FirstTest()
        {
            List<int[]> peopleList = new List<int[]>() { new[] { 10, 0 }, new[] { 3, 5 }, new[] { 5, 8 } };
            Assert.AreEqual(5, Kata.Number(peopleList));
        }
        [Test]
        public void SecondTest()
        {
            List<int[]> peopleList = new List<int[]>() { new[] { 3, 0 }, new[] { 9, 1 }, new[] { 4, 10 }, new[] { 12, 2 }, new[] { 6, 1 }, new[] { 7, 10 } };
            Assert.AreEqual(17, Kata.Number(peopleList));
        }
        [Test]
        public void ThirdTest()
        {
            List<int[]> peopleList = new List<int[]>() { new[] { 3, 0 }, new[] { 9, 1 }, new[] { 4, 8 }, new[] { 12, 2 }, new[] { 6, 1 }, new[] { 7, 8 } };
            Assert.AreEqual(21, Kata.Number(peopleList));
        }

        [Test()]
        public void FindMissingLetterTest()
        {
            Assert.AreEqual('e', Kata.FindMissingLetter(new[] { 'a', 'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', Kata.FindMissingLetter(new[] { 'O', 'Q', 'R', 'S' }));
        }


        private static IEnumerable<TestCaseData> NarcissisticTestCases
        {
            get
            {
                yield return new TestCaseData(1)
                    .Returns(true)
                    .SetDescription("1 is narcissistic");
                yield return new TestCaseData(371)
                    .Returns(true)
                    .SetDescription("371 is narcissistic");

            }
        }

        [Test, TestCaseSource(nameof(NarcissisticTestCases))]
        public bool NarcissisticTest(int n) => Kata.Narcissistic(n);
    }
}
