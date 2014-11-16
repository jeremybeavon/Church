using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Data
{
    /// <summary>
    /// The data sent as the response to a login request.
    /// </summary>
    public sealed class LoginResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginResponse"/> class.
        /// </summary>
        public LoginResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginResponse"/> class.
        /// </summary>
        /// <param name="loginStatus">The login status.</param>
        public LoginResponse(LoginStatus loginStatus)
        {
            this.LoginStatus = loginStatus;
        }

        /// <summary>
        /// Gets or sets the login status.
        /// </summary>
        public LoginStatus LoginStatus { get; set; }

        /// <summary>
        /// Gets or sets the request validation token.
        /// </summary>
        public string RequestValidationToken { get; set; }
    }
}
