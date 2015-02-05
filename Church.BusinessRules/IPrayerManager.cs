using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Data;

namespace Church.BusinessRules
{
    /// <summary>
    /// Provides management methods for prayers.
    /// </summary>
    public interface IPrayerManager
    {
        /// <summary>
        /// Adds a new prayer request.
        /// </summary>
        /// <param name="request">The new request.</param>
        /// <returns>A task that represents adding a new prayer request.</returns>
        Task Request(PrayerRequest request);

        /// <summary>
        /// Gets the 10 latest prayer request for the specified topic.
        /// </summary>
        /// <param name="topic">The topic to search.</param>
        /// <returns>A task that represents getting the 10 latest prayer request for the specified topic.</returns>
        Task<IList<PrayerRequestItem>> GetLatestPrayerRequests(string topic);

        /// <summary>
        /// Gets the prayer request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The prayer request.</returns>
        Task<PrayerRequest> GetPrayerRequest(string id);
    }
}
