using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Data;

namespace Church.BusinessRules
{
    /// <summary>
    /// Provides the current user.
    /// </summary>
    public interface ICurrentUserProvider
    {
        /// <summary>
        /// Gets the current user.
        /// </summary>
        Guid? CurrentUserId { get; }
    }
}
