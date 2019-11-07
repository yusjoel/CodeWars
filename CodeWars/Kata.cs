using System;

namespace CodeWars
{
    public class Kata
    {
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
    }
}
