using EmailSender;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailWorker.Configuration
{
    public static class EmailWorkerConfigurationExtension
    {
        public static void ConfigureEmailSender(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.RegisterEmailSender(configuration);
        }
    }
}