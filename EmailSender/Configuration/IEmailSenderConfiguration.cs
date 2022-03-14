namespace EmailSender.Configuration
{
    public interface IEmailSenderConfiguration
    {
        string AddressFrom { get; set; }
        string AddressesToPath { get; set; }
        string AddressFromDisplayName { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        string UserNameFrom { get; set; }
        string Password { get; set; }
        string Host { get; set; }
        bool EnableSsl { get; set; }
        bool UseDefaultCredentials { get; set; }
        int Port { get; set; }
        string AttachmentFileName { get; set; }
        int MinDelay { get; set; }
        int MaxDelay { get; set; }
    }
}