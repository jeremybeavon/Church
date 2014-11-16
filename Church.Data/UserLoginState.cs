using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace Church.Data
{
    /// <summary>
    /// Represents the login state of a user.
    /// </summary>
    public sealed class UserLoginState
    {
        /// <summary>
        /// A count of the number of times the user has failed to log in.
        /// </summary>
        private int accessFailedCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginState"/> class.
        /// </summary>
        public UserLoginState()
        {
            this.Logins = new Collection<UserLogin>();
        }

        /// <summary>
        /// Gets or sets the number of times the user has failed to log in.
        /// </summary>
        public int AccessFailedCount
        {
            get { return this.accessFailedCount; }
            set { this.accessFailedCount = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this user can be locked out.
        /// </summary>
        public bool IsLockoutEnabled { get; set; }

        /// <summary>
        /// Gets or sets the end date of a lockout.
        /// </summary>
        public DateTimeOffset LockoutEndDate { get; set; }

        /// <summary>
        /// Gets a list of the current user logins.
        /// </summary>
        public Collection<UserLogin> Logins { get; private set; }

        /// <summary>
        /// Increments the number of times the user has failed to log in.
        /// </summary>
        /// <returns>The number of time the user has failed to log in.</returns>
        public int IncrementAccessFailedCount()
        {
            return Interlocked.Increment(ref this.accessFailedCount);
        }

        /// <summary>
        /// Resets the number of times the user has failed to log in.
        /// </summary>
        public void ResetAccessFailedCount()
        {
            Interlocked.Exchange(ref this.accessFailedCount, 0);
        }
    }
}
