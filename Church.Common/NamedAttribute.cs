using System;
using NinjectNamedAttribute = Ninject.NamedAttribute;

namespace Church.Common
{
    /// <summary>
    /// Indicates that the decorated member should only be injected using binding(s)
    /// registered with the specified name.
    /// </summary>
    public sealed class NamedAttribute : NinjectNamedAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NamedAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the binding(s) to use.</param>
        public NamedAttribute(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the binding(s) to use.</param>
        public NamedAttribute(Enum name)
            : base(name.ToString())
        {
        }
    }
}
