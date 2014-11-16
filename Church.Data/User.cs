using System;
using System.Collections.Generic;
using Church.Common;

namespace Church.Data
{
    /// <summary>
    /// Represents a user of the system.
    /// </summary>
    public sealed class User : AbstractData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.Roles = new HashSet<string>();
            this.LoginState = new UserLoginState();
        }

        /// <summary>
        /// Gets or sets the full name of this user.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the login name of this user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password hash of this user.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the email address of this user.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the email address of this user has been confirmed.
        /// </summary>
        public bool IsEmailAddressConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone number of this user.
        /// </summary>
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the mobile phone number of this user has been confirmed.
        /// </summary>
        public bool IsMobilePhoneNumberConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the security stamp for this user.
        /// </summary>
        public string SecurityStamp { get; set; }

        /// <summary>
        /// Gets the roles that this user belongs to.
        /// </summary>
        public HashSet<string> Roles { get; private set; }

        /// <summary>
        /// Gets or sets the login state of this user.
        /// </summary>
        public UserLoginState LoginState { get; set; }
    }
}
