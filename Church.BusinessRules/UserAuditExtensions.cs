using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Data;

namespace Church.BusinessRules
{
    /// <summary>
    /// Provides extension methods for <see cref="IUserAuditManager"/>.
    /// </summary>
    public static class UserAuditExtensions
    {
        /// <summary>
        /// Adds a new user audit.
        /// </summary>
        /// <param name="userAuditManager">The user audit manager.</param>
        /// <param name="auditEvent">The audit event.</param>
        /// <returns>A task that represents adding a new user audit.</returns>
        public static Task AddAuditAsync(this IUserAuditManager userAuditManager, AuditEvent auditEvent)
        {
            UserAudit userAudit = new UserAudit()
            {
                Event = auditEvent
            };
            return userAuditManager.AddAuditAsync(userAudit);
        }
    }
}
