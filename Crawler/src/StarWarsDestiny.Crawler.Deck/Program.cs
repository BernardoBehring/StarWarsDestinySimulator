using Microsoft.Extensions.DependencyInjection;
using StarWarsDestiny.Crawler.Model.Enum;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using StarWarsDestiny.Crawler.Service.Impl;
using StarWarsDestiny.Crawler.Service.Interfaces;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Repository.Impl;
using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Crawler.Repository.Context;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Service.Interfaces;
using StarWarsDestiny.Service.Impl;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Crawler.Deck.Interfaces;
using StarWarsDestiny.Crawler.Deck.Controller;
using StarWarsDestiny.Crawler.Deck.Executor;
using StarWarsDestiny.Crawler.Deck.Extractor;

namespace StarWarsDestiny.Crawler.Deck
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = GetServiceCollection()
                .BuildServiceProvider();

            EnumStatus? status = null;
            if (args.Length > 1 && args[1] != null)
                status = (EnumStatus)Enum.Parse(typeof(EnumStatus), args[1]);

            if (status == null)
                status = EnumStatus.AwaitingProcessing;

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            logger.LogDebug(DateTime.Now.ToLongDateString());
            logger.LogDebug("Executing");

            if (args.Length > 0 && string.Equals(args[0], "/downloadDecks", StringComparison.CurrentCultureIgnoreCase))
            {
                var downloadCardController = serviceProvider.GetService<IDownloadDeckSWDestinyDBController>();
                await downloadCardController.ExecuteAsync(status.Value);
            }
            else if (args.Length > 0 &&
                     string.Equals(args[0], "/downloadDeckDetails", StringComparison.CurrentCultureIgnoreCase))
            {
                var downloadCardDetailController =
                    serviceProvider.GetService<IDownloadDeckDetailsSWDestinyDBController>();
                await downloadCardDetailController.ExecuteAsync(status.Value);
            }

            logger.LogDebug("All done!");
        }

        private static IServiceCollection GetServiceCollection()
        {
            var services = new ServiceCollection();
            services.AddDbContext<CrawlerContext>();
            services.AddDbContext<StarWarsDestinyContext>();
            services.TryAddScoped(typeof(IReadWriteRepository<,>), typeof(ReadWriteRepository<,>));
            services.TryAddScoped(typeof(IReadWriteService<,>), typeof(ReadWriteService<,>));

            return services
                    .AddLogging()
                    .AddScoped<IDownloadDeckSWDestinyDBController, DownloadDeckSWDestinyDBController>()
                    .AddScoped<IDownloadDeckSWDestinyDBExecutor, DownloadDeckSWDestinyDBExecutor>()
                    .AddScoped<IDownloadDeckSWDestinyDBExtractor, DownloadDeckSWDestinyDBExtractor>()

                    .AddScoped<IDownloadDeckDetailsSWDestinyDBController, DownloadDeckDetailsSWDestinyDBController>()
                    .AddScoped<IDownloadDeckDetailsSWDestinyDBExecutor, DownloadDeckDetailsSWDestinyDBExecutor>()
                    .AddScoped<IDownloadDeckDetailsSWDestinyDBExtractor, DownloadDeckDetailsSWDestinyDBExtractor>()

                    .AddScoped<IRequestService, RequestService>()
                    .AddScoped<IRobotService, RobotService>()
                    .AddScoped<ISiteService, SiteService>()
                    .AddScoped<IStatusService, StatusService>()

                    .AddScoped<ICardService, CardService>()
                    .AddScoped<IDeckService, DeckService>()
                ;
        }
    }
}
