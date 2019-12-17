using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kyu7
{
    /// <summary>
    ///     List Filtering
    /// </summary>
    /// <remarks>
    ///     https://www.codewars.com/kata/list-filtering/train/csharp
    /// </remarks>
    public class ListFilterer
    {
        /// <summary>
        ///     My Solution
        /// </summary>
        /// <param name="listOfItems"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
        {
            return listOfItems.OfType<int>();
        }

        /// <summary>
        ///     Clever
        /// </summary>
        /// <param name="listOfItems"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetIntegersFromList2(List<object> listOfItems)
        {
            foreach (var item in listOfItems)
                if (item is int i)
                    yield return i;
        }
    }
}
