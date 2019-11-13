using CodeWars.Kyu6;
using NUnit.Framework;
using System;

namespace CodeWarsTests.Kyu6
{
    [TestFixture]
    public class SumPartsTests
    {
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once IdentifierTypo
        private static void dotest(int[] ls, int[] exp)
        {
            var ans = SumParts.PartsSums(ls);
            Assert.AreEqual(exp, ans);
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once IdentifierTypo
        public static void atest0()
        {
            Console.WriteLine("Basic Tests");
            dotest(new int[] { }, new[] { 0 });
            dotest(new[] { 0, 1, 3, 6, 10 }, new[] { 20, 20, 19, 16, 10, 0 });
            dotest(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 21, 20, 18, 15, 11, 6, 0 });
            dotest(new[] { 744125, 935, 407, 454, 430, 90, 144, 6710213, 889, 810, 2579358 },
                new[]
                {
                    10037855, 9293730, 9292795, 9292388, 9291934, 9291504, 9291414, 9291270, 2581057, 2580168, 2579358,
                    0
                });
        }
    }
}
