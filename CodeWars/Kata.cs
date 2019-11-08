using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public class Kata
    {
        /// <summary>
        ///     Find the next perfect square!
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        /// <remarks>
        ///     https://www.codewars.com/kata/56269eb78ad2e4ced1000013
        /// </remarks>
        public static long FindNextSquare(long num)
        {
            if (num <= 0)
                throw new ArgumentOutOfRangeException(nameof(num));

            // 1 + 3 + 5 + ... + (2n - 1) = n ^ 2
            long k = 1;
            long square = num;
            square -= k;
            while (square > 0)
            {
                k += 2;
                square -= k;
            }

            if (square < 0)
                return -1;

            // k = 2n - 1
            // (n + 1) ^ 2 - n ^ 2 = 2n + 1
            long nextSquare;
            checked
            {
                try
                {
                    nextSquare = num + k + 2;
                }
                catch (OverflowException)
                {
                    nextSquare = -1;
                }
            }
            return nextSquare;
        }

        /// <summary>
        ///     Number of People in the Bus
        /// </summary>
        /// <param name="peopleListInOut"></param>
        /// <returns></returns>
        /// <remarks>
        ///     https://www.codewars.com/kata/number-of-people-in-the-bus/train/csharp
        /// </remarks>
        public static int Number(List<int[]> peopleListInOut)
        {
            return peopleListInOut.Sum(inOutArray => inOutArray[0] - inOutArray[1]);
        }

        /// <summary>
        ///     Find the missing letter
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <remarks>
        ///     https://www.codewars.com/kata/5839edaa6754d6fec10000a2/train/csharp
        /// </remarks>
        public static char FindMissingLetter(char[] array)
        {
            // 本题是寻找缺失的字母, 所以最多只有25个字符
            // 如果改成寻找缺失的数字, 此时应该考虑折半查找

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length < 2)
                throw new ArgumentException("The length of the array will always be at least 2", nameof(array));

            char c = array[0];
            c++;
            for (int i = 1; i < array.Length; i++)
            {
                if (c != array[i])
                    return c;

                c++;
            }

            throw new ArgumentException("no letter missing", nameof(array));
        }

        /// <summary>
        ///     Does my number look big in this?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>
        ///     https://www.codewars.com/kata/5287e858c6b5a9678200083c/train/csharp
        /// </remarks>
        public static bool Narcissistic(int value)
        {
            int exponent = 0;
            int number = value;
            var digits = new List<int>();
            while (number > 0)
            {
                digits.Add(number % 10);
                number = number / 10;
                exponent++;
            }

            int sum = 0;
            foreach (int digit in digits)
            {
                int power = 1;
                for (int i = 0; i < exponent; i++)
                    power *= digit;
                sum += power;
            }

            return sum == value;
        }
    }
}
