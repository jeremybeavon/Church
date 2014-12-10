using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Church.BusinessRules;
using Church.Data;

namespace Church.Web.Identity
{
    /// <summary>
    /// Provides the current user.
    /// </summary>
    public class CurrentUserProvider : ICurrentUserProvider
    {
        /// <summary>
        /// Gets the current user.
        /// </summary>
        public Guid? CurrentUserId
        {
            get
            {
                ClaimsIdentity identity = HttpContext.Current.User.Identity as ClaimsIdentity;
                return identity == null ? (Guid?)null : Guid.Parse(IdentityExtensions.GetClaim(identity, ChurchClaims.UserId));
            }
        }
    }
}
