using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Church.Web.Identity
{
    /// <summary>
    /// Creates a <see cref="ClaimsIdentity"/> from a <see cref="ChurchUser"/>.
    /// </summary>
    public sealed class ChurchClaimsIdentityFactory : ClaimsIdentityFactory<ChurchUser, Guid>
    {
        /// <summary>
        /// Create a <see cref="ClaimsIdentity"/> from a user.
        /// </summary>
        /// <param name="manager">The user manager.</param>
        /// <param name="user">The user to create the identity based on.</param>
        /// <param name="authenticationType">The authentication type.</param>
        /// <returns>A <see cref="ClaimsIdentity"/> from a user.</returns>
        public async override Task<ClaimsIdentity> CreateAsync(
            UserManager<ChurchUser, Guid> manager,
            ChurchUser user,
            string authenticationType)
        {
            ClaimsIdentity identity = await base.CreateAsync(manager, user, authenticationType);
            identity.AddClaim(new Claim(ChurchClaims.UserId, user.Id.ToString()));
            identity.AddClaim(new Claim(ChurchClaims.FullName, user.User.FullName));
            return identity;
        }
    }
}