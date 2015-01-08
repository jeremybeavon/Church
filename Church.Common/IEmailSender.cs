using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.Common
{
    /// <summary>
    /// Provides methods to send emails.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends the specified email.
        /// </summary>
        /// <param name="email">The email to send.</param>
        void Send(EmailMessage email);

        /// <summary>
        /// Asynchronously sends the specified email.
        /// </summary>
        /// <param name="email">The email to send.</param>
        /// <returns>A task that represents sending the specified email.</returns>
        Task SendAsync(EmailMessage email);
    }
}
