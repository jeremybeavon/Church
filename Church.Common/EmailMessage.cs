using System.Collections.Generic;
using System.Net.Mail;

namespace Church.Common
{
    public sealed class EmailMessage
    {
        public EmailMessage()
        {
            this.To = new List<MailAddress>();
            this.Cc = new List<MailAddress>();
            this.Bcc = new List<MailAddress>();
            this.Attachments = new List<string>();
        }

        public MailAddress From { get; set; }

        public IList<MailAddress> To { get; private set; }

        public IList<MailAddress> Cc { get; private set; }

        public IList<MailAddress> Bcc { get; private set; }

        public string Subject { get; set; }

        public string Html { get; set; }

        public string Text { get; set; }

        public IList<string> Attachments { get; private set; }
    }
}
