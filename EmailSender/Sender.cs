using EmailSender.Configuration;
using FileReader;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace EmailSender
{
    public class Sender : ISender
    {
        private readonly ILogger<Sender> _logger;
        private readonly IEmailSenderConfiguration _emailSenderConfiguration;
        private readonly IFileReader _fileReader;

        public Sender(ILogger<Sender> logger,
            EmailSenderConfiguration emailSenderConfiguration,
            IFileReader fileReader)
        {
            _logger = logger;
            _emailSenderConfiguration = emailSenderConfiguration;
            _fileReader = fileReader;
        }

        public void Send(CancellationToken cancellationToken)
        {
            foreach (var address in _fileReader.GetLines(_emailSenderConfiguration.AddressesToPath))
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    Send(address);
                    _logger.LogInformation($"Sent: {address}");
                    var millisecondsTimeout = new Random()
                        .Next(_emailSenderConfiguration.MinDelay,
                            _emailSenderConfiguration.MaxDelay);
                    Thread.Sleep(millisecondsTimeout);
                };
            }
        }

        private void Send(string address)
        {
            var msg = new MailMessage
            {
               From = new MailAddress(_emailSenderConfiguration.AddressFrom,
                   _emailSenderConfiguration.AddressFromDisplayName),
               Subject = _emailSenderConfiguration.Subject,
               Body = _emailSenderConfiguration.Body,
            };

            msg.To.Add(address);
            msg.Attachments.Add(new Attachment(_emailSenderConfiguration.AttachmentFileName));

            using var client = new SmtpClient
            {
                EnableSsl = _emailSenderConfiguration.EnableSsl,
                UseDefaultCredentials = _emailSenderConfiguration.UseDefaultCredentials,
                Credentials = new NetworkCredential(_emailSenderConfiguration.UserNameFrom, _emailSenderConfiguration.Password),
                Host = _emailSenderConfiguration.Host,
                Port = _emailSenderConfiguration.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

            client.Send(msg);
        }
    }
}