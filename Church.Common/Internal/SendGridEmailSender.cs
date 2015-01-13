using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SendGrid;

namespace Church.Common.Internal
{    
    /// <summary>
    /// Provides methods to send emails.
    /// </summary>
    public sealed class SendGridEmailSender : IEmailSender
    {
        /// <summary>
        /// The send grid user name.
        /// </summary>
        private const string SendGridUserName = "SendGridUserName";

        /// <summary>
        /// The send grid password.
        /// </summary>
        private const string SendGridPassword = "SendGridPassword";

        /// <summary>
        /// The settings.
        /// </summary>
        private readonly IConfigurationSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendGridEmailSender"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public SendGridEmailSender(IConfigurationSettings settings)
        {
            this.settings = settings;
        }

        /// <summary>
        /// Sends the specified email.
        /// </summary>
        /// <param name="email">The email to send.</param>
        public void Send(EmailMessage email)
        {
            this.CreateTransport().Deliver(CreateMessage(email));
        }

        /// <summary>
        /// Asynchronously sends the specified email.
        /// </summary>
        /// <param name="email">The email to send.</param>
        /// <returns>
        /// A task that represents sending the specified email.
        /// </returns>
        public Task SendAsync(EmailMessage email)
        {
            return this.CreateTransport().DeliverAsync(CreateMessage(email));
        }

        /// <summary>
        /// Creates the message.
        /// </summary>
        /// <param name="email">The email to convert.</param>
        /// <returns>A SendGridMessage based on the specified email.</returns>
        private static SendGridMessage CreateMessage(EmailMessage email)
        {
            return new SendGridMessage()
            {
                From = email.From,
                To = email.To.ToArray(),
                Cc = email.Cc.ToArray(),
                Bcc = email.Bcc.ToArray(),
                Subject = email.Subject,
                Html = email.Html,
                Text = email.Text,
                Attachments = email.Attachments.ToArray()
            };
        }

        /// <summary>
        /// Creates the transport.
        /// </summary>
        /// <returns>The transport.</returns>
        private ITransport CreateTransport()
        {
            NetworkCredential credential = new NetworkCredential(
                this.settings.GetSetting(SendGridUserName),
                this.settings.GetSetting(SendGridPassword));
            return new Web(credential);
        }
    }
}
