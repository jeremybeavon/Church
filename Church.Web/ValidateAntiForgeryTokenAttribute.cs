using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Church.Web
{
    /// <summary>
    /// Provides a filter that validates the anti-forgery token.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// Executes the authorization filter to synchronize.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <param name="cancellationToken">The cancellation token associated with the filter.</param>
        /// <param name="continuation">The continuation function.</param>
        /// <returns>The authorization filter to synchronize.</returns>
        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            if (SkipAntiForgeryValidation(actionContext))
            {
                return continuation();
            }

            try
            {
                string cookieValue = actionContext.Request.Headers.GetCookies()
                    .SelectMany(cookie => cookie.Cookies)
                    .Where(cookie => cookie.Name == AntiForgeryHelper.CookieName)
                    .Select(cookie => cookie.Value)
                    .FirstOrDefault();
                IEnumerable<string> headerValues;
                actionContext.Request.Headers.TryGetValues(AntiForgeryHelper.HeaderName, out headerValues);
                AntiForgery.Validate(cookieValue, headerValues.FirstOrDefault());
            }
            catch
            {
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    RequestMessage = actionContext.ControllerContext.Request
                };
                return Task.FromResult(actionContext.Response);
            }

            return continuation();
        }

        /// <summary>
        /// Returns a value indicating whether the specified action context contains a
        /// <see cref="SkipAntiForgeryValidationAttribute"/>.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <returns>A value indicating whether the specified action context contains a
        /// <see cref="SkipAntiForgeryValidationAttribute"/>.</returns>
        private static bool SkipAntiForgeryValidation(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<SkipAntiForgeryValidationAttribute>().Any() ||
                actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<SkipAntiForgeryValidationAttribute>().Any();
        }
    }
}