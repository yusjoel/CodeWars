using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kyu5
{
    /// <summary>
    ///     Josephus Survivor
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/555624b601231dc7a400017a/train/csharp
    /// </remarks>
    public class JosephusSurvivor
    {
        public static int JosSurvivor(int n, int k)
        {
            if (n < 1) throw new ArgumentOutOfRangeException(nameof(n));
            if (k < 1) throw new ArgumentOutOfRangeException(nameof(k));

            // 这里的解法是直接模拟, 使用LinkedList模拟一个圈
            // 然后数到k就移除一个节点, 迭代n-1次剩下的节点就是解

            var linkedList = new LinkedList<int>(Enumerable.Range(1, n));
            var iterator = linkedList.First;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < k - 1; j++)
                    iterator = iterator.Next ?? linkedList.First;
                var failed = iterator;
                iterator = iterator.Next ?? linkedList.First;
                linkedList.Remove(failed);
            }

            return iterator.Value;
        }

        public static int SolveBetter(int n, int k)
        {
            var list = new LinkedList<int>(Enumerable.Range(1, n));
            var listNode = list.First;
            while (list.Count > 1)
            {
                for (int i = 1; i <= k; i++)
                    listNode = listNode.Next ?? list.First;

                // 这里相当于上面我写的3句
                list.Remove(listNode.Previous ?? list.Last);
            }
            return list.First.Value;
        }

        public static int Solve(int n, int k)
        {
            // 对于(n, k)的第一轮, 报到k的人出局, 直接将这个人剔除, 从下一个人重新开始编号
            // 那么后面其实相当于(n-1, k), 生存者是同一个人, 区别只是在于编号相差了k
            // 令k=1, 更容易考虑这个问题
            // (1, k) = 0
            // (n, k) = (n-1, k) + k % n
            // 计算的时候按照基0, 返回答案时基1

            int survivor = 0;
            for (int i = 0; i < n - 1; i++)
                survivor = (survivor + k) % (i + 2);

            return survivor + 1;
        }
    }
}
