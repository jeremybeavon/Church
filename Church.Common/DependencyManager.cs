using Church.Common.Dependencies;

namespace Church.Common
{
    /// <summary>
    /// Provides a manager for dependencies.
    /// </summary>
    public static class DependencyManager
    {
        /// <summary>
        /// The default dependency manager, which uses Ninject.
        /// </summary>
        private static readonly IDependencyManager DefaultDependencyManager = new NinjectDependencyManager();

        /// <summary>
        /// The current overridden dependency manager.
        /// </summary>
        private static IDependencyManager current;

        /// <summary>
        /// Gets or sets the current dependency manager.
        /// </summary>
        public static IDependencyManager Current
        {
            get { return current ?? DefaultDependencyManager; }
            set { current = value; }
        }

        /// <summary>
        /// Constructs or retrieves an object with the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to retrieve or create.</typeparam>
        /// <returns>An object with the specified type.</returns>
        public static T Get<T>()
        {
            return Current.Get<T>();
        }

        /// <summary>
        /// Binds the specified type to an implementation.
        /// </summary>
        /// <typeparam name="T">The type to bind to an implementation.</typeparam>
        /// <returns>A binding object.</returns>
        public static IBindingTo<T> Bind<T>()
        {
            return Current.Bind<T>();
        }

        /// <summary>
        /// Loads all specified dependency modules.
        /// </summary>
        /// <param name="dependencyModules">The dependency modules to load.</param>
        public static void Load(params IDependencyModule[] dependencyModules)
        {
            Current.Load(dependencyModules);
        }
    }
}
