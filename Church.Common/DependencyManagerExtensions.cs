using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Church.Common.Dependencies;
using NullGuard;

namespace Church.Common
{
    /// <summary>
    /// Provides extensions for <see cref="IDependencyManager"/>.
    /// </summary>
    public static class DependencyManagerExtensions
    {
        /// <summary>
        /// Registers all bindings in the specified assembly by finding all <see cref="RegisterBindingAttribute"/> attributes.
        /// </summary>
        /// <param name="dependencyManager">The dependency manager to be initialized.</param>
        /// <param name="assembly">The assembly that contains bindings.</param>
        public static void BindAssembly(this IDependencyManager dependencyManager, Assembly assembly)
        {
            BindAssembly(dependencyManager, assembly, null);
        }

        /// <summary>
        /// Registers all bindings in the specified assembly by finding all <see cref="RegisterBindingAttribute"/> attributes
        /// that belong to the specified container.
        /// </summary>
        /// <param name="dependencyManager">The dependency manager to be initialized.</param>
        /// <param name="assembly">The assembly that contains bindings.</param>
        /// <param name="container">The binding container to be bound.</param>
        public static void BindAssembly(this IDependencyManager dependencyManager, Assembly assembly, [AllowNull] string container)
        {
            BindAttributes(dependencyManager, GetAttributes(assembly).Where(bind => bind.Container == container));
        }

        /// <summary>
        /// Gets all <see cref="RegisterBindingAttribute"/> attributes from the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly to search.</param>
        /// <returns>All <see cref="RegisterBindingAttribute"/> attributes from the specified assembly.</returns>
        private static IEnumerable<RegisterBindingAttribute> GetAttributes(Assembly assembly)
        {
            return Attribute.GetCustomAttributes(assembly, typeof(RegisterBindingAttribute)).Cast<RegisterBindingAttribute>();
        }

        /// <summary>
        /// Registers all bindings using the <see cref="RegisterBindingAttribute"/> attributes.
        /// </summary>
        /// <param name="dependencyManager">The dependency manager to be initialized.</param>
        /// <param name="attributes">The <see cref="RegisterBindingAttribute"/> attributes.</param>
        private static void BindAttributes(
            IDependencyManager dependencyManager,
            IEnumerable<RegisterBindingAttribute> attributes)
        {
            foreach (RegisterBindingAttribute bind in attributes)
            {
                ((IBindingProvider)Activator.CreateInstance(bind.Binding)).Bind(dependencyManager);
            }
        }
    }
}
