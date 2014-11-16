using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using NullGuard;

namespace Church.Common.Dependencies
{
    /// <summary>
    /// Provides a manager for dependencies using NInject.
    /// </summary>
    public sealed class NinjectDependencyManager : IDependencyManager
    {
        /// <summary>
        /// The Ninject kernel.
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyManager"/> class.
        /// </summary>
        public NinjectDependencyManager()
        {
            INinjectSettings settings = new NinjectSettings
            {
                InjectAttribute = typeof(InjectAttribute)
            };
            this.kernel = new StandardKernel(settings);
        }

        /// <summary>
        /// Constructs or retrieves an object with the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to retrieve or create.</typeparam>
        /// <returns>An object with the specified type.</returns>
        public T Get<T>()
        {
            return this.kernel.Get<T>();
        }

        /// <summary>
        /// Constructs or retrieves an object with the specified type.
        /// </summary>
        /// <param name="type">The type of object to retrieve or create.</param>
        /// <returns>An object with the specified type.</returns>
        [return: AllowNull]
        public object Get(Type type)
        {
            return this.kernel.TryGet(type);
        }

        /// <summary>
        /// Constructs or retrieves all objects with the specified type.
        /// </summary>
        /// <param name="type">The type of object to retrieve or create.</param>
        /// <returns>All objects with the specified type.</returns>
        public IEnumerable<object> GetAll(Type type)
        {
            return this.kernel.GetAll(type);
        }

        /// <summary>
        /// Binds the specified type to an implementation.
        /// </summary>
        /// <typeparam name="T">The type to bind to an implementation.</typeparam>
        /// <returns>A binding object.</returns>
        public IBindingTo<T> Bind<T>()
        {
            return new NinjectBindingTo<T>(this.kernel.Bind<T>()); 
        }

        /// <summary>
        /// Loads all specified dependency modules.
        /// </summary>
        /// <param name="dependencyModules">The dependency modules to load.</param>
        public void Load(params IDependencyModule[] dependencyModules)
        {
            this.kernel.Load(dependencyModules.Select(dependencyModule => new NinjectDependencyModule(this, dependencyModule)));
        }

        /// <summary>
        /// Returns a scope, which manages the instances of retrieved objects.
        /// </summary>
        /// <returns>A scope, which manages the instances of retrieved objects.</returns>
        public IDependencyScope CreateScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }
}
