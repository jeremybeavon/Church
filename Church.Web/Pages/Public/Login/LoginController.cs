using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using Church.Data;
using Church.Web.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Church.Web.Pages.Public.Login
{
    /// <summary>
    /// The controller for logging in.
    /// </summary>
    public class LoginController : ApiController
    {
        /// <summary>
        /// The sign-in manager.
        /// </summary>
        private readonly ChurchSignInManager signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="signInManager">The sign-in manager.</param>
        public LoginController(ChurchSignInManager signInManager)
        {
            this.signInManager = signInManager;
        }

        /// <summary>
        /// Tries to use the specified credentials to log in.
        /// </summary>
        /// <param name="login">The credentials to log in with.</param>
        /// <returns>A task that represents the result of the login.</returns>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [SkipAntiForgeryValidation]
        public async Task<HttpResponseMessage> LogIn(LoginRequest login)
        {
            switch (await this.signInManager.PasswordSignInAsync(login.UserName, login.Password, true, false))
            {
                case SignInStatus.Success:
                    string requestValidationToken;
                    string cookieToken;
                    AntiForgery.GetTokens(null, out cookieToken, out requestValidationToken);
                    LoginResponse loginResponse = new LoginResponse(LoginStatus.Success)
                    {
                        RequestValidationToken = requestValidationToken
                    };
                    HttpResponseMessage response = Request.CreateResponse<LoginResponse>(loginResponse);
                    response.Headers.AddCookies(new[] { new CookieHeaderValue(AntiForgeryHelper.CookieName, cookieToken) });
                    return response;
                default:
                    return Request.CreateResponse<LoginResponse>(new LoginResponse(LoginStatus.IncorrectUserNameOrPassword));
            }
        }
    }
}
