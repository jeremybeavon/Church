using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Common
{
    /// <summary>
    /// Provides methods for retrieving configuration settings.
    /// </summary>
    public interface IConfigurationSettings
    {
        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="settingName">Name of the setting.</param>
        /// <returns>The setting with the specified name.</returns>
        string GetSetting(string settingName);
    }
}
