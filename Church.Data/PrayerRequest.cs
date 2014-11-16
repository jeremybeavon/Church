using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Common;

namespace Church.Data
{
    /// <summary>
    /// Represents a prayer request.
    /// </summary>
    public sealed class PrayerRequest : AbstractData
    {
        /// <summary>
        /// Gets or sets the topic of the request.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// Gets or sets name of the request.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets text of the request.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets url of the request.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the user that requested this prayer.
        /// </summary>
        public UserReference RequestedBy { get; set; }

        /// <summary>
        /// Gets or sets the date this request was created.
        /// </summary>
        public DateTime RequestDate { get; set; }
    }
}
