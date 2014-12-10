using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Common
{
    /// <summary>
    /// Represents a date time.
    /// </summary>
    public interface IDateTime
    {
        /// <summary>
        /// Gets the current time in UTC.
        /// </summary>
        DateTime Now { get; }
    }
}
