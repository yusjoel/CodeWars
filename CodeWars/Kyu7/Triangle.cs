namespace CodeWars.Kyu7
{
    /// <summary>
    ///     Is this a triangle?
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/is-this-a-triangle/train/csharp
    /// </remarks>
    public class Triangle
    {
        public static bool IsTriangle(int a, int b, int c)
        {
            if (a <= 0) return false;
            if (b <= 0) return false;
            if (c <= 0) return false;
            if (a <= c - b) return false;
            if (a <= b - c) return false;
            if (b <= a - c) return false;
            return true;
        }
    }
}
