using System.Collections.Generic;

namespace CodeWars.Kyu4
{
    public class Node
    {
        public Node Left;

        public Node Right;

        public int Value;

        public Node(Node l, Node r, int v)
        {
            Left = l;
            Right = r;
            Value = v;
        }
    }

    /// <summary>
    ///     Sort binary tree by levels
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/sort-binary-tree-by-levels/train/csharp
    /// </remarks>
    public class BinaryTree
    {
        /// <summary>
        ///     My Solution
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static List<int> TreeByLevels(Node node)
        {
            var result = new List<int>();
            var level = new List<Node> { node };
            TreeByLevels(level, result);
            return result;
        }

        private static void TreeByLevels(List<Node> currentLevel, List<int> result)
        {
            foreach (var node in currentLevel)
            {
                if (node == null) continue;

                result.Add(node.Value);
            }

            var nextLevel = new List<Node>();
            foreach (var node in currentLevel)
            {
                if (node == null) continue;

                nextLevel.Add(node.Left);
                nextLevel.Add(node.Right);
            }

            if (nextLevel.Count > 0)
                TreeByLevels(nextLevel, result);
        }

        /// <summary>
        ///     使用队列的解
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static List<int> TreeByLevelsClever(Node node)
        {
            var list = new List<int>();

            var queue = new Queue<Node>();
            if (node != null) queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var n = queue.Dequeue();
                if (n != null)
                {
                    list.Add(n.Value);
                    queue.Enqueue(n.Left);
                    queue.Enqueue(n.Right);
                }
            }

            return list;
        }
    }
}
