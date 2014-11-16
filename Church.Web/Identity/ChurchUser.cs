using System;
using Church.Data;
using EnsureThat;
using Microsoft.AspNet.Identity;

namespace Church.Web.Identity
{
    /// <summary>
    /// Represents a user of the system.
    /// </summary>
    public sealed class ChurchUser : IUser<Guid>
    {
        /// <summary>
        /// The user data.
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChurchUser"/> class.
        /// </summary>
        /// <param name="user">The user data.</param>
        public ChurchUser(User user)
        {
            Ensure.That(user, "user").IsNotNull();
            this.user = user;
        }

        /// <summary>
        /// Gets the id of this user.
        /// </summary>
        public Guid Id
        {
            get { return Guid.Parse(this.user.Id); }
        }

        /// <summary>
        /// Gets or sets the name of this user.
        /// </summary>
        public string UserName
        {
            get { return this.user.UserName; }
            set { this.user.UserName = value; }
        }

        /// <summary>
        /// Gets the user data.
        /// </summary>
        public User User
        {
            get { return this.user; }
        }
    }
}