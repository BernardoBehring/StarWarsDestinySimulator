using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Common.Util.Extensions;
using StarWarsDestiny.Model;
using StarWarsDestiny.Model.Dto;
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

        public async Task<Card> GetCardByDataCode(string dataCode)
        {
            var query = await _repository.GetAllWithParametersAsync(a => a.DataCode == dataCode);

            return query.FirstOrDefault();
        }

        public async Task<IEnumerable<Card>> GetAllWithCardFilter(CardFilter filter, params string[] include)
        {
            if (filter != default)
            {
                var expr = MountFilter(filter, a => a.Id != null);

                return await _repository.GetAllWithParametersAsync(expr.Compile(), include);
            }

            return await _repository.GetAllAsync(include);
        }

        private Expression<Func<Card, bool>> MountFilter(CardFilter filter, Expression<Func<Card, bool>> initialFilter)
        {
            if (filter.Id != default)
                initialFilter = initialFilter.And(a => a.Id == filter.Id);

            if (filter.Name != default)
                initialFilter = initialFilter.And(a => a.Name.Contains(filter.Name));

            if (filter.Subtitle != default)
                initialFilter = initialFilter.And(a => a.Subtitle.Contains(filter.Subtitle));

            if (filter.Text != default)
                initialFilter = initialFilter.And(a => a.Text.Contains(filter.Text));

            if (filter.Number != default)
                initialFilter = initialFilter.And(a => a.Number == filter.Number);

            if (filter.ArtistId != default)
                initialFilter = initialFilter.And(a => a.ArtistId == filter.ArtistId);
            
            if (filter.AffiliationId != default)
                initialFilter = initialFilter.And(a => a.AffiliationId == filter.AffiliationId);
            
            if (filter.FactionId != default)
                initialFilter = initialFilter.And(a => a.FactionId == filter.FactionId);
            
            if (filter.ColorId != default)
                initialFilter = initialFilter.And(a => a.ColorId == filter.ColorId);
            
            if (filter.RarityId != default)
                initialFilter = initialFilter.And(a => a.RarityId == filter.RarityId);
            
            if (filter.SetStarWarsId != default)
                initialFilter = initialFilter.And(a => a.SetStarWarsId == filter.SetStarWarsId);
            
            if (filter.Points != default)
                initialFilter = initialFilter.And(a => a.Points == filter.Points);
            
            if (filter.ElitePoints != default)
                initialFilter = initialFilter.And(a => a.ElitePoints == filter.ElitePoints);
            
            if (filter.Health != default)
                initialFilter = initialFilter.And(a => a.Health == filter.Health);
            
            if (filter.Cost != default)
                initialFilter = initialFilter.And(a => a.Cost == filter.Cost);
            
            if (filter.IsCharacter != default)
                initialFilter = initialFilter.And(a => a.IsCharacter == filter.IsCharacter);
            
            if (filter.IsSuport != default)
                initialFilter = initialFilter.And(a => a.IsSuport == filter.IsSuport);
            
            if (filter.IsUpgrade != default)
                initialFilter = initialFilter.And(a => a.IsUpgrade == filter.IsUpgrade);
            
            if (filter.IsUnique != default)
                initialFilter = initialFilter.And(a => a.IsUnique == filter.IsUnique);

            return initialFilter;
        }
    }
}
