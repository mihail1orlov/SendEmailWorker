namespace EmailSender.Configuration
{
    public class EmailSenderConfiguration : IEmailSenderConfiguration
    {
        public string AddressFrom { get; set; }
        public string AddressesToPath { get; set; }
        public string AddressFromDisplayName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string UserNameFrom { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public int Port { get; set; }
        public string AttachmentFileName { get; set; }
        public int MinDelay { get; set; }
        public int MaxDelay { get; set; }
    }
}