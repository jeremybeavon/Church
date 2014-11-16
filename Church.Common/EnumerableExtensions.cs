using System;
using System.Collections.Generic;
using System.Linq;
using Church.Common.Collections;

namespace Church.Common
{
    /// <summary>
    /// Provides extension methods for enumerable objects.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Converts the enumerable to an IExtendedDictionary using the specified key function.
        /// </summary>
        /// <typeparam name="TKey">The key type of the dictionary.</typeparam>
        /// <typeparam name="TValue">The value type of the dictionary.</typeparam>
        /// <param name="enumerable">The enumerable to convert to a IExtendedDictionary.</param>
        /// <param name="keyFunction">The function that find a key based on the value.</param>
        /// <returns>An IExtendedDictionary.</returns>
        public static IExtendedDictionary<TKey, TValue> ToExtendedDictionary<TKey, TValue>(
            this IEnumerable<TValue> enumerable,
            Func<TValue, TKey> keyFunction)
        {
            return new ExtendedDictionary<TKey, TValue>(
                enumerable.Select(value => new KeyValuePair<TKey, TValue>(keyFunction(value), value)));
        }

        /// <summary>
        /// Returns the first item from the enumerable with the specified search text.
        /// </summary>
        /// <typeparam name="TItem">The type of item to return.</typeparam>
        /// <param name="enumerable">The enumerable to search.</param>
        /// <param name="searchFunc">The function to convert an item to a string.</param>
        /// <param name="searchText">The text to search for.</param>
        /// <returns>The first item that matches the specified search text, or null.</returns>
        public static TItem DoCaseInsensitiveSearch<TItem>(
            this IEnumerable<TItem> enumerable,
            Func<TItem, string> searchFunc,
            string searchText)
        {
            return enumerable.FirstOrDefault(item => string.Equals(searchFunc(item), searchText, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
