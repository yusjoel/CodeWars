using CodeWars.Kyu5;
using NUnit.Framework;
using System;

namespace CodeWarsTests.Kyu5
{
    [TestFixture()]
    public class JosephusSurvivorTests
    {
        private static void Testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void Test1()
        {
            Console.WriteLine("Basic Tests JosSurvivor");
            Testing(JosephusSurvivor.JosSurvivor(7, 3), 4);
            Testing(JosephusSurvivor.JosSurvivor(11, 19), 10);
            Testing(JosephusSurvivor.JosSurvivor(40, 3), 28);
            Testing(JosephusSurvivor.JosSurvivor(14, 2), 13);
            Testing(JosephusSurvivor.JosSurvivor(100, 1), 100);
            Testing(JosephusSurvivor.JosSurvivor(1, 300), 1);
            Testing(JosephusSurvivor.JosSurvivor(2, 300), 1);
            Testing(JosephusSurvivor.JosSurvivor(5, 300), 1);
            Testing(JosephusSurvivor.JosSurvivor(7, 300), 7);
            Testing(JosephusSurvivor.JosSurvivor(300, 300), 265);
        }
    }
}
