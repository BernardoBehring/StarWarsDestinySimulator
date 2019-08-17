using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Common.Util.Extensions
{
    public static class EntityIdExtensions
    {
        public static EntityId ToEntityId(this int id)
        {
            return new EntityId
            {
                Id = id
            };
        }
    }
}
