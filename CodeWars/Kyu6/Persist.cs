using System;

namespace CodeWars.Kyu6
{
    /// <summary>
    ///     Persistent Bugger.
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/persistent-bugger/train/csharp
    /// </remarks>
    public class Persist
    {
        public static int Persistence(long n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n));

            long i = n;
            long j = 1;
            int times = 0;
            while (i >= 10)
            {
                while (i > 0)
                {
                    j *= i % 10;
                    i /= 10;
                }
                i = j;
                j = 1;
                times++;
            }
            return times;
        }
    }
}
