using System.Reflection;
using Church.Common;

namespace Church.DataAccess.RavenDb
{
    /// <summary>
    /// Provides a dependency module that registers all types needed for file system storage.
    /// </summary>
    public sealed class RavenDbDependencyModule : IDependencyModule
    {
        /// <summary>
        /// The container name of this dependency module.
        /// </summary>
        public const string Container = "RavenDb";

        /// <summary>
        /// Registers dependencies.
        /// </summary>
        /// <param name="dependencyManager">The dependency manager.</param>
        public void Load(IDependencyManager dependencyManager)
        {
            dependencyManager.BindAssembly(Assembly.GetExecutingAssembly(), Container);
        }
    }
}
