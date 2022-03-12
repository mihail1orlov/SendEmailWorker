namespace EmailSender.Configuration
{
    public interface IEmailSenderConfiguration
    {
        string AddressFrom { get; set; }
        string AddressTo { get; set; }
        string AddressFromDisplayName { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        string UserNameFrom { get; set; }
        string Password { get; set; }
        string Host { get; set; }
        bool EnableSsl { get; set; }
        bool UseDefaultCredentials { get; set; }
        int Port { get; set; }
    }
}