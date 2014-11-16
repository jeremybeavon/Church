using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.BusinessRules;
using Church.Common;
using Church.Data;
using Church.DataAccess;

[assembly: RegisterBinding(typeof(Binding<IPrayerManager, PrayerManager>))]

namespace Church.BusinessRules
{
    /// <summary>
    /// Provides management methods for prayers.
    /// </summary>
    public sealed class PrayerManager : IPrayerManager
    {
        /// <summary>
        /// The prayer data access.
        /// </summary>
        private readonly IPrayerDataAccess prayerDataAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrayerManager"/> class.
        /// </summary>
        /// <param name="prayerDataAccess">The prayer data access.</param>
        public PrayerManager(IPrayerDataAccess prayerDataAccess)
        {
            this.prayerDataAccess = prayerDataAccess;
        }

        /// <summary>
        /// Adds a new prayer request.
        /// </summary>
        /// <param name="request">The new request.</param>
        /// <returns>A task that represents adding a new prayer request.</returns>
        public Task Request(PrayerRequest request)
        {
            return this.prayerDataAccess.Request(request);
        }

        /// <summary>
        /// Gets the 10 latest prayer request for the specified topic.
        /// </summary>
        /// <param name="topic">The topic to search.</param>
        /// <returns>A task that represents getting the 10 latest prayer request for the specified topic.</returns>
        public Task<IList<PrayerRequestItem>> GetLatestPrayerRequests(string topic)
        {
            return this.prayerDataAccess.GetLatestPrayerRequests(topic);
        }
    }
}
