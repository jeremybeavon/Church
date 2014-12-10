using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Data;

namespace Church.BusinessRules
{
    /// <summary>
    /// Provides management methods for user auditing.
    /// </summary>
    public interface IUserAuditManager
    {
        /// <summary>
        /// Adds a new user audit.
        /// </summary>
        /// <param name="audit">The new user audit.</param>
        /// <returns>A task that represents adding a new user audit.</returns>
        Task AddAuditAsync(UserAudit audit);
    }
}
