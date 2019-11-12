using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kyu6
{
    /// <summary>
    ///     Split and then add both sides of an array together.
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/split-and-then-add-both-sides-of-an-array-together/train/csharp
    /// </remarks>
    public class Kata001
    {
        /// <summary>
        ///     My Solution
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] SplitAndAdd(int[] numbers, int n)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));

            var numberList = new List<int>(numbers);

            int time = 0;
            int length = numbers.Length;
            int skip = 0;

            while (time < n && length > 1)
            {
                int half = length / 2;
                int odd = length % 2;

                for (int i = 0; i < half; i++)
                    numberList[skip + half + i + odd] += numberList[skip + i];

                time++;
                length = half + odd;
                skip += half;
            }

            var range = numberList.GetRange(skip, length);
            return range.ToArray();
        }

        /// <summary>
        ///     一个聪明但是耗费资源的方法, 主要的点在于靠Reverse来进行对齐
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] SplitAndAdd2(int[] numbers, int n)
        {
            if (n == 0)
                return numbers;

            int length = numbers.Length / 2;
            var firstList = numbers.Take(length).Reverse().ToList();
            var secondList = numbers.Skip(length).Reverse().ToList();

            for (int i = 0; i < firstList.Count; i++)
                secondList[i] += firstList[i];

            secondList.Reverse();
            return SplitAndAdd(secondList.ToArray(), n - 1);
        }
    }
}
