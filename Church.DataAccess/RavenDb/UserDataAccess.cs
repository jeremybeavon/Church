using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Church.Common;
using Church.Data;
using Church.DataAccess;
using Church.DataAccess.RavenDb;
using Raven.Client;

[assembly: RegisterBinding(typeof(Binding<IUserDataAccess, UserDataAccess>), RavenDbDependencyModule.Container)]

namespace Church.DataAccess.RavenDb
{
    /// <summary>
    /// Data access for users.
    /// </summary>
    public sealed class UserDataAccess : AbstractDataAccess, IUserDataAccess
    {
        /// <summary>
        /// Asynchronously gets a list of users that can be queried.
        /// </summary>
        /// <returns>A task that represents retrieving the list of users.</returns>
        public Task<IQueryable<User>> GetUserQueryAsync()
        {
            return Task.FromResult((IQueryable<User>)CreateSession().Query<User>());
        }

        /// <summary>
        /// Asynchronously find a user with the specified login.
        /// </summary>
        /// <param name="login">The login to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        public Task<User> FindAsync(UserLogin login)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously creates the specified user.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>A task that represents creating the specified user.</returns>
        public Task CreateUserAsync(User user)
        {
            return this.SaveAsync(user);
        }

        /// <summary>
        /// Asynchronously deletes the specified user.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        /// <returns>A task that represents deleting the specified user.</returns>
        public Task DeleteUserAsync(User user)
        {
            return this.SaveAsync(user);
        }

        /// <summary>
        /// Asynchronously updates the specified user.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>A task that represents updating the specified user.</returns>
        public Task UpdateUserAsync(User user)
        {
            return this.SaveAsync(user);
        }

        /// <summary>
        /// Asynchronously find a user with the specified id.
        /// </summary>
        /// <param name="userId">The user id to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        public async Task<User> FindByIdAsync(Guid userId)
        {
            using (IAsyncDocumentSession session = CreateSession())
            {
                return await session.LoadAsync<User>(userId.ToString());
            }
        }

        /// <summary>
        /// Asynchronously find a user with the specified user name.
        /// </summary>
        /// <param name="userName">The user name to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        public async Task<User> FindByNameAsync(string userName)
        {
            using (IAsyncDocumentSession session = CreateSession())
            {
                return (await session.Query<User>().Where(user => user.UserName == userName).ToListAsync()).FirstOrDefault();
            }
        }

        /// <summary>
        /// Asynchronously find a user with the specified email address.
        /// </summary>
        /// <param name="email">The email address to find.</param>
        /// <returns>A task that represents finding the specified user.</returns>
        public async Task<User> FindByEmailAsync(string email)
        {
            using (IAsyncDocumentSession session = CreateSession())
            {
                return (await session.Query<User>().Where(user => user.EmailAddress == email).ToListAsync())[0];
            }    
        }

        /// <summary>
        /// Asynchronously updates the specified login state.
        /// </summary>
        /// <param name="loginState">The login state to update.</param>
        /// <returns>A task that represents updating the specified login state.</returns>
        public Task UpdateUserLoginStateAsync(UserLoginState loginState)
        {
            throw new NotImplementedException();
        }
    }
}
