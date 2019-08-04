using System.Linq;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class CardService : ReadWriteService<Card, StarWarsDestinyContext>, ICardService
    {
        private readonly IReadWriteRepository<Card, StarWarsDestinyContext> _repository;
        private readonly IDieService _dieService;
        private readonly IDiceFaceService _diceFaceService;

        public CardService(IReadWriteRepository<Card, StarWarsDestinyContext> repository,
            IDieService dieService, IDiceFaceService diceFaceService) : base(repository)
        {
            _repository = repository;
            _dieService = dieService;
            _diceFaceService = diceFaceService;
        }

        public async Task<bool> GetCardInDb(Card card)
        {
            var cards = await _repository.GetAllWithParametersAsync(a => a.IsCharacter == card.IsCharacter &&
                                                                    a.ColorId == card.ColorId &&
                                                                    a.DataCode == card.DataCode &&
                                                                    a.Name == card.Name);

            return cards.Any();
        }

        public async Task<Card> AddAsync(Card card)
        {
            var die = card.Die;
            if (card.Die != null)
                card.Die = null;

            card = await CreateAsync(card);

            if (die != null)
            {
                die.CardId = card.Id;
                die.Card = null;
                var diceFaces = die.DiceFaces;
                die.DiceFaces = null;

                die = await _dieService.CreateAsync(die);

                foreach (var diceFace in diceFaces)
                {
                    diceFace.Die = null;
                    diceFace.DieId = die.Id;
                    await _diceFaceService.CreateAsync(diceFace);
                }

                card.DieId = die.Id;
                await PartialUpdateAsync(card, new[] {nameof(card.DieId)});
            }

            return card;
        }
    }
}
