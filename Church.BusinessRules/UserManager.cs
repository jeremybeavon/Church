using System;
using System.Linq;
using System.Threading.Tasks;
using Church.BusinessRules;
using Church.Common;
using Church.Data;
using Church.DataAccess;

[assembly: RegisterBinding(typeof(Binding<IUserManager, UserManager>))]

namespace Church.BusinessRules
{
    /// <summary>
    /// Provides management methods for users.
    /// </summary>
    public sealed class UserManager : IUserManager
    {
        /// <summary>
        /// The user data access.
        /// </summary>
        private readonly IUserDataAccess userDataAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="userDataAccess">The user data access.</param>
        public UserManager(IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        /// <summary>
        /// Asynchronously gets a list of users that can be queried.
        /// </summary>
        /// <returns>A task that represents retrieving the list of users.</returns>
        public Task<IQueryable<User>> GetUserQueryAsync()
        {
            return this.userDataAccess.GetUserQueryAsync();
        }

        /// <summary>
        /// Asynchronously find a user with the specified login.
        /// </summary>
        /// <param name="login">The login to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        public Task<User> FindAsync(UserLogin login)
        {
            return this.userDataAccess.FindAsync(login);
        }

        /// <summary>
        /// Asynchronously creates the specified user.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>A task that represents creating the specified user.</returns>
        public Task CreateUserAsync(User user)
        {
            return this.userDataAccess.CreateUserAsync(user);
        }

        /// <summary>
        /// Asynchronously deletes the specified user.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        /// <returns>A task that represents deleting the specified user.</returns>
        public Task DeleteUserAsync(User user)
        {
            return this.userDataAccess.DeleteUserAsync(user);
        }

        /// <summary>
        /// Asynchronously updates the specified user.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>A task that represents updating the specified user.</returns>
        public Task UpdateUserAsync(User user)
        {
            return this.userDataAccess.UpdateUserAsync(user);
        }

        /// <summary>
        /// Asynchronously find a user with the specified id.
        /// </summary>
        /// <param name="userId">The user id to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        public Task<User> FindByIdAsync(Guid userId)
        {
            return this.userDataAccess.FindByIdAsync(userId);
        }

        /// <summary>
        /// Asynchronously find a user with the specified user name.
        /// </summary>
        /// <param name="userName">The user name to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        public Task<User> FindByNameAsync(string userName)
        {
            return this.userDataAccess.FindByNameAsync(userName);
        }

        /// <summary>
        /// Asynchronously find a user with the specified email address.
        /// </summary>
        /// <param name="email">The email address to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        public Task<User> FindByEmailAsync(string email)
        {
            return this.userDataAccess.FindByEmailAsync(email);
        }

        /// <summary>
        /// Asynchronously updates the specified login state.
        /// </summary>
        /// <param name="loginState">The login state to update.</param>
        /// <returns>A task that represents updating the specified login state.</returns>
        public Task UpdateUserLoginStateAsync(UserLoginState loginState)
        {
            return this.userDataAccess.UpdateUserLoginStateAsync(loginState);
        }
    }
}
