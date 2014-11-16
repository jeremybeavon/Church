using System;
using NullGuard;

namespace Church.Common
{
    /// <summary>
    /// Base class for all data objects.
    /// </summary>
    public abstract class AbstractData : IHasId
    {
        /// <summary>
        /// Gets or sets the id of this object.
        /// </summary>
        [AllowNull]
        public string Id { get; set; }
    }
}
