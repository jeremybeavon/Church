using Church.Web.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Church.Web
{
    /// <summary>
    /// The Owin startup class.
    /// </summary>
    public class OwinStartup
    {
        /// <summary>
        /// The Owin configuration method.
        /// </summary>
        /// <param name="app">The app to configure.</param>
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ChurchSignInManager>(CreateChurchSignInManager);
            CookieAuthenticationOptions options = new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            };
            app.UseCookieAuthentication(options);
        }

        /// <summary>
        /// Creates the <see cref="ChurchSignInManager"/>.
        /// </summary>
        /// <param name="options">The options. Not used.</param>
        /// <param name="context">The context used to find the authentication.</param>
        /// <returns>The new <see cref="ChurchSignInManager"/>.</returns>
        private static ChurchSignInManager CreateChurchSignInManager(
            IdentityFactoryOptions<ChurchSignInManager> options,
            IOwinContext context)
        {
            return new ChurchSignInManager(context.Authentication);
        }
    }
}
