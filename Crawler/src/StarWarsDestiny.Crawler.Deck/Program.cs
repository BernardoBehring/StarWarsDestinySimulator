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
using Microsoft.Extensions.Configuration;

namespace StarWarsDestiny.Crawler.Deck
{
    public class Program
    {
        private static IConfiguration _configuration;
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

            if (args.Length > 0 && string.Equals(args[0], "/downloadCards", StringComparison.CurrentCultureIgnoreCase))
            {
                var downloadCardController = serviceProvider.GetService<IDownloadCardSWDestinyDBController>();
                await downloadCardController.ExecuteAsync(status.Value);
            }
            else if (args.Length > 0 &&
                     string.Equals(args[0], "/downloadCardDetails", StringComparison.CurrentCultureIgnoreCase))
            {
                var downloadCardDetailController =
                    serviceProvider.GetService<IDownloadCardDetailSWDestinyDBController>();
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
                    //.AddScoped<IDownloadCardSWDestinyDBController, DownloadCardSWDestinyDBController>()
                    //.AddScoped<IDownloadCardSWDestinyDBExecutor, DownloadCardSWDestinyDBExecutor>()
                    //.AddScoped<IDownloadCardSWDestinyDBExtractor, DownloadCardSWDestinyDBExtractor>()
                    
                    .AddScoped<IRequestService, RequestService>()
                    .AddScoped<IRobotService, RobotService>()
                    .AddScoped<ISiteService, SiteService>()
                    .AddScoped<IStatusService, StatusService>()

                    .AddScoped<IAffiliationService, AffiliationService>()
                    .AddScoped<IArtistService, ArtistService>()
                    .AddScoped<IBalanceForceService, BalanceForceService>()
                    .AddScoped<ICardLegalityService, CardLegalityService>()
                    .AddScoped<ICardService, CardService>()
                    .AddScoped<IColorService, ColorService>()
                    .AddScoped<IDiceActionService, DiceActionService>()
                    .AddScoped<IDiceFaceService, DiceFaceService>()
                    .AddScoped<IDieService, DieService>()
                    .AddScoped<IFactionService, FactionService>()
                    .AddScoped<ILegalityService, LegalityService>()
                    .AddScoped<IRarityService, RarityService>()
                    .AddScoped<ISetStarWarsService, SetStarWarsService>()
                    .AddScoped<ITypeService, TypeService>()
                ;
        }
    }
}
