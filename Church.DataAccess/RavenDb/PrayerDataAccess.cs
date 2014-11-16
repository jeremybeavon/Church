using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Common;
using Church.Data;
using Church.DataAccess;
using Church.DataAccess.RavenDb;
using Raven.Client;

[assembly: RegisterBinding(typeof(Binding<IPrayerDataAccess, PrayerDataAccess>), RavenDbDependencyModule.Container)]

namespace Church.DataAccess.RavenDb
{
    /// <summary>
    /// Data access for prayers.
    /// </summary>
    public sealed class PrayerDataAccess : AbstractDataAccess, IPrayerDataAccess
    {
        /// <summary>
        /// Adds a new prayer request.
        /// </summary>
        /// <param name="request">The new request.</param>
        /// <returns>A task that represents adding a new prayer request.</returns>
        public Task Request(PrayerRequest request)
        {
            return this.SaveAsync(request);
        }

        /// <summary>
        /// Gets the 10 latest prayer request for the specified topic.
        /// </summary>
        /// <param name="topic">The topic to search.</param>
        /// <returns>A task that represents getting the 10 latest prayer request for the specified topic.</returns>
        public Task<IList<PrayerRequestItem>> GetLatestPrayerRequests(string topic)
        {
            using (IAsyncDocumentSession session = CreateSession())
            {
                return (from request in session.Query<PrayerRequest>()
                        where request.Topic == topic
                        orderby request.RequestDate descending
                        select new PrayerRequestItem()
                        {
                            Id = request.Id,
                            Name = request.Name,
                            RequestedBy = request.RequestedBy,
                            RequestDate = request.RequestDate
                        }).ToListAsync();
            }
        }
    }
}
