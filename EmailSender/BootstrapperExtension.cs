using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using EmailSender.Configuration;

namespace EmailSender
{
    public static class BootstrapperExtension
    {
        public static void RegisterEmailSender(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSenderConfiguration>(
                configuration.GetSection(nameof(EmailSenderConfiguration)));
            services.AddSingleton(resolver =>
                resolver.GetRequiredService<IOptions<EmailSenderConfiguration>>().Value);

            FileReader.BootstrapperExtension.RegisterFileReader(services, configuration);

            services.AddSingleton<ISender, Sender>();
        }
    }
}