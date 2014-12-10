using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Common;
using Church.Data;
using Church.DataAccess;
using Church.DataAccess.EntityFramework;

[assembly: RegisterBinding(typeof(Binding<IUserAuditDataAccess, UserAuditDataAccess>), EntityFrameworkDependencyModule.Container)]

namespace Church.DataAccess.EntityFramework
{
    /// <summary>
    /// Data access for user auditing.
    /// </summary>
    public sealed class UserAuditDataAccess : IUserAuditDataAccess
    {
        /// <summary>
        /// Adds a new user audit.
        /// </summary>
        /// <param name="audit">The new user audit.</param>
        /// <returns>
        /// A task that represents adding a new user audit.
        /// </returns>
        public async Task AddAuditAsync(UserAudit audit)
        {
            using (ChurchContext context = new ChurchContext())
            {
                context.UserAudit.Add(audit);
                await context.SaveChangesAsync();
            }
        }
    }
}
