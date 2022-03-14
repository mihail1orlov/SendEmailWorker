using EmailSender;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EmailWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISender _sender;

        public Worker(ILogger<Worker> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("start mailing");
            _sender.Send(stoppingToken);
            _logger.LogInformation("stop mailing");
        }
    }
}
