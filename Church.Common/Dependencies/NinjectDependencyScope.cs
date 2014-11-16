using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Activation.Blocks;
using NullGuard;

namespace Church.Common.Dependencies
{
    /// <summary>
    /// Provides a scope for dependencies using NInject.
    /// </summary>
    internal sealed class NinjectDependencyScope : IDependencyScope
    {
        /// <summary>
        /// The activation block that this object wraps.
        /// </summary>
        private readonly IActivationBlock activationBlock;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyScope"/> class.
        /// </summary>
        /// <param name="activationBlock">The Ninject block.</param>
        public NinjectDependencyScope(IActivationBlock activationBlock)
        {
            this.activationBlock = activationBlock;
        }

        /// <summary>
        /// Constructs or retrieves an object with the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to retrieve or create.</typeparam>
        /// <returns>An object with the specified type.</returns>
        public T Get<T>()
        {
            return this.activationBlock.Get<T>();
        }

        /// <summary>
        /// Constructs or retrieves an object with the specified type.
        /// </summary>
        /// <param name="type">The type of object to retrieve or create.</param>
        /// <returns>An object with the specified type.</returns>
        [return: AllowNull]
        public object Get(Type type)
        {
            return this.activationBlock.TryGet(type);
        }

        /// <summary>
        /// Constructs or retrieves all objects with the specified type.
        /// </summary>
        /// <param name="type">The type of object to retrieve or create.</param>
        /// <returns>All objects with the specified type.</returns>
        public IEnumerable<object> GetAll(Type type)
        {
            return this.activationBlock.GetAll(type);
        }
    }
}
