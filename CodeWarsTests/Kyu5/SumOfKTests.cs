using CodeWars.Kyu5;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CodeWarsTests.Kyu5
{
    [TestFixture]
    public class SumOfKTests
    {
        [Test]
        public void ChooseBestSumTest()
        {
            Console.WriteLine("****** Basic Tests");
            var ts = new List<int> { 50, 55, 56, 57, 58 };
            var n = SumOfK.chooseBestSum(163, 3, ts);
            Assert.AreEqual(163, n);

            ts = new List<int> { 50 };
            n = SumOfK.chooseBestSum(163, 3, ts);
            Assert.AreEqual(null, n);

            ts = new List<int> { 91, 74, 73, 85, 73, 81, 87 };
            n = SumOfK.chooseBestSum(230, 3, ts);
            Assert.AreEqual(228, n);
        }
    }
}
