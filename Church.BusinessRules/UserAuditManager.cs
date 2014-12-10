using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.BusinessRules;
using Church.Common;
using Church.Data;
using Church.DataAccess;

[assembly: RegisterBinding(typeof(Binding<IUserAuditManager, UserAuditManager>))]

namespace Church.BusinessRules
{
    /// <summary>
    /// Provides management methods for user auditing.
    /// </summary>
    public sealed class UserAuditManager : IUserAuditManager
    {
        /// <summary>
        /// The user audit data access.
        /// </summary>
        private readonly IUserAuditDataAccess userAuditDataAccess;

        /// <summary>
        /// The current user provider.
        /// </summary>
        private ICurrentUserProvider currentUserProvider;

        /// <summary>
        /// The date time.
        /// </summary>
        private IDateTime dateTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAuditManager"/> class.
        /// </summary>
        /// <param name="userAuditDataAccess">The user audit data access.</param>
        /// <param name="currentUserProvider">The current user provider.</param>
        /// <param name="dateTime">The date time.</param>
        public UserAuditManager(
            IUserAuditDataAccess userAuditDataAccess,
            ICurrentUserProvider currentUserProvider,
            IDateTime dateTime)
        {
            this.userAuditDataAccess = userAuditDataAccess;
            this.currentUserProvider = currentUserProvider;
            this.dateTime = dateTime;
        }

        /// <summary>
        /// Adds a new user audit.
        /// </summary>
        /// <param name="audit">The new user audit.</param>
        /// <returns>
        /// A task that represents adding a new user audit.
        /// </returns>
        public Task AddAuditAsync(UserAudit audit)
        {
            Guid? currentUserId = this.currentUserProvider.CurrentUserId;
            if (currentUserId == null)
            {
                return Task.FromResult(0);
            }

            audit.UserId = currentUserId.Value;
            audit.Time = this.dateTime.Now;
            return this.userAuditDataAccess.AddAuditAsync(audit);
        }
    }
}
