using System;
using System.Collections.Generic;

namespace CodeWars.Kyu3
{
    /// <summary>
    ///     Battleship field validator
    /// </summary>
    /// <remarks>https://www.codewars.com/kata/battleship-field-validator/train/csharp</remarks>
    public class BattleshipField
    {
        /// <summary>
        ///     <para>
        ///         1. There must be single battleship (size of 4 cells), 2 cruisers (size 3), 3 destroyers (size 2) and 4
        ///         submarines (size 1). Any additional ships are not allowed, as well as missing ships.
        ///         2. Each ship must be a straight line, except for submarines, which are just single cell.
        ///         3. The ship cannot overlap or be in contact with any other ship, neither by edge nor by corner.
        ///     </para>
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static bool ValidateBattlefield(int[,] field)
        {
            if (field == null)
                throw new ArgumentNullException(nameof(field));

            if (field.Rank != 2)
                throw new ArgumentException("Rank must be 2", nameof(field));

            int height = field.GetLength(0);
            int width = field.GetLength(1);

            Console.WriteLine($"field width = {width}, height = {height}");

            var shipCellsAndCountMap = new Dictionary<int, int>
            {
                [4] = 1,
                [3] = 2,
                [2] = 3,
                [1] = 4
            };

            var foundCells = new List<int>();

            for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
            {
                // 已经被处理过了, 跳过
                if (foundCells.Contains(i * width + j))
                    continue;

                // 空格子, 跳过
                if (field[i, j] == 0)
                    continue;

                // 四周有格子被占据, 不符合规则, 返回false
                if (CheckCorners(field, width, height, i, j))
                {
                    Console.WriteLine($"Invalid cell[{i}, {j}], corner occupied");
                    return false;
                }

                bool isLeftOccupied = j < width - 1 && field[i, j + 1] > 0;
                bool isDownOccupied = i < height - 1 && field[i + 1, j] > 0;

                // 左侧和下方同时有格子被占据, 不符合规则, 返回false
                if (isLeftOccupied && isDownOccupied)
                {
                    Console.WriteLine($"Invalid cell[{i}, {j}], left & down occupied");
                    return false;
                }

                foundCells.Add(i * width + j);

                int cells = 1;
                if (isLeftOccupied)
                {
                    // 向左侧发展
                    int k = j + 1;
                    while (k < width && field[i, k] > 0)
                    {
                        // 四周有格子被占据, 不符合规则, 返回false
                        if (CheckCorners(field, width, height, i, k))
                        {
                            Console.WriteLine($"Invalid cell[{i}, {k}], corner occupied");
                            return false;
                        }

                        // 上下有格子被占据, 不符合规则, 返回false
                        if (CheckUpDown(field, height, i, k))
                        {
                            Console.WriteLine($"Invalid cell[{i}, {k}], up or down occupied");
                            return false;
                        }

                        foundCells.Add(i * width + k);
                        k++;
                        cells++;
                    }
                }
                else if (isDownOccupied)
                {
                    // 向下方发展
                    int k = i + 1;
                    while (k < height && field[k, j] > 0)
                    {
                        // 四周有格子被占据, 不符合规则, 返回false
                        if (CheckCorners(field, width, height, k, j))
                        {
                            Console.WriteLine($"Invalid cell[{k}, {j}], corner occupied");
                            return false;
                        }

                        // 左右有格子被占据, 不符合规则, 返回false
                        if (CheckLeftRight(field, height, k, j))
                        {
                            Console.WriteLine($"Invalid cell[{k}, {j}], left or right occupied");
                            return false;
                        }

                        foundCells.Add(k * width + j);
                        k++;
                        cells++;
                    }
                }

                // 不支持的格子数, 返回false
                if (cells > 4)
                {
                    Console.WriteLine($"Invalid cell count: {cells}, start at [{i}, {j}]");
                    return false;
                }

                // 过多数量, 返回false
                if (shipCellsAndCountMap[cells] == 0)
                {
                    Console.WriteLine($"Too many {cells}-cells ship, start at [{i}, {j}]");
                    return false;
                }

                Console.WriteLine($"Found {cells}-cells ship, start at [{i}, {j}]");
                shipCellsAndCountMap[cells]--;
            }

            foreach (var pair in shipCellsAndCountMap)
                // 船数量不足
                if (pair.Value > 0)
                {
                    Console.WriteLine($"Not enough {pair.Key}-cells ship: {pair.Value}");
                    return false;
                }

            return true;
        }

        private static bool CheckUpDown(int[,] field, int height, int i, int j)
        {
            bool isOccupied = false;
            // 上
            if (i > 0)
                isOccupied = field[i - 1, j] > 0;
            // 下
            if (i < height - 1)
                isOccupied = isOccupied || field[i + 1, j] > 0;

            return isOccupied;
        }

        private static bool CheckLeftRight(int[,] field, int width, int i, int j)
        {
            bool isOccupied = false;
            // 左
            if (j > 0)
                isOccupied = field[i, j - 1] > 0;
            // 右
            if (j < width - 1)
                isOccupied = isOccupied || field[i, j + 1] > 0;

            return isOccupied;
        }

        private static bool CheckCorners(int[,] field, int width, int height, int i, int j)
        {
            bool isCornerOccupied = false;
            // 左上
            if (j > 0 && i > 0)
                isCornerOccupied = field[i - 1, j - 1] > 0;
            // 左下
            if (j < height - 1 && i > 0)
                isCornerOccupied = isCornerOccupied || field[i - 1, j + 1] > 0;

            // 右上
            if (j > 0 && i < width - 1)
                isCornerOccupied = isCornerOccupied || field[i + 1, j - 1] > 0;
            // 右下
            if (j < height - 1 && i < width - 1)
                isCornerOccupied = isCornerOccupied || field[i + 1, j + 1] > 0;

            return isCornerOccupied;
        }

        // 看到一个优化
        // Console.WriteLine($"Invalid cell[{i}, {j}], corner occupied");
        // return false;
        // 写一个函数Fail(string message)
    }
}
