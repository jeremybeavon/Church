using System;
using Ninject.Syntax;

namespace Church.Common.Dependencies
{
    /// <summary>
    /// Provides methods to specify the scope or name of a binding.
    /// </summary>
    /// <typeparam name="T">The type that is being bound.</typeparam>
    internal sealed class NinjectBindingInOrWithName<T> : IBindingInOrWithName
    {
        /// <summary>
        /// The Ninject syntax.
        /// </summary>
        private readonly IBindingWhenInNamedWithOrOnSyntax<T> syntax;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectBindingInOrWithName{T}"/> class.
        /// </summary>
        /// <param name="syntax">The Ninject syntax.</param>
        public NinjectBindingInOrWithName(IBindingWhenInNamedWithOrOnSyntax<T> syntax)
        {
            this.syntax = syntax;
        }

        /// <summary>
        /// Specifies that a binding type is only created once.
        /// </summary>
        public void InSingletonScope()
        {
            this.syntax.InSingletonScope();
        }

        /// <summary>
        /// Specifies that a binding type is created every time it is requested.
        /// </summary>
        public void InTransientScope()
        {
            this.syntax.InTransientScope();
        }

        /// <summary>
        /// Specifies that a binding type has the specified name.
        /// </summary>
        /// <param name="name">The name to assign to this binding.</param>
        /// <returns>A binding that allows a scope to be specified.</returns>
        public IBindingIn WithName(string name)
        {
            this.syntax.Named(name);
            return this;
        }

        /// <summary>
        /// Specifies that a binding type has the specified name.
        /// </summary>
        /// <param name="name">The name to assign to this binding.</param>
        /// <returns>A binding that allows a scope to be specified.</returns>
        public IBindingIn WithName(Enum name)
        {
            return this.WithName(name.ToString());
        }
    }
}
