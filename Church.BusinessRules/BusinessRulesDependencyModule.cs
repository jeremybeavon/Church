using System.Reflection;
using Church.Common;
using Church.DataAccess.EntityFramework;
using Church.DataAccess.RavenDb;

namespace Church.BusinessRules
{
    /// <summary>
    /// Provides a dependency module that registers all business rule dependencies.
    /// </summary>
    public sealed class BusinessRulesDependencyModule : IDependencyModule
    {
        /// <summary>
        /// Registers all business rule dependencies.
        /// </summary>
        /// <param name="dependencyManager">The dependency manager.</param>
        public void Load(IDependencyManager dependencyManager)
        {
            dependencyManager.Load(new RavenDbDependencyModule());
            dependencyManager.Load(new EntityFrameworkDependencyModule());
            dependencyManager.BindAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
