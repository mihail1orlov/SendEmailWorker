using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileReader
{
    public static class BootstrapperExtension
    {
        public static void RegisterFileReader(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFileReader, FileReader>();
        }
    }
}