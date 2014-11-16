using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Church.BusinessRules;
using Church.Data;
using EnsureThat;
using Microsoft.AspNet.Identity;

namespace Church.Web.Identity
{
    /// <summary>
    /// Provides a user store.
    /// </summary>
    public sealed class ChurchUserStore :
        IUserLoginStore<ChurchUser, Guid>,
        IUserEmailStore<ChurchUser, Guid>,
        IUserLockoutStore<ChurchUser, Guid>,
        IUserPasswordStore<ChurchUser, Guid>,
        IUserPhoneNumberStore<ChurchUser, Guid>,
        ////IUserRoleStore<ChurchUser, Guid>,
        ////IUserSecurityStampStore<ChurchUser, Guid>,
        IUserTwoFactorStore<ChurchUser, Guid>,
        IQueryableUserStore<ChurchUser, Guid>
    {
        /// <summary>
        /// The user manager.
        /// </summary>
        private readonly IUserManager userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChurchUserStore"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public ChurchUserStore(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// Gets a list of users that can be queried.
        /// </summary>
        public IQueryable<ChurchUser> Users
        {
            get 
            {
                Task<IQueryable<User>> userQueryTask = this.userManager.GetUserQueryAsync();
                userQueryTask.RunSynchronously();
                return userQueryTask.Result.Select(user => new ChurchUser(user));
            }
        }

        /// <summary>
        /// Asynchronously adds a user login with the specified provider and key.
        /// </summary>
        /// <param name="user">The user that is being logged in.</param>
        /// <param name="login">The login info.</param>
        /// <returns>A task that represents adding a user login with the specified provider and key.</returns>
        public Task AddLoginAsync(ChurchUser user, UserLoginInfo login)
        {
            user.User.LoginState.Logins.Add(this.GetUserLogin(login));
            return this.UpdateLoginStateAsync(user);
        }

        /// <summary>
        /// Asynchronously returns the user associated with the specified login.
        /// </summary>
        /// <param name="login">The login to search for.</param>
        /// <returns>A task that represents returning the user associated with the specified login.</returns>
        public async Task<ChurchUser> FindAsync(UserLoginInfo login)
        {
            return this.GetChurchUser(await this.userManager.FindAsync(this.GetUserLogin(login)));
        }

        /// <summary>
        /// Asynchronously returns the linked accounts for the specified user.
        /// </summary>
        /// <param name="user">The user to get the logins for.</param>
        /// <returns>A task that represents returning the linked accounts for the specified user.</returns>
        public Task<IList<UserLoginInfo>> GetLoginsAsync(ChurchUser user)
        {
            return Task.FromResult<IList<UserLoginInfo>>(user.User.LoginState.Logins.Select(this.GetUserLogin).ToList());
        }

        /// <summary>
        /// Asynchronously removes the user login with the specified combination if it exists.
        /// </summary>
        /// <param name="user">The user that will have login info removed.</param>
        /// <param name="login">The login info to remove from the specified user.</param>
        /// <returns>A task that represents removing the user login.</returns>
        public async Task RemoveLoginAsync(ChurchUser user, UserLoginInfo login)
        {
            UserLogin userLoginToRemove = user.User.LoginState.Logins.SingleOrDefault(
                userLogin => userLogin.LoginProvider == login.LoginProvider && userLogin.ProviderKey == login.ProviderKey);
            if (userLoginToRemove != null)
            {
                user.User.LoginState.Logins.Remove(userLoginToRemove);
                await this.UpdateLoginStateAsync(user);
            }
        }

        /// <summary>
        /// Asynchronously creates the specified user.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>A task that represents creating the specified user.</returns>
        public Task CreateAsync(ChurchUser user)
        {
            return this.userManager.CreateUserAsync(user.User);
        }

        /// <summary>
        /// Asynchronously deletes the specified user.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        /// <returns>A task that represents deleting the specified user.</returns>
        public Task DeleteAsync(ChurchUser user)
        {
            return this.userManager.DeleteUserAsync(user.User);
        }

        /// <summary>
        /// Asynchronously find a user with the specified id.
        /// </summary>
        /// <param name="userId">The user id to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        public async Task<ChurchUser> FindByIdAsync(Guid userId)
        {
            return this.GetChurchUser(await this.userManager.FindByIdAsync(userId));
        }

        /// <summary>
        /// Asynchronously find a user with the specified user name.
        /// </summary>
        /// <param name="userName">The user name to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        public async Task<ChurchUser> FindByNameAsync(string userName)
        {
            return this.GetChurchUser(await this.userManager.FindByNameAsync(userName));
        }

        /// <summary>
        /// Asynchronously updates the specified user.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>A task that represents updating the specified user.</returns>
        public Task UpdateAsync(ChurchUser user)
        {
            return this.userManager.UpdateUserAsync(user.User);
        }

        /// <summary>
        /// Asynchronously find a user with the specified email address.
        /// </summary>
        /// <param name="email">The email address to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        public async Task<ChurchUser> FindByEmailAsync(string email)
        {
            Ensure.That(email, "email").IsNotNullOrWhiteSpace();
            return this.GetChurchUser(await this.userManager.FindByEmailAsync(email));
        }

        /// <summary>
        /// Asynchronously gets the email address for the specified user.
        /// </summary>
        /// <param name="user">The user to get the email address for.</param>
        /// <returns>A task that represents getting the email address for the specified user.</returns>
        public Task<string> GetEmailAsync(ChurchUser user)
        {
            return Task.FromResult(user.User.EmailAddress);
        }

        /// <summary>
        /// Asynchronously gets a value indicating whether the email address for the specified user has
        /// been confirmed.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents getting a value indicating whether the email address for
        /// the specified user has been confirmed.</returns>
        public Task<bool> GetEmailConfirmedAsync(ChurchUser user)
        {
            return Task.FromResult(user.User.IsEmailAddressConfirmed);
        }

        /// <summary>
        /// Asynchronously sets the email address for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="email">The new email address.</param>
        /// <returns>A task that represents setting the email address for the specified user.</returns>
        public Task SetEmailAsync(ChurchUser user, string email)
        {
            user.User.EmailAddress = email;
            return this.UpdateAsync(user);
        }

        /// <summary>
        /// Asynchronously sets a value indicating whether the email address for the specified user has
        /// been confirmed.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="confirmed">The new value indicating whether the email address for the specified user has
        /// been confirmed.</param>
        /// <returns>A task that represents setting a value indicating whether the email address for
        /// the specified user has been confirmed.</returns>
        public Task SetEmailConfirmedAsync(ChurchUser user, bool confirmed)
        {
            user.User.IsEmailAddressConfirmed = confirmed;
            return this.UpdateAsync(user);
        }

        /// <summary>
        /// Asynchronously gets the number of times the specified user has failed to log in.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents getting the number of times the specified user has
        /// failed to log in.</returns>
        public Task<int> GetAccessFailedCountAsync(ChurchUser user)
        {
            return Task.FromResult(user.User.LoginState.AccessFailedCount);
        }

        /// <summary>
        /// Asynchronously gets a value indicating whether the specified user can be locked out.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents getting a value indicating whether the specified user
        /// can be locked out.</returns>
        public Task<bool> GetLockoutEnabledAsync(ChurchUser user)
        {
            return Task.FromResult(user.User.LoginState.IsLockoutEnabled);
        }

        /// <summary>
        /// Asynchronously gets the lockout end date for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents getting the lockout end date for the specified user.</returns>
        public Task<DateTimeOffset> GetLockoutEndDateAsync(ChurchUser user)
        {
            return Task.FromResult(user.User.LoginState.LockoutEndDate);
        }

        /// <summary>
        /// Asynchronously increments the number of times the specified user has failed to log in.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents incrementing the number of times the specified user has
        /// failed to log in.</returns>
        public async Task<int> IncrementAccessFailedCountAsync(ChurchUser user)
        {
            int accessFailedCount = user.User.LoginState.IncrementAccessFailedCount();
            await this.UpdateLoginStateAsync(user);
            return accessFailedCount;
        }

        /// <summary>
        /// Asynchronously resets the number of times the specified user has failed to log in.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents resetting the number of times the specified user has
        /// failed to log in.</returns>
        public Task ResetAccessFailedCountAsync(ChurchUser user)
        {
            user.User.LoginState.ResetAccessFailedCount();
            return this.UpdateLoginStateAsync(user);
        }

        /// <summary>
        /// Asynchronously sets a value indicating whether the specified user can be locked out.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="enabled">The new value indicating whether the specified user can be locked out.</param>
        /// <returns>A task that represents setting a value indicating whether the specified user
        /// can be locked out.</returns>
        public Task SetLockoutEnabledAsync(ChurchUser user, bool enabled)
        {
            user.User.LoginState.IsLockoutEnabled = enabled;
            return this.UpdateLoginStateAsync(user);
        }

        /// <summary>
        /// Asynchronously sets the lockout end date for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="lockoutEnd">The new lockout end date.</param>
        /// <returns>A task that represents setting the lockout end date for the specified user.</returns>
        public Task SetLockoutEndDateAsync(ChurchUser user, DateTimeOffset lockoutEnd)
        {
            user.User.LoginState.LockoutEndDate = lockoutEnd;
            return this.UpdateLoginStateAsync(user);
        }

        /// <summary>
        /// Asynchronously gets the password hash for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents getting the password hash for the specified user.</returns>
        public Task<string> GetPasswordHashAsync(ChurchUser user)
        {
            return Task.FromResult(user.User.PasswordHash);
        }

        /// <summary>
        /// Asynchronously gets a value indicating whether the specified user has a password.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents getting a value indicating whether the specified user
        /// has a password.</returns>
        public Task<bool> HasPasswordAsync(ChurchUser user)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Asynchronously sets the password hash for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="passwordHash">The new password hash.</param>
        /// <returns>A task that represents setting the password hash for the specified user.</returns>
        public Task SetPasswordHashAsync(ChurchUser user, string passwordHash)
        {
            user.User.PasswordHash = passwordHash;
            return this.UpdateAsync(user);
        }

        /// <summary>
        /// Asynchronously gets the mobile phone number for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents getting the mobile phone number for the specified user.</returns>
        public Task<string> GetPhoneNumberAsync(ChurchUser user)
        {
            return Task.FromResult(user.User.MobilePhoneNumber);
        }

        /// <summary>
        /// Asynchronously gets a value indicating whether the mobile phone number for the specified user has
        /// been confirmed.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents getting a value indicating whether the mobile phone number for
        /// the specified user has been confirmed.</returns>
        public Task<bool> GetPhoneNumberConfirmedAsync(ChurchUser user)
        {
            return Task.FromResult(user.User.IsMobilePhoneNumberConfirmed);
        }

        /// <summary>
        /// Asynchronously sets the mobile phone number for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="phoneNumber">The new mobile phone number.</param>
        /// <returns>A task that represents setting the mobile phone number for the specified user.</returns>
        public Task SetPhoneNumberAsync(ChurchUser user, string phoneNumber)
        {
            user.User.MobilePhoneNumber = phoneNumber;
            return this.UpdateAsync(user);
        }

        /// <summary>
        /// Asynchronously sets a value indicating whether the mobile phone number for the specified user has
        /// been confirmed.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="confirmed">The new value indicating whether the mobile phone number for the specified user has
        /// been confirmed.</param>
        /// <returns>A task that represents setting a value indicating whether the mobile phone number for
        /// the specified user has been confirmed.</returns>
        public Task SetPhoneNumberConfirmedAsync(ChurchUser user, bool confirmed)
        {
            user.User.IsMobilePhoneNumberConfirmed = confirmed;
            return this.UpdateAsync(user);
        }

        /// <summary>
        /// Asynchronously adds the specified role to the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="roleName">The role to add to the specified user.</param>
        /// <returns>A task that represents adding the specified role to the specified user.</returns>
        public Task AddToRoleAsync(ChurchUser user, string roleName)
        {
            Ensure.That(roleName, "roleName").IsNotNullOrWhiteSpace();
            user.User.Roles.Add(roleName);
            return this.UpdateAsync(user);
        }

        /// <summary>
        /// Asynchronously gets the roles for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents getting the roles for the specified user.</returns>
        public Task<IList<string>> GetRolesAsync(ChurchUser user)
        {
            return Task.FromResult<IList<string>>(user.User.Roles.ToList());
        }

        /// <summary>
        /// Asynchronously gets a value indicating whether the specified user has the specified role.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="roleName">The role name.</param>
        /// <returns>A task that represents getting a value indicating whether the specified user
        /// has the specified role.</returns>
        public Task<bool> IsInRoleAsync(ChurchUser user, string roleName)
        {
            Ensure.That(roleName, "roleName").IsNotNullOrWhiteSpace();
            return Task.FromResult(user.User.Roles.Contains(roleName));
        }

        /// <summary>
        /// Asynchronously removes the specified role to the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="roleName">The role to add to the specified user.</param>
        /// <returns>A task that represents removing the specified role to the specified user.</returns>
        public Task RemoveFromRoleAsync(ChurchUser user, string roleName)
        {
            Ensure.That(roleName, "roleName").IsNotNullOrWhiteSpace();
            user.User.Roles.Remove(roleName);
            return this.UpdateAsync(user);
        }

        /// <summary>
        /// Asynchronously gets the security stamp for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents getting the security stamp for the specified user.</returns>
        public Task<string> GetSecurityStampAsync(ChurchUser user)
        {
            return Task.FromResult(user.User.SecurityStamp);
        }

        /// <summary>
        /// Asynchronously sets the security stamp for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="stamp">The new security stamp.</param>
        /// <returns>A task that represents setting the security stamp for the specified user.</returns>
        public Task SetSecurityStampAsync(ChurchUser user, string stamp)
        {
            user.User.SecurityStamp = stamp;
            return this.UpdateAsync(user);
        }

        /// <summary>
        /// Asynchronously gets a value indicating whether two-factor authentication is enabled for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <returns>A task that represents indicating whether two-factor authentication is enabled
        /// for the specified user.</returns>
        public Task<bool> GetTwoFactorEnabledAsync(ChurchUser user)
        {
            return Task.FromResult(false);
        }

        /// <summary>
        /// Asynchronously sets a value indicating whether two-factor authentication is enabled for the specified user.
        /// </summary>
        /// <param name="user">The user to query.</param>
        /// <param name="enabled">A value indicating whether two-factor authentication is enabled for the
        /// specified user.</param>
        /// <returns>A task that represents setting a value indicating whether two-factor authentication is enabled
        /// for the specified user.</returns>
        public Task SetTwoFactorEnabledAsync(ChurchUser user, bool enabled)
        {
            return Task.FromResult(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Gets a <see cref="ChurchUser"/> based on a <see cref="User"/>.
        /// </summary>
        /// <param name="user">The user to convert to a ChurchUser.</param>
        /// <returns>A ChurchUser based on the specified user.</returns>
        private ChurchUser GetChurchUser(User user)
        {
            return user == null ? null : new ChurchUser(user);
        }

        /// <summary>
        /// Converts a UserLogin to a UserLoginInfo.
        /// </summary>
        /// <param name="login">The login to convert.</param>
        /// <returns>A UserLoginInfo based on the specified login.</returns>
        private UserLoginInfo GetUserLogin(UserLogin login)
        {
            return new UserLoginInfo(login.LoginProvider, login.ProviderKey);
        }

        /// <summary>
        /// Converts a UserLoginInfo to a UserLogin.
        /// </summary>
        /// <param name="login">The login to convert.</param>
        /// <returns>A UserLogin based on the specified login.</returns>
        private UserLogin GetUserLogin(UserLoginInfo login)
        {
            return new UserLogin
            {
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey
            };
        }

        /// <summary>
        /// Asynchronously updates the login state of the specified user.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>A task that represents updating the login state of the specified user.</returns>
        private Task UpdateLoginStateAsync(ChurchUser user)
        {
            return this.userManager.UpdateUserLoginStateAsync(user.User.LoginState);
        }
    }
}