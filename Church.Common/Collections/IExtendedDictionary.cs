using System;
using System.Collections.Generic;

namespace Church.Common.Collections
{
    /// <summary>
    /// Provides an extended dictionary.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    public interface IExtendedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Adds a key/value pair to the dictionary if the key does not already exist.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="valueFactory">The function used to generate a value for the key.</param>
        /// <returns>The value for the key. This will be either the existing value for the key
        /// if the key is already in the dictionary, or the new value for the key as
        /// returned by valueFactory if the key was not in the dictionary.</returns>
        TValue GetOrAdd(TKey key, Func<TValue> valueFactory);

        /// <summary>
        /// Adds a key/value pair to the dictionary if the key does not already exist.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="valueFactory">The function used to generate a value for the key.</param>
        /// <returns>The value for the key. This will be either the existing value for the key
        /// if the key is already in the dictionary, or the new value for the key as
        /// returned by valueFactory if the key was not in the dictionary.</returns>
        TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory);
    }
}
