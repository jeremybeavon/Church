using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Common.Internal
{
    /// <summary>
    /// Represents a date time.
    /// </summary>
    internal sealed class ChurchDateTime : IDateTime
    {
        /// <summary>
        /// Gets the current time in UTC.
        /// </summary>
        public DateTime Now
        {
            get { return DateTime.UtcNow; }
        }
    }
}
