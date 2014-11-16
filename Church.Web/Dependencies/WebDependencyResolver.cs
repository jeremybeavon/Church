using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Church.Common;
using NullGuard;
using IDependencyScope = System.Web.Http.Dependencies.IDependencyScope;

namespace Church.Web.Dependencies
{
    /// <summary>
    /// Provides a dependency injection container.
    /// </summary>
    public class WebDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// Starts a resolution scope.
        /// </summary>
        /// <returns>The dependency scope.</returns>
        public IDependencyScope BeginScope()
        {
            return new WebDependencyScope(DependencyManager.Current.CreateScope());
        }

        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        /// <param name="serviceType">The service to be retrieved.</param>
        /// <returns>The retrieved service.</returns>
        [return: AllowNull]
        public object GetService(Type serviceType)
        {
            return DependencyManager.Current.Get(serviceType);
        }

        /// <summary>
        /// Constructs or retrieves all objects with the specified type.
        /// </summary>
        /// <param name="serviceType">The type of object to retrieve or create.</param>
        /// <returns>All objects with the specified type.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return DependencyManager.Current.GetAll(serviceType);
        }

        /// <summary>
        /// Disposes this object. Empty method.
        /// </summary>
        public void Dispose()
        {
        }
    }
}