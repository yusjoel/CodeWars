using CodeWars.Kyu4;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodeWarsTests.Kyu4
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 },
                BinaryTree.TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2),
                    new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1)));
        }

        [Test]
        public void NullTest()
        {
            Assert.AreEqual(new List<int>(), BinaryTree.TreeByLevels(null));
        }
    }
}
