using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Church.Web
{
    /// <summary>
    /// Provides constants used for anti-forgery tokens.
    /// </summary>
    internal static class AntiForgeryHelper
    {
        /// <summary>
        /// The cookie name that contains the anti-forgery token.
        /// </summary>
        public const string CookieName = "antiForgeryToken";

        /// <summary>
        /// The HTTP header name that contains the anti-forgery token.
        /// </summary>
        public const string HeaderName = "X-RequestValidationToken";
    }
}