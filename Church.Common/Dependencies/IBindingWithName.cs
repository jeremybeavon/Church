using System;

namespace Church.Common.Dependencies
{
    /// <summary>
    /// Provides methods to specify the name of a binding.
    /// </summary>
    public interface IBindingWithName
    {
        /// <summary>
        /// Specifies that a binding type has the specified name.
        /// </summary>
        /// <param name="name">The name to assign to this binding.</param>
        /// <returns>A binding that allows a scope to be specified.</returns>
        IBindingIn WithName(string name);

        /// <summary>
        /// Specifies that a binding type has the specified name.
        /// </summary>
        /// <param name="name">The name to assign to this binding.</param>
        /// <returns>A binding that allows a scope to be specified.</returns>
        IBindingIn WithName(Enum name);
    }
}
