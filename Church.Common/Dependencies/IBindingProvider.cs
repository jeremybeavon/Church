using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Common.Dependencies
{
    /// <summary>
    /// Represents an object that provides bindings to a dependency manager.
    /// </summary>
    public interface IBindingProvider
    {
        /// <summary>
        /// When implemented, adds bindings to the specified dependency manager.
        /// </summary>
        /// <param name="dependencyManager">The dependency manager to initialize.</param>
        void Bind(IDependencyManager dependencyManager);
    }
}
