using System;
using System.Collections.Generic;
using System.Reflection;
using Church.Common.Dependencies;

namespace Church.Common
{
    /// <summary>
    /// Represents a manager for dependencies.
    /// </summary>
    public interface IDependencyManager
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

        /// <summary>
        /// Binds the specified type to an implementation.
        /// </summary>
        /// <typeparam name="T">The type to bind to an implementation.</typeparam>
        /// <returns>A binding object.</returns>
        IBindingTo<T> Bind<T>();

        /// <summary>
        /// Loads all specified dependency modules.
        /// </summary>
        /// <param name="dependencyModules">The dependency modules to load.</param>
        void Load(params IDependencyModule[] dependencyModules);

        /// <summary>
        /// Returns a scope, which manages the instances of retrieved objects.
        /// </summary>
        /// <returns>A scope, which manages the instances of retrieved objects.</returns>
        IDependencyScope CreateScope();
    }
}
