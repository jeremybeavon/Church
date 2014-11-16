using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Church.Common.Dependencies;
using Microsoft.AspNet.Identity.Owin;

namespace Church.Web.Dependencies
{
    /// <summary>
    /// Provides extension methods of <see cref="IBindingTo{T}"/>.
    /// </summary>
    internal static class BindingToExtensions
    {
        /// <summary>
        /// Binds the specified binding to the Owin context of the current HttpContext.
        /// </summary>
        /// <typeparam name="T">The type being bound.</typeparam>
        /// <param name="binding">The binding to be bound to the Owin context of the current HttpContext.</param>
        public static void ToOwinContext<T>(this IBindingTo<T> binding)
        {
            binding.To(() => new HttpContextWrapper(HttpContext.Current).GetOwinContext().Get<T>());
        }
    }
}