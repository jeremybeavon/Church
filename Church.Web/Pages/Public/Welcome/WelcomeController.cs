using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Church.Data.Translations;

namespace Church.Web.Pages.Public.Welcome
{
    /// <summary>
    /// The controller for the welcome page.
    /// </summary>
    public sealed class WelcomeController : ApiController
    {
        /// <summary>
        /// Get the translations.
        /// </summary>
        /// <returns>The translations for the welcome page.</returns>
        public Task<WelcomeTranslations> Translations()
        {
            return null;
        }
    }
}
