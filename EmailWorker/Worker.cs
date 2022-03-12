using EmailSender;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
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
            _sender.Send(stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
