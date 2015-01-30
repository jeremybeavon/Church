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

        /// <summary>
        /// Gets the boolean setting.
        /// </summary>
        /// <param name="settingName">Name of the setting.</param>
        /// <param name="defaultValue">The default value if the setting is not found or not valid.</param>
        /// <returns>The boolean setting.</returns>
        bool GetBooleanSetting(string settingName, bool defaultValue);
    }
}
