using System;

namespace Church.Common.Dependencies
{
    /// <summary>
    /// Provides method to bind a type to an implementation.
    /// </summary>
    /// <typeparam name="T">The type that is being bound.</typeparam>
    public interface IBindingTo<T>
    {
        /// <summary>
        /// Binds a type to the specified implementation.
        /// </summary>
        /// <typeparam name="TImplementation">The implementation type.</typeparam>
        /// <returns>A binding that allows a name and scope to be specified.</returns>
        IBindingInOrWithName To<TImplementation>()
            where TImplementation : T;

        /// <summary>
        /// Binds a type to the specified delegate.
        /// </summary>
        /// <param name="method">The delegate used to create the object.</param>
        /// <returns>A binding that allows a name and scope to be specified.</returns>
        IBindingInOrWithName To(Func<T> method);
    }
}
