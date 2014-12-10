using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Church.Common;

namespace Church.DataAccess.EntityFramework
{
    /// <summary>
    /// Provides a dependency module that registers all types needed for entity framework storage.
    /// </summary>
    public sealed class EntityFrameworkDependencyModule : IDependencyModule
    {
        /// <summary>
        /// The container name of this dependency module.
        /// </summary>
        public const string Container = "EntityFramework";

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
