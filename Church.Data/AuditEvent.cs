using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Common;

namespace Church.Data
{
    /// <summary>
    /// Represents an audit event.
    /// </summary>
    public enum AuditEvent
    {
        /// <summary>
        /// The login success
        /// </summary>
        LoginSuccess,

        /// <summary>
        /// The login failure
        /// </summary>
        LoginFailure
    }
}
