using CodeWars.Kyu3;
using NUnit.Framework;

namespace CodeWarsTests.Kyu3
{
    [TestFixture]
    public class BattleshipFieldTests
    {
        [Test]
        public void TestCase()
        {
            var field = new int[10, 10]
            {
                { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
            Assert.IsTrue(BattleshipField.ValidateBattlefield(field));
        }
    }
}
