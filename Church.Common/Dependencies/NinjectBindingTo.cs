using System;
using Ninject.Syntax;

namespace Church.Common.Dependencies
{
    /// <summary>
    /// Provides method to bind a type to an implementation.
    /// </summary>
    /// <typeparam name="T">The type that is being bound.</typeparam>
    internal sealed class NinjectBindingTo<T> : IBindingTo<T>
    {
        /// <summary>
        /// The Ninject syntax.
        /// </summary>
        private readonly IBindingToSyntax<T> bindingToSyntax;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectBindingTo{T}"/> class.
        /// </summary>
        /// <param name="bindingToSyntax">The Ninject syntax.</param>
        public NinjectBindingTo(IBindingToSyntax<T> bindingToSyntax)
        {
            this.bindingToSyntax = bindingToSyntax;
        }

        /// <summary>
        /// Binds a type to the specified implementation.
        /// </summary>
        /// <typeparam name="TImplementation">The implementation type.</typeparam>
        /// <returns>A binding that allows a name and scope to be specified.</returns>
        public IBindingInOrWithName To<TImplementation>() where TImplementation : T
        {
            return new NinjectBindingInOrWithName<TImplementation>(this.bindingToSyntax.To<TImplementation>());
        }

        /// <summary>
        /// Binds a type to the specified delegate.
        /// </summary>
        /// <param name="method">The delegate used to create the object.</param>
        /// <returns>A binding that allows a name and scope to be specified.</returns>
        public IBindingInOrWithName To(Func<T> method)
        {
            return new NinjectBindingInOrWithName<T>(this.bindingToSyntax.ToMethod(context => method()));
        }
    }
}
