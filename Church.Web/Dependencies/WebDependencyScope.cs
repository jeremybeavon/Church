using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using NullGuard;
using IChurchDependencyScope = Church.Common.IDependencyScope;

namespace Church.Web.Dependencies
{
    /// <summary>
    /// Provides a scope for dependencies.
    /// </summary>
    public class WebDependencyScope : IDependencyScope
    {
        /// <summary>
        /// The scope that this object wraps.
        /// </summary>
        private readonly IChurchDependencyScope scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebDependencyScope"/> class.
        /// </summary>
        /// <param name="scope">The scope that this object wraps.</param>
        public WebDependencyScope(IChurchDependencyScope scope)
        {
            this.scope = scope;
        }
        
        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        /// <param name="serviceType">The service to be retrieved.</param>
        /// <returns>The retrieved service.</returns>
        [return: AllowNull]
        public object GetService(Type serviceType)
        {
            return this.scope.Get(serviceType);
        }

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        /// <param name="serviceType">The collection of services to be retrieved.</param>
        /// <returns>The retrieved collection of services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.scope.GetAll(serviceType);
        }

        /// <summary>
        /// Disposes this object. Empty method.
        /// </summary>
        public void Dispose()
        {
        }
    }
}