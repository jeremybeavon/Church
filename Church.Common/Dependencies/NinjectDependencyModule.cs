using Ninject.Modules;

namespace Church.Common.Dependencies
{
    /// <summary>
    /// Provides an Ninject dependency module that can register dependencies.
    /// </summary>
    internal sealed class NinjectDependencyModule : NinjectModule
    {
        /// <summary>
        /// The dependency manager.
        /// </summary>
        private readonly IDependencyManager dependencyManager;

        /// <summary>
        /// The dependency module to load.
        /// </summary>
        private readonly IDependencyModule dependencyModule;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyModule"/> class.
        /// </summary>
        /// <param name="dependencyManager">The dependency manager.</param>
        /// <param name="dependencyModule">The dependency module to load.</param>
        public NinjectDependencyModule(IDependencyManager dependencyManager, IDependencyModule dependencyModule)
        {
            this.dependencyManager = dependencyManager;
            this.dependencyModule = dependencyModule;
        }

        /// <summary>
        /// Gets the module's name.
        /// </summary>
        public override string Name
        {
            get { return this.dependencyModule.GetType().FullName; }
        }

        /// <summary>
        /// Loads the module into the Ninject kernel.
        /// </summary>
        public override void Load()
        {
            this.dependencyModule.Load(this.dependencyManager);
        }
    }
}
