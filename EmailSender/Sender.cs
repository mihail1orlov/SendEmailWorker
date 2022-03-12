using EmailSender.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace EmailSender
{
    public class Sender : ISender
    {
        private readonly IEmailSenderConfiguration _emailSenderConfiguration;

        public Sender(EmailSenderConfiguration emailSenderConfiguration)
        {
            _emailSenderConfiguration = emailSenderConfiguration;
        }

        public void Send(CancellationToken cancellationToken)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(_emailSenderConfiguration.AddressFrom, _emailSenderConfiguration.AddressFromDisplayName);
            msg.Subject = _emailSenderConfiguration.Subject;
            msg.Body = _emailSenderConfiguration.Body;
            msg.To.Add(_emailSenderConfiguration.AddressTo);
            //msg.Priority = MailPriority.High;

            using var client = new SmtpClient();
            client.EnableSsl = _emailSenderConfiguration.EnableSsl;
            client.UseDefaultCredentials = _emailSenderConfiguration.UseDefaultCredentials;
            client.Credentials = new NetworkCredential(_emailSenderConfiguration.UserNameFrom, _emailSenderConfiguration.Password);
            client.Host = _emailSenderConfiguration.Host;
            client.Port = _emailSenderConfiguration.Port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.Send(msg);
        }
    }
}