using System.Collections.Generic;
using System.Net.Mail;

namespace Church.Common
{
    /// <summary>
    /// Represents an email message.
    /// </summary>
    public sealed class EmailMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailMessage"/> class.
        /// </summary>
        public EmailMessage()
        {
            this.To = new List<MailAddress>();
            this.Cc = new List<MailAddress>();
            this.Bcc = new List<MailAddress>();
            this.Attachments = new List<string>();
        }

        /// <summary>
        /// Gets or sets the sender of the email.
        /// </summary>
        public MailAddress From { get; set; }

        /// <summary>
        /// Gets the recipients of the email.
        /// </summary>
        public IList<MailAddress> To { get; private set; }

        /// <summary>
        /// Gets the carbon-copy recipients of the email.
        /// </summary>
        public IList<MailAddress> Cc { get; private set; }

        /// <summary>
        /// Gets the blind carbon-copy recipients of the email.
        /// </summary>
        public IList<MailAddress> Bcc { get; private set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the HTML message text.
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets the attachments.
        /// </summary>
        public IList<string> Attachments { get; private set; }
    }
}
