using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Common.Util
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
