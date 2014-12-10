using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Church.Data;
using Church.Web.Identity;

namespace Church.Web
{
    /// <summary>
    /// Provides extension methods for <see cref="IIdentity"/>.
    /// </summary>
    public static class IdentityExtensions
    {
        /// <summary>
        /// Converts the specified identity to a <see cref="UserReference"/>.
        /// </summary>
        /// <param name="identity">The identity to convert to a <see cref="UserReference"/>.</param>
        /// <returns>The <see cref="UserReference"/>.</returns>
        public static UserReference AsUserReference(this IIdentity identity)
        {
            ClaimsIdentity claims = identity as ClaimsIdentity;
            if (claims == null)
            {
                throw new ArgumentException("identity must be ClaimsIdentity", "identity");
            }

            return new UserReference()
            {
                Id = GetClaim(claims, ChurchClaims.UserId),
                Name = GetClaim(claims, ChurchClaims.FullName)
            };
        }

        /// <summary>
        /// Gets the claim for the specified identity with the specified name.
        /// </summary>
        /// <param name="identity">The identity to search.</param>
        /// <param name="name">The claim name to find.</param>
        /// <returns>The claim with the specified name.</returns>
        internal static string GetClaim(ClaimsIdentity identity, string name)
        {
            Claim claim = identity.FindFirst(name);
            if (claim == null)
            {
                throw new ClaimNotFoundException(name + " was not found.");
            }

            return claim.Value;
        }
    }
}