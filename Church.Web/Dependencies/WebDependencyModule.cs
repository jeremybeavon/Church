using System.Web;
using Church.BusinessRules;
using Church.Common;
using Church.Web.Identity;
using Microsoft.Owin;

namespace Church.Web.Dependencies
{
    /// <summary>
    /// Provides a dependency module that registers all web dependencies.
    /// </summary>
    /// <remarks>
    /// This includes the common, data access and business rules dependency modules.
    /// </remarks>
    public sealed class WebDependencyModule : IDependencyModule
    {
        /// <summary>
        /// Registers all types needed for web.
        /// </summary>
        /// <param name="dependencyManager">The dependency manager.</param>
        /// <remarks>
        /// This includes the common, file system and business rules dependency modules.
        /// </remarks>
        public void Load(IDependencyManager dependencyManager)
        {
            dependencyManager.Load(
                new CommonDependencyModule(),
                new BusinessRulesDependencyModule());
            dependencyManager.Bind<ChurchSignInManager>().ToOwinContext();
            dependencyManager.Bind<ICurrentUserProvider>().To<CurrentUserProvider>();
        }
    }
}