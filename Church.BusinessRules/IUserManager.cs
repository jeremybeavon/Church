using System;
using System.Linq;
using System.Threading.Tasks;
using Church.Data;

namespace Church.BusinessRules
{
    /// <summary>
    /// Provides management methods for users.
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Asynchronously gets a list of users that can be queried.
        /// </summary>
        /// <returns>A task that represents retrieving the list of users.</returns>
        Task<IQueryable<User>> GetUserQueryAsync();

        /// <summary>
        /// Asynchronously find a user with the specified login.
        /// </summary>
        /// <param name="login">The login to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        Task<User> FindAsync(UserLogin login);

        /// <summary>
        /// Asynchronously creates the specified user.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>A task that represents creating the specified user.</returns>
        Task CreateUserAsync(User user);

        /// <summary>
        /// Asynchronously deletes the specified user.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        /// <returns>A task that represents deleting the specified user.</returns>
        Task DeleteUserAsync(User user);

        /// <summary>
        /// Asynchronously updates the specified user.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>A task that represents updating the specified user.</returns>
        Task UpdateUserAsync(User user);

        /// <summary>
        /// Asynchronously find a user with the specified id.
        /// </summary>
        /// <param name="userId">The user id to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        Task<User> FindByIdAsync(Guid userId);

        /// <summary>
        /// Asynchronously find a user with the specified user name.
        /// </summary>
        /// <param name="userName">The user name to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        Task<User> FindByNameAsync(string userName);

        /// <summary>
        /// Asynchronously find a user with the specified email address.
        /// </summary>
        /// <param name="email">The email address to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        Task<User> FindByEmailAsync(string email);

        /// <summary>
        /// Asynchronously updates the specified login state.
        /// </summary>
        /// <param name="loginState">The login state to update.</param>
        /// <returns>A task that represents updating the specified login state.</returns>
        Task UpdateUserLoginStateAsync(UserLoginState loginState);
    }
}
