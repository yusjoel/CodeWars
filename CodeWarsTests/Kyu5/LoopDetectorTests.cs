using CodeWars.Kyu5;
using NUnit.Framework;

namespace CodeWarsTests.Kyu5
{
    [TestFixture]
    public class LoopDetectorTests
    {
        [TestCase(1, 3)]
        [TestCase(2, 3)]
        [TestCase(3, 3)]
        [TestCase(4, 3)]
        [TestCase(5, 3)]
        [TestCase(6, 3)]
        public void GetLoopSizeTest(int n, int m)
        {
            var startNode = LoopDetector.GenerateLinkedNodes(n, m);
            Assert.AreEqual(m, LoopDetector.GetLoopSizeClever(startNode));
        }

        [Test]
        public void FourNodesWithLoopSize3()
        {
            var n1 = new LoopDetector.Node();
            var n2 = new LoopDetector.Node();
            var n3 = new LoopDetector.Node();
            var n4 = new LoopDetector.Node();
            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n2;
            Assert.AreEqual(3, LoopDetector.getLoopSize(n1));
        }
    }
}
