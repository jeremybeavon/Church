using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Common.Internal
{
    /// <summary>
    /// Provides methods for retrieving configuration settings.
    /// </summary>
    public sealed class ConfigurationSettings : IConfigurationSettings
    {
        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="settingName">Name of the setting.</param>
        /// <returns>
        /// The setting with the specified name.
        /// </returns>
        public string GetSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }
    }
}
