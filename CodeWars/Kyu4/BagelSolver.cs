namespace CodeWars.Kyu4
{
    public sealed class Bagel
    {
        public int Value { get; private set; } = 3;
    }

    /// <summary>
    ///     Bagels
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/bagels/train/csharp
    /// </remarks>
    public class BagelSolver
    {
        public static Bagel Bagel
        {
            get
            {
                var bagel = new Bagel();
                var propertyInfo = typeof(Bagel).GetProperty(nameof(Bagel.Value));
                if (propertyInfo != null)
                    propertyInfo.SetValue(bagel, 4);

                return bagel;
            }
        }
    }
}
