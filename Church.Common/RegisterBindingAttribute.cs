using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullGuard;

namespace Church.Common
{
    /// <summary>
    /// Provides an attribute used for registering dependency manager bindings.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class RegisterBindingAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterBindingAttribute"/> class.
        /// </summary>
        /// <param name="binding">The type of the binding object. Usually <see cref="Binding"/>.</param>
        public RegisterBindingAttribute(Type binding)
        {
            this.Binding = binding;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterBindingAttribute"/> class.
        /// </summary>
        /// <param name="binding">The type of the binding object. Usually <see cref="Binding"/>.</param>
        /// <param name="container">The name of the container this binding belongs to.</param>
        public RegisterBindingAttribute(Type binding, string container)
        {
            this.Binding = binding;
            this.Container = container;
        }

        /// <summary>
        /// Gets the binding type. Usually <see cref="Binding"/>.
        /// </summary>
        public Type Binding { get; private set; }

        /// <summary>
        /// Gets the container that is binding belongs to.
        /// </summary>
        [AllowNull]
        public string Container { get; private set; }
    }
}
