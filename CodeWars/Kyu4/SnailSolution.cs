using System;

namespace CodeWars.Kyu4
{
    /// <summary>
    ///     Snail
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/snail/train/csharp
    /// </remarks>
    public class SnailSolution
    {
        public static int[] Snail(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            // 扯淡的设定, 这里int[][]改成int[,]更好一些
            if (array[0].Length == 0)
                return new int[0];

            int n = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                var row = array[i];
                if (row == null)
                    throw new ArgumentException($"array[{i}] is null");

                if (row.Length != n)
                    throw new ArgumentException($"array[{i}].Length != {n}");
            }

            var result = new int[n * n];
            Solve(array, 0, 0, n, result, 0);
            return result;
        }

        /// <summary>
        ///     从[i, j]开始, 遍历一个边长为n的正方形
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="n"></param>
        /// <param name="result"></param>
        /// <param name="k"></param>
        private static void Solve(int[][] array, int i, int j, int n, int[] result, int k)
        {
            // 偶数正方形的终点
            if (n == 0)
                return;

            // 奇数正方形的终点
            result[k] = array[i][j];
            if (n == 1) return;

            // 第一笔, 向右画n-1
            for (int l = 0; l < n - 1; l++)
            {
                k++;
                j++;
                result[k] = array[i][j];
            }

            // 第二笔, 向下画n-1
            for (int l = 0; l < n - 1; l++)
            {
                k++;
                i++;
                result[k] = array[i][j];
            }

            // 第三笔, 向左画n-1
            for (int l = 0; l < n - 1; l++)
            {
                k++;
                j--;
                result[k] = array[i][j];
            }

            // 第四笔, 向上画n-2
            for (int l = 0; l < n - 2; l++)
            {
                k++;
                i--;
                result[k] = array[i][j];
            }

            // 向右1格, 解里面那个小的n-2的正方形
            k++;
            j++;

            Solve(array, i, j, n - 2, result, k);
        }

        #region Clever

        // 这是最精简的解, 代码有些难懂, 但一旦想明白也还好
        // 向右画n, 向下画n-1, 向左画n-1, 向上画n-2, 向右画n-2
        // 规律是每次y方向画, n就减1, 直到n为0

        public static int[] Snail2(int[][] array)
        {
            int l = array[0].Length;
            var sorted = new int[l * l];
            Snail2(array, -1, 0, 1, 0, l, 0, sorted);
            return sorted;
        }

        public static void Snail2(int[][] array, int x, int y, int dx, int dy, int l, int i, int[] sorted)
        {
            if (l == 0)
                return;

            for (int j = 0; j < l; j++)
            {
                x += dx;
                y += dy;
                sorted[i++] = array[y][x];
            }
            Snail2(array, x, y, -dy, dx, dy == 0 ? l - 1 : l, i, sorted);
        }

        #endregion
    }
}
