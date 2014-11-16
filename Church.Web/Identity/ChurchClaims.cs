using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Church.Web.Identity
{
    /// <summary>
    /// Specifies the custom claims.
    /// </summary>
    public static class ChurchClaims
    {
        /// <summary>
        /// The custom user id claim.
        /// </summary>
        public const string UserId = "UserId";

        /// <summary>
        /// The custom full name claim.
        /// </summary>
        public const string FullName = "FullName";
    }
}