using StarWarsDestiny.Common.Repository.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Repository.Interfaces;

namespace StarWarsDestiny.Repository.Impl
{
    public class RarityRepository : ReadWriteRepository<Rarity, StarWarsDestinyContext>, IRarityRepository
    {
        public RarityRepository(StarWarsDestinyContext context) : base(context)
        {
        }
    }
}
