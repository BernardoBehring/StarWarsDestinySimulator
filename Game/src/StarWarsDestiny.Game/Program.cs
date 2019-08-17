using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StarWarsDestiny.Common.Repository.Impl;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Common.Util.Extensions;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Impl;
using StarWarsDestiny.Service.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsDestiny.Game
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Star Wars Destiny Simulator!");
            Console.WriteLine("Press any key to start new game");
            Console.ReadLine();

            var serviceProvider = GetServiceCollection()
                .BuildServiceProvider();

            var gameService = serviceProvider.GetService<IGameService>();
            var playerService = serviceProvider.GetService<IPlayerService>();
            var playerGameService = serviceProvider.GetService<IPlayerRoundService>();
            var deckService = serviceProvider.GetService<IDeckService>();

            var game = new Model.Game
            {
                InsertedIn = DateTime.Now
            };

            await gameService.CreateAsync(game);

            Console.WriteLine("Type your name");
            var name = Console.ReadLine();

            var player = new Player
            {
                InsertedIn = DateTime.Now,
                Name = name
            };

            var player1 = await playerService.CreateAsync(player);
            var player2Id = await playerService.GetModelIdAsync("bot1");
            var player2 = await playerService.GetByIdAsync(player2Id.ToEntityId());

            var player1Game = new PlayerGame
            {
                InsertedIn = DateTime.Now,
                PlayerId = player1.Id,
                GameId = game.Id
            };

            var player2Game = new PlayerGame
            {
                InsertedIn = DateTime.Now,
                PlayerId = player2.Id,
                GameId = game.Id
            };

            game.PlayerGames.Add(player1Game);
            game.PlayerGames.Add(player2Game);

            var listDecks = await deckService.GetAllAsync();

            Console.WriteLine("Choose your deck");
            foreach (var deck in listDecks)
            {
                Console.WriteLine($"{deck.Id} - {deck.Name}");
            }
            var deckId = Console.ReadLine();
            player1Game.DeckId = Convert.ToInt32(deckId);

            var random = new Random();
            var deckIdPlayer2 = random.Next(listDecks.Min(a => a.Id), listDecks.Max(a => a.Id));

            player2Game.DeckId = deckIdPlayer2;
        }

        private static IServiceCollection GetServiceCollection()
        {
            var services = new ServiceCollection();
            services.AddDbContext<StarWarsDestinyContext>();
            services.TryAddScoped(typeof(IReadWriteRepository<,>), typeof(ReadWriteRepository<,>));
            services.TryAddScoped(typeof(IReadWriteService<,>), typeof(ReadWriteService<,>));

            return services
                    .AddLogging()
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
