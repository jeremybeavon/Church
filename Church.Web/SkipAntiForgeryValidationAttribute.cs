using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Church.Web
{
    /// <summary>
    /// Provides an attribute that determines whether the class or method should skip anti-forgery validation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class SkipAntiForgeryValidationAttribute : Attribute
    {
    }
}