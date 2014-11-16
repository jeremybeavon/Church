using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Data;

namespace Church.DataAccess
{
    /// <summary>
    /// Provides data access methods for prayers.
    /// </summary>
    public interface IPrayerDataAccess
    {
        /// <summary>
        /// Adds a new prayer request.
        /// </summary>
        /// <param name="request">The new request.</param>
        /// <returns>A task that represents adding a new prayer request.</returns>
        Task Request(PrayerRequest request);

        /// <summary>
        /// Get the 10 latest prayer request for the specified topic.
        /// </summary>
        /// <param name="topic">The topic to search.</param>
        /// <returns>A task that represents getting the 10 latest prayer request for the specified topic.</returns>
        Task<IList<PrayerRequestItem>> GetLatestPrayerRequests(string topic);
    }
}
