using System;
using System.Collections.Generic;

namespace Church.Common
{
    /// <summary>
    /// Represents a scope for dependencies.
    /// </summary>
    public interface IDependencyScope
    {
        /// <summary>
        /// Constructs or retrieves an object with the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to retrieve or create.</typeparam>
        /// <returns>An object with the specified type.</returns>
        T Get<T>();

        /// <summary>
        /// Constructs or retrieves an object with the specified type.
        /// </summary>
        /// <param name="type">The type of object to retrieve or create.</param>
        /// <returns>An object with the specified type.</returns>
        object Get(Type type);

        /// <summary>
        /// Constructs or retrieves all objects with the specified type.
        /// </summary>
        /// <param name="type">The type of object to retrieve or create.</param>
        /// <returns>All objects with the specified type.</returns>
        IEnumerable<object> GetAll(Type type);
    }
}
