using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Common
{
    /// <summary>
    /// Represents data with an id.
    /// </summary>
    public interface IHasId
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        string Id { get; }
    }
}
