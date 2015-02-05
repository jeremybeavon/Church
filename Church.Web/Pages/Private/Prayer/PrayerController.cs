using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Church.BusinessRules;
using Church.Data;

namespace Church.Web.Pages.Private.Prayer
{
    /// <summary>
    /// The controller for the prayers.
    /// </summary>
    [Authorize]
    public class PrayerController : ApiController
    {
        /// <summary>
        /// The prayer manager.
        /// </summary>
        private readonly IPrayerManager prayerManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrayerController"/> class.
        /// </summary>
        /// <param name="prayerManager">The prayer manager.</param>
        public PrayerController(IPrayerManager prayerManager)
        {
            this.prayerManager = prayerManager;
        }

        /// <summary>
        /// Adds a new prayer request.
        /// </summary>
        /// <param name="request">The new request.</param>
        /// <returns>A task that represents adding a new prayer request.</returns>
        [HttpPost]
        [Route("prayer/request")]
        public Task AddRequest(PrayerRequest request)
        {
            request.Id = request.Topic + "/";
            request.RequestDate = DateTime.UtcNow;
            request.RequestedBy = User.Identity.AsUserReference();
            return this.prayerManager.Request(request);
        }

        /// <summary>
        /// Gets the 10 latest prayer request for the specified topic.
        /// </summary>
        /// <param name="topic">The topic to search.</param>
        /// <returns>A task that represents getting the 10 latest prayer request for the specified topic.</returns>
        [HttpGet]
        [Route("prayer/needs/{topic}")]
        public Task<IList<PrayerRequestItem>> GetLatestPrayerRequests(string topic)
        {
            return this.prayerManager.GetLatestPrayerRequests(topic);
        }

        ////public Task<>
    }
}
