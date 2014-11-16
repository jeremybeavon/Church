using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Church.Common;
using Microsoft.AspNet.Identity;

namespace Church.Web.Identity
{
    /// <summary>
    /// Manages user operations, such as log-in.
    /// </summary>
    public sealed class ChurchUserManager : UserManager<ChurchUser, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChurchUserManager"/> class.
        /// </summary>
        public ChurchUserManager()
            : base(DependencyManager.Get<ChurchUserStore>())
        {
            this.ClaimsIdentityFactory = new ChurchClaimsIdentityFactory();
        }
    }
}