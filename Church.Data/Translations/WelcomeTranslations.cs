using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Common;

namespace Church.Data.Translations
{
    /// <summary>
    /// The welcome translations.
    /// </summary>
    public sealed class WelcomeTranslations : AbstractData
    {
        /// <summary>
        /// Gets or sets the welcome text.
        /// </summary>
        public string Welcome { get; set; }
    }
}
