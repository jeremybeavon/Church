using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Church.Web.Identity
{
    /// <summary>
    /// Manages sign-in operations for users.
    /// </summary>
    public sealed class ChurchSignInManager : SignInManager<ChurchUser, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChurchSignInManager"/> class.
        /// </summary>
        /// <param name="authenticationManager">The authentication manager.</param>
        public ChurchSignInManager(IAuthenticationManager authenticationManager)
            : base(new ChurchUserManager(), authenticationManager)
        {
        }
    }
}