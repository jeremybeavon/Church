using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Common.Dependencies;

namespace Church.Common
{
    /// <summary>
    /// Specifies a binding.
    /// </summary>
    /// <typeparam name="TFrom">The type being bound.</typeparam>
    /// <typeparam name="TTo">The destination type.</typeparam>
    public sealed class Binding<TFrom, TTo> : IBindingProvider
        where TTo : TFrom
    {
        /// <summary>
        /// Adds a binding to the specified dependency manager.
        /// </summary>
        /// <param name="dependencyManager">The dependency manager to initialize.</param>
        public void Bind(IDependencyManager dependencyManager)
        {
            dependencyManager.Bind<TFrom>().To<TTo>();
        }
    }
}
