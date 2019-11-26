using System;
using System.Collections.Generic;

namespace CodeWars.Kyu5
{
    /// <summary>
    ///     Can you get the loop ?
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/can-you-get-the-loop/csharp
    /// </remarks>
    public class LoopDetector
    {
        public static int GetLoopSizeClever(Node startNode)
        {
            // 假设链表的非循环部分长度为n, 循环部分长度为m
            // 一个迭代器slow以1次1个节点的速度进行遍历, fast以1次2个节点的速度进行遍历
            // 假设经过l次迭代slow和fast相遇, 说明该链表确实有循环部分
            // 如果m>n, 当slow到达第n个节点时, fast此时距离循环完成还差m-n个节点
            // 所以再迭代m-n次后, slow和fast相遇, 此时m=l
            // 如果m<n, 此时l>n>m, 只能另外计算循环长度
            // fast不动, slow继续遍历, 当slow再次遇到fast, 迭代的次数就是循环长度
            // 第二个操作是包含第一个操作的, 所以并不需要计算l

            if (startNode == null)
                throw new ArgumentNullException(nameof(startNode));

            var slow = startNode;
            var fast = startNode;

            do
            {
                if (fast.next?.next == null)
                    return 0;

                fast = fast.next.next;

                if (slow.next == null)
                    return 0;

                slow = slow.next;
            } while (slow != fast);

            int l = 0;
            do
            {
                slow = slow.next;
                l++;
            } while (slow != fast);

            return l;
        }

        // ReSharper disable once InconsistentNaming
        public static int getLoopSize(Node startNode)
        {
            var map = new Dictionary<Node, int>();

            var node = startNode;
            int i = 0;
            while (node != null)
            {
                if (map.ContainsKey(node)) return i - map[node];

                map[node] = i;
                i++;
                node = node.next;
            }

            return 0;
        }

        public static Node GenerateLinkedNodes(int n, int m)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n));
            if (m < 0)
                throw new ArgumentOutOfRangeException(nameof(m));
            if (n + m <= 0)
                throw new ArgumentException("n + m <= 0");

            Node startNode = null;
            Node previousNode = null;
            Node loopStartNode = null;
            for (int i = 0; i < n + m; i++)
            {
                var node = new Node();
                if (startNode == null)
                    startNode = node;
                if (previousNode != null)
                    previousNode.next = node;
                previousNode = node;

                if (i == n)
                    loopStartNode = node;
            }

            if (previousNode != null)
                previousNode.next = loopStartNode;

            return startNode;
        }

        public class Node
        {
            // ReSharper disable once InconsistentNaming
            public Node next;
        }
    }
}
