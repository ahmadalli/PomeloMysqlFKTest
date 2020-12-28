using FKTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FKTest.Services.HostedServices
{
    public class StartupHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<StartupHostedService> _logger;

        public StartupHostedService(
            IServiceProvider serviceProvider,
            ILogger<StartupHostedService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var _ = _logger.BeginScope(("state", "configuring application"));
            using var scope = _serviceProvider.CreateScope();
            using var dbContext = scope.ServiceProvider.GetService<FkDbContext>();

            _logger.LogInformation("migrating database.");
            await dbContext.Database.MigrateAsync(cancellationToken);

            var childs = await dbContext.Set<Child>()
                .Where(x=>x.Name.StartsWith("David"))
                .Where(x=>x.Code.EndsWith("74"))
                .Where(x=>x.Parent.Code.EndsWith("74"))
                .Where(x => x.Parent.Created > x.Created - TimeSpan.FromMinutes(30))
                .OrderBy(x => x.Created)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
