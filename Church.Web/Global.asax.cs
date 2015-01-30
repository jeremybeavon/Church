using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using Church.Common;
using Church.Web.Dependencies;
using WebApiContrib.MessageHandlers;

namespace Church.Web
{
    /// <summary>
    /// Initializes the web application.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// The require SSL configuration key.
        /// </summary>
        private const string RequireSslConfigKey = "RequireSSL";

        /// <summary>
        /// Initializes the web application.
        /// </summary>
        protected void Application_Start()
        {
            DependencyManager.Load(new WebDependencyModule());
            GlobalConfiguration.Configure(ConfigureHttp);
        }

        /// <summary>
        /// Configures http settings.
        /// </summary>
        /// <param name="configuration">The http configuration.</param>
        private static void ConfigureHttp(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();
            configuration.DependencyResolver = new WebDependencyResolver();
            configuration.Filters.Add(new AuthorizeAttribute());
            configuration.Filters.Add(new ValidateAntiForgeryTokenAttribute());
            if (DependencyManager.Get<IConfigurationSettings>().GetBooleanSetting(RequireSslConfigKey, true))
            {
                configuration.MessageHandlers.Add(new RequireHttpsHandler());
            }
        }
    }
}
