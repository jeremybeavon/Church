using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Data
{
    /// <summary>
    /// Represents short details of a prayer request.
    /// </summary>
    public sealed class PrayerRequestItem
    {
        /// <summary>
        /// Gets or sets the id of this prayer request.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of this prayer request.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user that request this prayer.
        /// </summary>
        public UserReference RequestedBy { get; set; }

        /// <summary>
        /// Gets or sets the date this request was created.
        /// </summary>
        public DateTime RequestDate { get; set; }
    }
}
