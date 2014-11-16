using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Church.Common.Collections
{
    /// <summary>
    /// Provides a default implementation of IExtendedDictionary.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    public sealed class ExtendedDictionary<TKey, TValue> : ConcurrentDictionary<TKey, TValue>,
        IExtendedDictionary<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedDictionary{TKey,TValue}"/> class.
        /// </summary>
        public ExtendedDictionary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedDictionary{TKey,TValue}"/> class
        /// specifying the initial entries.
        /// </summary>
        /// <param name="collection">The initial entries.</param>
        public ExtendedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
            : base(collection)
        {
        }

        /// <summary>
        /// Adds a key/value pair to the dictionary if the key does not already exist.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="valueFactory">The function used to generate a value for the key.</param>
        /// <returns>The value for the key. This will be either the existing value for the key
        /// if the key is already in the dictionary, or the new value for the key as
        /// returned by valueFactory if the key was not in the dictionary.</returns>
        public TValue GetOrAdd(TKey key, Func<TValue> valueFactory)
        {
            return this.GetOrAdd(key, ignoredKey => valueFactory());
        }
    }
}
